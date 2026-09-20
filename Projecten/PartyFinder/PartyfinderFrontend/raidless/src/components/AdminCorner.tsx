import { useEffect, useState } from "react";
import axios from "axios";
import { useAuth } from "react-oidc-context";
import Loading from "./Loading";
import type { MemberResponseContract } from "../types/types";
import { BaseLocalIS, BaseURILocal } from "../uris";

const AdminCorner = () => {
    const auth = useAuth();

    const [members, setMembers] = useState<MemberResponseContract[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [filter, setFilter] = useState<string>(""); // Username filter
    const token = auth.user?.access_token;

    const fetchMembers = async () => {
        try {
            setLoading(true);
            setError(null);

            if (!token) throw new Error("No access token found.");

            const res = await axios.get<MemberResponseContract[]>(
                `${BaseURILocal}/members/all`,
                { headers: { Authorization: `Bearer ${token}` } }
            );

            setMembers(res.data);
        } catch (e: any) {
            setError(e?.response?.data?.message ?? e?.message ?? "Failed to load members.");
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        if (!auth.isLoading && auth.isAuthenticated) fetchMembers();
        if (!auth.isLoading && !auth.isAuthenticated) {
            setLoading(false);
            setError("Not authenticated.");
        }
    }, [auth.isLoading, auth.isAuthenticated, auth.user]);

    const onRemoveClick = async (member: MemberResponseContract) => {
        try {
            await axios.delete(
                `${BaseURILocal}/members/${member.id}`,
                { headers: { Authorization: `Bearer ${token}` } }
            );
            await axios.delete(`${BaseLocalIS}/api/users/${auth.user?.profile.sub}`, { headers: { Authorization: `Bearer ${token}` } });
            fetchMembers();
        } catch (e: any) {
            setError(e?.response?.data?.message ?? e?.message ?? "Failed to remove member.");
        }
    };

    const handleExportCSV = async () => {
        try {
            if (!token) throw new Error("No access token found.");
            const res = await axios.get(`${BaseURILocal}/Members/csv`, {
                headers: { Authorization: `Bearer ${token}` },
                responseType: "blob",
            });

            const url = window.URL.createObjectURL(new Blob([res.data], { type: "text/csv" }));
            const a = document.createElement("a");
            a.href = url;
            a.download = "members.csv";
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        } catch (e: any) {
            setError(e?.response?.data?.message ?? e?.message ?? "Failed to export members.");
        }
    };

    if (loading) return <Loading />;

    // Filter members by username (case-insensitive)
    const filteredMembers = members.filter(m =>
        m.username.toLowerCase().includes(filter.toLowerCase())
    );

    return (
        <div className="min-h-[calc(100vh-160px)] text-white">
            <main className="mx-auto max-w-6xl px-6 py-10">
                <div className="flex flex-col gap-2 sm:flex-row sm:items-end sm:justify-between">
                    <div>
                        <h1 className="text-3xl font-bold tracking-tight text-blue-100">Admin Corner</h1>
                        <p className="mt-1 text-sm text-blue-200/80">
                            Members overview <span className="text-blue-200/60">({filteredMembers.length})</span>
                        </p>
                        <input
                            type="text"
                            placeholder="Filter by username..."
                            value={filter}
                            onChange={e => setFilter(e.target.value)}
                            className="mt-3 w-full sm:w-64 px-3 py-2 rounded-lg border border-blue-700 text-blue-900 shadow focus:outline-none focus:border-blue-500 bg-white"
                        />
                    </div>
                    <button
                        type="button"
                        onClick={handleExportCSV}
                        className="mt-4 sm:mt-0 inline-flex items-center rounded-lg bg-blue-600 px-4 py-2 text-sm font-semibold text-white shadow hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-400"
                    >
                        Export Members to CSV
                    </button>
                </div>

                {error && (
                    <div className="mt-6 rounded-xl border border-red-400/20 bg-red-500/10 px-4 py-3 text-sm text-red-200">
                        {error}
                    </div>
                )}

                {!error && filteredMembers.length === 0 && (
                    <div className="mt-6 rounded-2xl border border-white/10 bg-white/5 px-6 py-8 text-blue-100/80">
                        No members found.
                    </div>
                )}

                {filteredMembers.length > 0 && (
                    <section className="mt-6">
                        <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3">
                            {filteredMembers.map((m) => (
                                <article
                                    key={m.id}
                                    className="group rounded-2xl border border-white/10 bg-white/5 p-5 shadow-sm backdrop-blur transition hover:border-white/20 hover:bg-white/[0.07]"
                                >
                                    <div className="flex items-start justify-between gap-3">
                                        <div className="min-w-0">
                                            <div className="flex items-center gap-2">
                                                <h3 className="truncate text-lg font-semibold text-blue-50">
                                                    {m.username}
                                                </h3>
                                                <span className="shrink-0 rounded-full border border-amber-400/20 bg-amber-500/10 px-2 py-0.5 text-xs text-amber-100">
                                                    {m.accountType}
                                                </span>
                                            </div>

                                            <p className="mt-1 text-sm text-blue-100/70">
                                                State:{" "}
                                                <span className="font-medium text-blue-100/90">
                                                    {m.memberState}
                                                </span>
                                            </p>
                                        </div>

                                        <button
                                            type="button"
                                            onClick={() => onRemoveClick(m)}
                                            className="inline-flex h-9 w-9 items-center justify-center rounded-xl border border-white/10 bg-white/5 text-blue-50 transition hover:border-red-400/30 hover:bg-red-500/10 hover:text-red-200 focus:outline-none focus:ring-2 focus:ring-red-400/40"
                                            aria-label={`Remove ${m.username}`}
                                            title="Remove Member"
                                        >
                                            ×
                                        </button>
                                    </div>

                                    <div className="mt-4 rounded-xl border border-white/10 bg-black/20 px-3 py-2">
                                        <p className="text-[11px] text-blue-100/60">IdentityServerId</p>
                                        <p className="break-all font-mono text-xs text-blue-100/90">
                                            {m.identityserverId}
                                        </p>
                                    </div>
                                </article>
                            ))}
                        </div>
                    </section>
                )}
            </main>
        </div>
    );
};

export default AdminCorner;