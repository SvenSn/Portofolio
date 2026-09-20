import { PuzzleType } from '../types/shared';

export interface PuzzleItem {
  type: PuzzleType;
  label: string;
  emoji: string;

  shortDescription: string;   // ← voor lijst
  longDescription: string;    // ← voor detail
}

export const PUZZLES: PuzzleItem[] = [
  {
    type: 'goNoGo',
    label: 'Go / No‑Go',
    emoji: '🚦',
    shortDescription: 'Train impulscontrole en aandacht.',
    longDescription:
      'Je mag alleen drukken wanneer je een groene bol ziet,bij moeilijkheidsgraad: matig is cirkel symbool ook correct als deze zwart is. ,bij moeilijkheidsgraad: moeilijk is ook een cirkel en de letters A en X correct. Verschijnt er een andere kleur of een andere vorm? Dan mag je niet drukken.',
  },
  {
    type: 'stroop',
    label: 'Stroop',
    emoji: '🧠',
    shortDescription: 'Oefen selectieve aandacht en inhibitie.',
    longDescription:
      'De Stroop‑taak vraagt je om kleuren te benoemen terwijl woorden een andere betekenis hebben. Hierdoor moet je automatische reacties onderdrukken en bewust blijven focussen.',
  },
  {
    type: 'memory',
    label: 'Memory',
    emoji: '🧩',
    shortDescription: 'Werk aan visueel geheugen en herkenning.',
    longDescription:
      'Bij de memory-oefening draai je kaarten om en probeer je de juiste paren te vinden. Op makkelijk niveau werk je voornamelijk met afbeeldingen, op middelmatig niveau met woorden en op moeilijk niveau moet je afbeeldingen en woorden met elkaar combineren. Probeer zo weinig mogelijk zetten te gebruiken door goed te onthouden waar de kaarten liggen.',
  },
];