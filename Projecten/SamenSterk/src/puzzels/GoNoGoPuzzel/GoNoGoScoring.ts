import { TrialResult, GoNoGoScore, GoNoGoResult } from './GoNoGoTypes';

export function classifyTrial(
  isGo: boolean,
  responded: boolean,
  reactionTime: number | null,
  displayDuration: number,
): GoNoGoResult {
  if (!isGo) return responded ? 'false_alarm' : 'correct_inhibit';
  return (reactionTime !== null && reactionTime <= displayDuration)
    ? 'correct_go'
    : 'miss';
}

export function scoreTrials(results: TrialResult[]): GoNoGoScore {
  const total = results.length;

  let correctGo      = 0;
  let correctInhibit = 0;
  let falseAlarms    = 0;
  let misses         = 0;
  let rtSum          = 0;
  let rtCount        = 0;

  for (const r of results) {
    switch (r.result) {
      case 'correct_go':
        correctGo++;
        // reactionTime is gegarandeerd non-null bij correct_go
        rtSum += r.reactionTime as number;
        rtCount++;
        break;
      case 'correct_inhibit': correctInhibit++; break;
      case 'false_alarm':     falseAlarms++;    break;
      case 'miss':            misses++;         break;
    }
  }

  const avgReactionTime = rtCount > 0
    ? Math.round(rtSum / rtCount)
    : null;

  const rawScore =
    ((correctGo + correctInhibit) / total) * 100 -
    (falseAlarms / total) * 50 -
    (misses      / total) * 30;

  return {
    totalTrials: total,
    correctGo,
    correctInhibit,
    falseAlarms,
    misses,
    avgReactionTime,
    score: Math.max(0, Math.round(rawScore)),
  };
}