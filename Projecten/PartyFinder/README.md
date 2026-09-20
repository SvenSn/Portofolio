# PartyFinder

Een full-stack platform waarmee spelers een groep kunnen samenstellen voor raids en andere groepsactiviteiten. De applicatie combineert matchmaking, lobbybeheer, profielen, realtime updates, authenticatie en donaties.

## Onderdelen

- [`PartyfinderBackend`](PartyfinderBackend/README.md): ASP.NET Core API, IdentityServer, persistence en tests.
- [`PartyfinderFrontend/raidless`](PartyfinderFrontend/raidless/README.md): React 19-, TypeScript- en Vite-client.

## Belangrijkste functies

- Registratie en OIDC-login met rollen en beschermde routes.
- Pre-lobby's, wachtrijen, matchmaking en definitieve lobby's.
- Realtime lobby-updates via SignalR.
- OSRS-hiscore-integratie en profielgegevens.
- Afbeeldingsopslag en een Stripe-donatieflow.
- Beheerfunctionaliteit en geautomatiseerde backendtests.

## Lokaal starten

Start eerst IdentityServer en de API volgens de backend-README. Start daarna de frontend:

```powershell
cd .\PartyfinderFrontend\raidless
npm install
Copy-Item .env.example .env.local
npm run dev
```

De lokale standaardpoorten zijn 5001 voor IdentityServer, 7077 voor de API en 5173 voor Vite.

## Beveiliging

Databaseverbindingen, Stripe-sleutels en vertrouwelijke OAuth-clients horen in environmentvariabelen of een lokale secret store. Een browserclient is een publieke OIDC-client en gebruikt daarom Authorization Code + PKCE zonder `client_secret`.
