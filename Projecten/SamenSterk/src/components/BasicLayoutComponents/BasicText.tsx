import { AccessibilityProps, Text, TextProps } from "react-native";
import { twMerge } from "tailwind-merge";
import { useAppSelector } from "../../hooks/ReduxHooks";

type Variant = "title" | "body" | "label";

type BasicTextProps = TextProps & {
    className?: string;
    variant?: Variant;
} & AccessibilityProps

const variantStyles: Record<Variant, string> = {
    title: "text-slate-900 dark:text-slate-50 font-bold",
    body: "text-slate-800 dark:text-slate-50",
    label: "text-slate-500 dark:text-slate-400",
};

const sizeStyles = {
    normal: {
        title: "text-2xl",
        body: "text-base",
        label: "text-sm",
    },
    large: {
        title: "text-3xl",
        body: "text-lg",
        label: "text-base",
    },
};

const BasicText = ({
    className,
    variant = "body",
    ...props
}: BasicTextProps) => {
    const textSize = useAppSelector((state) => state.accountSettings.textSize);

    return (
        <Text
            className={twMerge(
                variantStyles[variant],
                sizeStyles[textSize][variant],
                className
            )}
            {...props}
        />
    );
};

export default BasicText;