import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAuth } from 'react-oidc-context';
import { useNavigate } from 'react-router-dom';
import { BaseURILocal } from '../uris';
import { BossType, BossTypeDisplayNames, type PreLobbyRequestContract, type PreLobbyResponseContract } from '../types/types';

const partySizeOptions = [
    { label: 'Duo', value: 2 },
    { label: 'Trio', value: 3 },
    { label: '4-Man', value: 4 },
    { label: '5-Man', value: 5 },
];

const CreatePreLobby = () => {
    const { user, isAuthenticated, signinRedirect } = useAuth();
    const userId = user?.profile.sub;
    const accessToken = user?.access_token;
    const navigate = useNavigate();

    const [selectedBoss, setSelectedBoss] = useState<BossType>(BossType.Bandos);
    const [partySize, setPartySize] = useState<number>(2);
    const [creatingLobby, setCreatingLobby] = useState(false);
    const [checkingExisting, setCheckingExisting] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (!isAuthenticated || !userId || !accessToken) {
            setCheckingExisting(false);
            return;
        }

        const checkExistingLobby = async () => {
            try {
                const { data } = await axios.get<PreLobbyResponseContract>(
                    `${BaseURILocal}/prelobbies/user/${userId}`,
                    { headers: { Authorization: `Bearer ${accessToken}` } }
                );
                if (data?.id) {
                    navigate(`/prelobby/${data.id}`);
                }
            } catch (err) {
                if (!axios.isAxiosError(err) || err.response?.status !== 404) {
                    setError('Failed to check existing lobby.');
                }
            } finally {
                setCheckingExisting(false);
            }
        };

        checkExistingLobby();
    }, [isAuthenticated, userId, accessToken, navigate]);

    const handleCreateLobby = async () => {
        if (!userId || !accessToken || !isAuthenticated) {
            signinRedirect();
            return;
        }
        setCreatingLobby(true);
        setError(null);
        try {
            const payload: PreLobbyRequestContract = {
                IdentityServerId: userId,
                Boss: selectedBoss,
                TargetSize: partySize,
            };
            const { data } = await axios.post<PreLobbyResponseContract>(
                `${BaseURILocal}/prelobbies`,
                payload,
                { headers: { Authorization: `Bearer ${accessToken}` } }
            );
            navigate(data?.id ? `/prelobby/${data.id}` : '/createPreLobby');
        } catch {
            setError('Failed to create lobby.');
        } finally {
            setCreatingLobby(false);
        }
    };

    if (checkingExisting) {
        return (
            <div className="border border-slate-700 rounded-2xl bg-slate-900/70 p-6 shadow-xl">
                <div className="text-center text-slate-400">Checking for existing lobby...</div>
            </div>
        );
    }

    return (
        <div className="border border-slate-700 rounded-2xl bg-slate-900/70 p-6 shadow-xl">
            <div className="mb-6">
                <h2 className="text-2xl font-semibold text-white mb-2">Create a Lobby</h2>
                <p className="text-slate-400 text-sm">Set up your party and start recruiting players.</p>
            </div>

            {error && (
                <div className="text-red-300 bg-red-500/10 border border-red-500/30 px-4 py-3 rounded-xl mb-4">
                    {error}
                </div>
            )}

            <div className="space-y-4">
                <div>
                    <label className="block text-slate-300 text-sm font-medium mb-2">Select Boss</label>
                    <select
                        value={selectedBoss}
                        onChange={(e) => setSelectedBoss(e.target.value as BossType)}
                        className="w-full bg-slate-800 border border-slate-700 text-white rounded-xl px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    >
                        {Object.values(BossType).map((boss) => (
                            <option key={boss} value={boss}>
                                {BossTypeDisplayNames[boss]}
                            </option>
                        ))}
                    </select>
                </div>

                <div>
                    <label className="block text-slate-300 text-sm font-medium mb-2">Party Size</label>
                    <select
                        value={partySize}
                        onChange={(e) => setPartySize(Number(e.target.value))}
                        className="w-full bg-slate-800 border border-slate-700 text-white rounded-xl px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    >
                        {partySizeOptions.map((option) => (
                            <option key={option.value} value={option.value}>
                                {option.label}
                            </option>
                        ))}
                    </select>
                </div>

                <button
                    onClick={handleCreateLobby}
                    disabled={creatingLobby}
                    className="w-full bg-blue-600 hover:bg-blue-500 disabled:bg-blue-800 disabled:cursor-not-allowed text-white font-medium py-3 rounded-xl transition-colors shadow-lg shadow-blue-900/40"
                >
                    {creatingLobby ? 'Creating Lobby...' : 'Create Lobby'}
                </button>
            </div>
        </div>
    );
};

export default CreatePreLobby;