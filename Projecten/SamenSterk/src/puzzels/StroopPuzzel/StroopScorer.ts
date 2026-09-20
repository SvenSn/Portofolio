import { StroopTrialResultaat, StroopScore, StroopTrialResult, StroopColor } from './StroopTypes';


export function classifyTrial(
  correctAnswer: StroopColor,
  answer: StroopColor | null,
  timeLimit: number,
  reactionTime: number | null,
): StroopTrialResult {
  if (!answer || reactionTime === null || reactionTime > timeLimit) return 'timeout';
  return answer === correctAnswer ? 'correct' : 'wrong';
}
export function calculateScore(results: StroopTrialResultaat[]): StroopScore {
  const total = results.length;

  let correct  = 0;
  let wrong    = 0;
  let timeout  = 0;
  let rtSum    = 0;
  let rtCount  = 0;

  for (const r of results) {
    switch (r.result) {
      case 'correct':
        correct++;
        rtSum += r.reactionTime as number;
        rtCount++;
        break;
      case 'wrong':   wrong++;   break;
      case 'timeout': timeout++; break;
    }
  }

  const rawScore =
    (correct / total) * 100 -
    (wrong   / total) * 30  -
    (timeout / total) * 20;

  return {
    totalTrials: total,
    correct,
    wrong,
    timeout,
    avgReactionTime: rtCount > 0 ? Math.round(rtSum / rtCount) : null,
    score: Math.max(0, Math.round(rawScore)),
  };
}