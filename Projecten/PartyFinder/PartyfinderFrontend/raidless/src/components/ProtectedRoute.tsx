import { Navigate } from "react-router-dom";
import { useAuth } from "react-oidc-context";
import { useEffect } from "react";
import Loading from "./Loading";
import type { ProtectedRouteProps } from "../types/types";

// Role hierarchy (all lowercase, consistent)
const ROLE_HIERARCHY: Record<string, string[]> = {
    admin: ["admin", "user"],
    user: ["user"],
};

const normalizeRole = (value: unknown) =>
    typeof value === "string" ? value.trim().toLowerCase() : "";

export function ProtectedRoute({ children, requiredRole }: ProtectedRouteProps) {
    const auth = useAuth();

    useEffect(() => {
        if (!auth.isLoading && !auth.isAuthenticated) {
            auth.signinRedirect();
        }
    }, [auth.isLoading, auth.isAuthenticated, auth]);

    if (auth.isLoading) return <Loading />;
    if (!auth.isAuthenticated) return <Loading />;

    if (requiredRole) {
        const rolesClaim = auth.user?.profile.role;
        const userRolesRaw = Array.isArray(rolesClaim)
            ? rolesClaim
            : rolesClaim
                ? [rolesClaim]
                : [];

        const userRoles = userRolesRaw.map(normalizeRole).filter(Boolean);

        const requiredRolesRaw = Array.isArray(requiredRole) ? requiredRole : [requiredRole];
        const requiredRoles = requiredRolesRaw.map(normalizeRole).filter(Boolean);

        const hasAccess = requiredRoles.some((req) =>
            userRoles.some((userRole) => ROLE_HIERARCHY[userRole]?.includes(req))
        );

        if (!hasAccess) return <Navigate to="/unauthorized" replace />;
    }

    return children;
}
