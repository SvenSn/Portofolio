import { loadStripe, type Stripe } from '@stripe/stripe-js';
import { Elements } from '@stripe/react-stripe-js';
import { useEffect, useState, type PropsWithChildren } from 'react';
import axios from 'axios';
import { useAuth } from 'react-oidc-context';
import Loading from '../components/Loading';
import { BaseURILocal } from '../uris';

export default function StripeProviderWrapper({ children }: PropsWithChildren) {
    const [stripePromise, setStripePromise] = useState<Stripe | null>(null);
    const auth = useAuth();
    const token = auth.user?.access_token;
    useEffect(() => {
        async function fetchKey() {
            try {
                const res = await axios.get(BaseURILocal + '/payments/config', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
                console.log(res.data);
                const publishableKey = res.data.publishableKey;
                console.log(publishableKey);
                const stripe = await loadStripe(publishableKey);
                setStripePromise(stripe);
            } catch (err) {
                console.error('Failed to fetch Stripe key:', err);
            }
        }

        fetchKey();
    }, []);

    if (!stripePromise) return <div><Loading /></div>;

    return <Elements stripe={stripePromise}>{children}</Elements>;
}
