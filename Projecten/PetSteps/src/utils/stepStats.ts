import { Timestamp } from "firebase/firestore";

const pad2 = (n: number) => String(n).padStart(2, "0");

export const toDateKey = (date: Date): string => {
    return `${date.getFullYear()}-${pad2(date.getMonth() + 1)}-${pad2(
        date.getDate()
    )}`;
};

export const fromDateKey = (key: string): Date => {
    const [year, month, day] = key.split("-").map(Number);
    return new Date(year, (month ?? 1) - 1, day ?? 1);
};

// datum van vandaag als string, bv. "2024-01-15"
export const getTodayKey = (): string => {
    return toDateKey(new Date());
};

// datum van gisteren als string
export const getYesterdayKey = (): string => {
    const gisteren = new Date();
    gisteren.setDate(gisteren.getDate() - 1);
    return toDateKey(gisteren);
};

// weeknummer als string, bv. "2024-W03"
export const getWeekKeyFromDate = (date: Date): string => {
    const startOfYear = new Date(date.getFullYear(), 0, 1);
    const weekNummer = Math.ceil(
        ((date.getTime() - startOfYear.getTime()) / 86400000 +
            startOfYear.getDay() +
            1) /
            7
    );
    return `${date.getFullYear()}-W${String(weekNummer).padStart(2, "0")}`;
};

export const getWeekKey = (): string => {
    return getWeekKeyFromDate(new Date());
};

export const getWeekKeyFromDateKey = (key: string): string => {
    return getWeekKeyFromDate(fromDateKey(key));
};

// vervaldatum 30 dagen vanaf nu voor Firebase TTL
export const getExpireAt = (): Timestamp => {
    const datum = new Date();
    datum.setDate(datum.getDate() + 30);
    return Timestamp.fromDate(datum);
};