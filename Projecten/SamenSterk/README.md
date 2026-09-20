# SamenSterk

Een toegankelijke React Native-app voor het plannen en uitvoeren van oefeningen en cognitieve puzzels. Gebruikers kunnen hun oefeningen beheren; admins kunnen nieuwe inhoud toevoegen.

## Functionaliteit

- Registratie, login en accountinstellingen via Firebase.
- Oefeningen bekijken, inplannen en als uitgevoerd markeren.
- Kalenderweergave per dag, week of maand.
- Cognitieve puzzels zoals Memory, Stroop en Go/No-Go.
- Moeilijkheidsgraden en scores per puzzel.
- Adminscherm om oefeningen met stappen aan te maken.
- Donkere modus, grotere tekst en toegankelijkheidsinstellingen.

## Stack

- Expo 54, React Native 0.81 en TypeScript.
- Firebase Authentication en Firestore.
- Redux Toolkit, React Navigation en AsyncStorage.
- NativeWind/Tailwind, Formik en Yup.

## Configuratie en starten

Kopieer `.env.example` naar `.env.local` en vul de Firebase-webconfiguratie in. Deze publieke clientconfiguratie vervangt geen beveiligde Firestore Security Rules.

```powershell
npm install
Copy-Item .env.example .env.local
npm start
```

Gebruik `npm run android`, `npm run ios` of `npm run web` om een specifiek platform te openen. Gebruik bij voorkeur één package manager; `package-lock.json` is momenteel de npm-lockfile.
