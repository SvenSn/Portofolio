import { useState } from "react";
import { useStripe, useElements, CardNumberElement, CardExpiryElement, CardCvcElement } from "@stripe/react-stripe-js";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import axios from "axios";
import { BaseURILocal } from "../uris";

const currencies = ["eur", "usd", "gbp"];

const validationSchema = Yup.object({
    amount: Yup.number()
        .min(1, "Amount must be at least 1")
        .required("Amount is required"),
    currency: Yup.string()
        .oneOf(currencies, "Invalid currency")
        .required("Currency is required"),
});

const Payment = () => {
    const stripe = useStripe();
    const elements = useElements();
    const [message, setMessage] = useState("");
    const [loading, setLoading] = useState(false);

    const handleSubmit = async (values: { amount: number; currency: string }) => {
        if (!stripe || !elements) return;
        setLoading(true);
        setMessage("");

        try {
            const res = await axios.post(BaseURILocal + "/payments/create-payment-intent", {
                amount: Math.round(values.amount * 100), //maal 100 want cent
                currency: values.currency,
            });

            const { clientSecret } = res.data;

            const cardNumberElement = elements.getElement(CardNumberElement);
            const cardExpiryElement = elements.getElement(CardExpiryElement);
            const cardCvcElement = elements.getElement(CardCvcElement);

            if (!cardNumberElement || !cardExpiryElement || !cardCvcElement) {
                setMessage("Card information is incomplete.");
                setLoading(false);
                return;
            }

            const { error, paymentIntent } = await stripe.confirmCardPayment(clientSecret, {
                payment_method: {
                    card: cardNumberElement,
                    billing_details: {},
                },
            });

            if (error) {
                setMessage(error.message ?? "Payment failed");
            } else if (paymentIntent?.status === "succeeded") {
                setMessage("Donation succeeded!");
            }
        } catch (err) {
            console.error(err);
            setMessage("Something went wrong.");
        }

        setLoading(false);
    };

    return (
        <div className="max-w-md mx-auto p-8 bg-white/5 rounded-xl border border-white/10 shadow mt-10">
            <h2 className="text-2xl font-bold text-blue-100 mb-6 text-center">Donate Here</h2>
            <div className="mb-6">
                <div className="flex items-center gap-3 bg-blue-950/80 border border-blue-400/40 rounded-xl px-4 py-3 shadow">
                    <span className="text-blue-200 text-sm font-medium">
                        Use test card:
                    </span>
                    <span className="font-mono bg-gray-800 px-3 py-1 rounded text-blue-100 text-base select-all tracking-widest">
                        4242 4242 4242 4242
                    </span>
                    <button
                        type="button"
                        className="inline-flex items-center gap-1 px-3 py-1.5 rounded-lg bg-linear-to-r from-blue-600 to-blue-500 text-white text-xs font-semibold shadow hover:from-blue-700 hover:to-blue-600 transition"
                        onClick={() => navigator.clipboard.writeText("4242 4242 4242 4242")}
                    >
                        <svg xmlns="http://www.w3.org/2000/svg" className="h-4 w-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <title>Copy</title>
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 16h8M8 12h8m-7 8h6a2 2 0 002-2V6a2 2 0 00-2-2H8a2 2 0 00-2 2v12a2 2 0 002 2z" />
                        </svg>
                        Copy
                    </button>
                </div>
                <div className="mt-2 text-blue-300 text-xs">
                    Any future expiry, any CVC.<br />
                    <span className="text-red-300 font-semibold">This is purely a simulation. DO NOT PUT REAL INFO IN HERE.</span>
                </div>
            </div>
            <Formik
                initialValues={{ amount: 10, currency: "eur" }}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}
            >
                {({ values }) => (
                    <Form autoComplete="off">
                        <div className="mb-4" >
                            <label className="block text-blue-200 mb-1">Amount</label>
                            <Field autoComplete="off"
                                type="number"
                                name="amount"
                                className="w-full rounded-lg px-4 py-2 bg-gray-800 text-white border border-blue-400 focus:outline-none focus:ring-2 focus:ring-blue-500"
                            />
                            <ErrorMessage name="amount" component="div" className="text-red-400 text-sm mt-1" />
                        </div>

                        <div className="mb-4">
                            <label className="block text-blue-200 mb-1">Currency</label>
                            <Field autoComplete="off"
                                as="select"
                                name="currency"
                                className="w-full rounded-lg px-4 py-2 bg-gray-800 text-white border border-blue-400 focus:outline-none focus:ring-2 focus:ring-blue-500"
                            >
                                {currencies.map((c) => (
                                    <option key={c} value={c}>
                                        {c.toUpperCase()}
                                    </option>
                                ))}
                            </Field>
                            <ErrorMessage name="currency" component="div" className="text-red-400 text-sm mt-1" />
                        </div>

                        <div className="mb-6">
                            <label className="block text-blue-200 mb-1">Card Number</label>
                            <div className="p-3 bg-gray-900 rounded-lg border border-blue-400 mb-3">
                                <CardNumberElement
                                    options={{
                                        style: {
                                            base: {
                                                color: "#fff",
                                                fontFamily: "inherit",
                                                fontSize: "16px",
                                                "::placeholder": { color: "#a0aec0" },
                                            },
                                            invalid: { color: "#f87171" },
                                        },
                                    }}
                                />
                            </div>
                            <div className="flex gap-3">
                                <div className="flex-1">
                                    <label className="block text-blue-200 mb-1">Expiry</label>
                                    <div className="p-3 bg-gray-900 rounded-lg border border-blue-400">
                                        <CardExpiryElement
                                            options={{
                                                style: {
                                                    base: {
                                                        color: "#fff",
                                                        fontFamily: "inherit",
                                                        fontSize: "16px",
                                                        "::placeholder": { color: "#a0aec0" },
                                                    },
                                                    invalid: { color: "#f87171" },
                                                },
                                            }}
                                        />
                                    </div>
                                </div>
                                <div className="flex-1">
                                    <label className="block text-blue-200 mb-1">CVC</label>
                                    <div className="p-3 bg-gray-900 rounded-lg border border-blue-400">
                                        <CardCvcElement
                                            options={{
                                                style: {
                                                    base: {
                                                        color: "#fff",
                                                        fontFamily: "inherit",
                                                        fontSize: "16px",
                                                        "::placeholder": { color: "#a0aec0" },
                                                    },
                                                    invalid: { color: "#f87171" },
                                                },
                                            }}
                                        />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <button
                            type="submit"
                            disabled={!stripe || loading}
                            className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold px-6 py-3 rounded-lg transition disabled:opacity-50"
                        >
                            {loading
                                ? "Processing..."
                                : `Donate ${values.amount} ${values.currency.toUpperCase()}`}
                        </button>
                    </Form>
                )}
            </Formik>

            {message && (
                <div
                    className={`mt-6 text-center rounded-lg px-4 py-3 ${message.includes("succeed")
                        ? "bg-green-600/20 text-green-300 border border-green-400/30"
                        : "bg-red-600/20 text-red-300 border border-red-400/30"
                        }`}
                >
                    {message}
                </div>
            )}
        </div>
    );
};

export default Payment;
