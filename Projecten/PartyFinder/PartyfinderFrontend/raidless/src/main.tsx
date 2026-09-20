import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import HomePage from './pages/HomePage.tsx'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import RootLayout from './layouts/RootLayout.tsx'
import { AuthProvider } from 'react-oidc-context'
import type { UserManagerSettings } from "oidc-client-ts";
import RegisterPage from './pages/RegisterPage.tsx'
import LobbyPage from './pages/LobbyPage.tsx'
import { BaseFrontendLocal } from './uris.ts'
import AboutPage from './pages/AboutPage.tsx'
import { ProtectedRoute } from './components/ProtectedRoute.tsx'
import CreateLobbyPage from './pages/CreateLobbyPage.tsx'
import PreLobby from './components/PreLobby.tsx'
import AdminPage from './pages/AdminPage.tsx'
import DonatePage from './pages/DonatePage.tsx'
import StripeProvider from './contexts/StripeProvider.tsx'

const browserRouter = createBrowserRouter([
  {
    element: <RootLayout />,
    children: [
      {
        path: "/",
        element: <HomePage />

      },
      {
        path: "/home",
        element: <HomePage />
      },
      {
        path: "/register",
        element: <RegisterPage />
      }
      , {
        path: "/createPreLobby",
        element: <ProtectedRoute><CreateLobbyPage /></ProtectedRoute>
      },
      {
        path: "/prelobby/:preLobbyId",
        element: <ProtectedRoute><PreLobby /></ProtectedRoute>
      },
      {
        path: "/AdminPage",
        element: <ProtectedRoute requiredRole={"Admin"}><AdminPage /></ProtectedRoute>
      },
      {
        path: "/lobby/:lobbyId",
        element: <LobbyPage />
      },
      {
        path: "/about",
        element: <AboutPage />
      },
      {
        path: "/donate",
        element:
          <ProtectedRoute>
            <StripeProvider>
              <DonatePage />
            </StripeProvider>
          </ProtectedRoute>
      }
    ]
  }
]);


const settings: UserManagerSettings = {
  authority: import.meta.env.VITE_IDENTITY_URL ?? "https://localhost:5001",
  client_id: import.meta.env.VITE_OIDC_CLIENT_ID ?? "webapp-client",
  redirect_uri: BaseFrontendLocal,
  post_logout_redirect_uri: BaseFrontendLocal,
  response_type: "code",
  loadUserInfo: true,
  scope: "openid profile partyfinder.api.Read partyfinder.api.Write roles",
  monitorSession: true,
  automaticSilentRenew: true,
};


const onSigninCallback = (): void => {
  window.history.replaceState({}, document.title, window.location.pathname);
};

const onSignoutCallback = (): void => {
  window.location.href = BaseFrontendLocal;
}

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <AuthProvider {...settings} onSigninCallback={onSigninCallback} onSignoutCallback={onSignoutCallback}>
      <RouterProvider router={browserRouter} />
    </AuthProvider>
  </StrictMode>,
)
