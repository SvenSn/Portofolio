# Raidless webclient

Een React 19-, TypeScript- en Vite-frontend voor PartyFinder.

## Functionaliteit

- OIDC-login met Authorization Code + PKCE.
- Publieke en beschermde routes.
- Lobby's en pre-lobby's aanmaken en bekijken.
- SignalR-updates tijdens matchmaking en lobbybeheer.
- Adminpagina voor bevoegde gebruikers.
- Stripe Elements voor de donatieflow.

## Configuratie en starten

Vereist een actuele Node.js LTS-versie. Kopieer `.env.example` naar `.env.local` en pas de URL's aan wanneer de backend niet op de standaardpoorten draait.

```powershell
npm install
Copy-Item .env.example .env.local
npm run dev
```

## Controles

```powershell
npm run lint
npm run build
```

Een Vite-client kan geen geheim veilig bewaren. Gebruik daarom nooit een `client_secret`, Stripe secret key of databasewachtwoord in `VITE_*`-variabelen.
