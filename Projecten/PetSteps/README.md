# PetSteps

Een React Native-app waarin dagelijkse beweging gekoppeld wordt aan virtuele huisdieren. De app leest stappen uit, bewaart voortgang en laat gebruikers huisdieren aanmaken en verzorgen.

## Functionaliteit

- Registratie en login via Firebase Authentication.
- Stappen meten en statistieken bekijken.
- Een actief huisdier kiezen en laten evolueren op basis van beweging.
- Huisdieren aanmaken en foto's uploaden via Cloudinary.
- Locatie en kaartweergave.
- Instellingen, accountbeheer en licht/donker thema.

## Stack

- Expo 54, React Native 0.81 en TypeScript.
- React Navigation, Redux Toolkit en redux-persist.
- Firebase Authentication en Firestore.
- Expo Sensors, Location, Maps, Camera en Image Picker.
- NativeWind/Tailwind voor styling.

## Configuratie

Kopieer `.env.example` naar `.env.local` en vul de Firebase- en Cloudinary-webconfiguratie in. `EXPO_PUBLIC_*`-waarden worden in de appbundle opgenomen en mogen dus nooit servergeheimen bevatten. Beveilig Firebase met correcte Security Rules en beperk uploadpresets.

## Starten

```powershell
yarn install
Copy-Item .env.example .env.local
yarn start
```

Voor een native Android-build:

```powershell
yarn android
```

Daarvoor zijn Android Studio, een Android SDK en een emulator of toestel nodig. De map `android/` bevat native projectcode; `.gradle`, `.kotlin`, `.cxx`, `build` en `local.properties` zijn lokale buildoutput en horen niet in Git.
