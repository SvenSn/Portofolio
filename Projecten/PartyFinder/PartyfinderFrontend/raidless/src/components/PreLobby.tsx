import { useCallback, useEffect, useRef, useState } from 'react';
import axios from 'axios';
import { useAuth } from 'react-oidc-context';
import { useParams, useNavigate } from 'react-router-dom';
import { BaseURILocal } from '../uris';
import { usePreLobbyHub } from '../hooks/usePreLobbyHub';
import { useLobbyHub } from "../hooks/useLobbyHub";
import Loading from './Loading';
import {
    BossTypeDisplayNames,
    type MemberResponseContract,
    type PreLobbyResponseContract,
} from '../types/types';

const PreLobby = () => {
    const { preLobbyId } = useParams<{ preLobbyId: string }>();
    const { user, isAuthenticated } = useAuth();
    const navigate = useNavigate();
    const userId = user?.profile.sub;
    const token = user?.access_token;

    const { currentLobby, isConnected, joinPreLobby, leavePreLobby, disbandPreLobby, ensureConnected, isQueued, joinQueue, cancelQueue } = usePreLobbyHub();

    const [lobbyData, setLobbyData] = useState<PreLobbyResponseContract | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [leavingLobby, setLeavingLobby] = useState(false);
    const [disbandingLobby, setDisbandingLobby] = useState(false);
    const [copied, setCopied] = useState(false);
    const [queueTimeElapsed, setQueueTimeElapsed] = useState(0);
    const [queueLoading, setQueueLoading] = useState(false);
    const hasJoinedRef = useRef(false);
    const queueStartTimeRef = useRef<number | null>(null);
    const hasJoinedGroupRef = useRef(false);

    useEffect(() => {
        if (isQueued) {
            if (!queueStartTimeRef.current) {
                queueStartTimeRef.current = Date.now();
            }
        } else {
            queueStartTimeRef.current = null;
            setQueueTimeElapsed(0);
        }
    }, [isQueued]);

    useEffect(() => {
        if (isQueued && queueStartTimeRef.current) {
            const timerId = setInterval(() => {
                const elapsed = Math.floor((Date.now() - queueStartTimeRef.current!) / 1000);
                setQueueTimeElapsed(elapsed);
            }, 1000);

            return () => clearInterval(timerId);
        }
    }, [isQueued]);

    const formatTime = (seconds: number) => {
        const mins = Math.floor(seconds / 60);
        const secs = seconds % 60;
        return `${mins}:${secs.toString().padStart(2, '0')}`;
    };

    useEffect(() => {
        if (currentLobby && currentLobby.id === preLobbyId) {
            setLobbyData(prev =>
                prev
                    ? {
                        ...prev,
                        members: currentLobby.members,
                        leaderId: currentLobby.leaderId,
                        targetSize: currentLobby.targetSize,
                        boss: currentLobby.boss,
                    }
                    : currentLobby
            );
        }
    }, [currentLobby, preLobbyId]);

    useEffect(() => {
        if (!isAuthenticated || !preLobbyId) return;

        const fetchPreLobby = async () => {
            setLoading(true);
            setError(null);
            try {
                const { data } = await axios.get<PreLobbyResponseContract>(
                    `${BaseURILocal}/prelobbies/${preLobbyId}`,
                    token ? { headers: { Authorization: `Bearer ${token}` } } : {}
                );
                setLobbyData(data);

                // Join via SignalR if not already joined
                if (!hasJoinedRef.current && isConnected) {
                    await ensureConnected();
                    await joinPreLobby(preLobbyId);
                    hasJoinedRef.current = true;
                }
            } catch (err) {
                if (axios.isAxiosError(err) && err.response?.status === 404) {
                    setError('Lobby not found.');
                } else {
                    setError('Failed to fetch lobby.');
                }
                setLobbyData(null);
            } finally {
                setLoading(false);
            }
        };

        fetchPreLobby();
    }, [isAuthenticated, preLobbyId, isConnected, token]);

    const ensureJoinedLobbyGroup = useCallback(async () => {
        if (!preLobbyId) return;

        await ensureConnected();

        if (hasJoinedGroupRef.current) return;

        console.log('[PreLobby] Joining SignalR lobby group:', preLobbyId);
        await joinPreLobby(preLobbyId);
        hasJoinedGroupRef.current = true;
        console.log('[PreLobby] Joined SignalR lobby group:', preLobbyId);
    }, [ensureConnected, joinPreLobby, preLobbyId]);

    useEffect(() => {
        if (!isAuthenticated) return;
        if (!preLobbyId) return;

        ensureJoinedLobbyGroup().catch((e) =>
            console.error('[PreLobby] Failed to join lobby group:', e)
        );
    }, [ensureJoinedLobbyGroup, isAuthenticated, preLobbyId]);

    const handleCopyInvite = async () => {
        if (!lobbyData?.inviteToken) return;
        const inviteUrl = `${window.location.origin}/prelobby/${lobbyData.id}`;
        try {
            await navigator.clipboard.writeText(inviteUrl);
            setCopied(true);
            setTimeout(() => setCopied(false), 2000);
        } catch {
            setError('Failed to copy invite link.');
        }
    };

    const handleQueueToggle = async () => {
        setError(null);
        setQueueLoading(true);

        try {
            console.log('[PreLobby] Starting queue toggle');
            await ensureJoinedLobbyGroup();

            if (isQueued) {
                await cancelQueue();
                return;
            }

            if (!lobbyData) return;

            await joinQueue(preLobbyId!);
            console.log('[PreLobby] joinQueue completed successfully');
        } catch (err) {
            console.error('[PreLobby] Queue error:', err);
            setError(isQueued ? 'Failed to cancel queue.' : 'Failed to join queue.');
        } finally {
            setQueueLoading(false);
        }
    };

    const handleLeaveLobby = async () => {
        if (!preLobbyId) return;
        setError(null);
        setLeavingLobby(true);
        try {
            await ensureConnected();
            await leavePreLobby(preLobbyId);
            hasJoinedRef.current = false;
            navigate('/createPreLobby');
        } catch {
            setError('Failed to leave lobby.');
        } finally {
            setLeavingLobby(false);
        }
    };

    const handleDisbandLobby = async () => {
        if (!preLobbyId) return;
        setError(null);
        setDisbandingLobby(true);
        try {
            await ensureConnected();
            await disbandPreLobby(preLobbyId);
            hasJoinedRef.current = false;
            navigate('/createPreLobby');
        } catch {
            setError('Failed to disband lobby.');
        } finally {
            setDisbandingLobby(false);
        }
    };

    useEffect(() => {
        console.log("[PreLobby] isQueued changed =>", isQueued);
    }, [isQueued]);

    useLobbyHub(
        preLobbyId ?? "",
        () => { },
        (lobby) => {
            console.log("[PreLobby] MatchFound received:", lobby);
            navigate(`/lobby/${lobby.id}`, { state: { lobby } });
        }
    );

    if (!isAuthenticated) return null;
    if (loading) return <Loading />;

    const isLeader = lobbyData && userId === lobbyData.leaderId;
    const isMember = lobbyData?.members.some((m) => m.identityserverId === userId);

    return (
        <div className="min-h-[60vh] bg-blue-1000 flex items-center justify-center px-4">
            <div className="max-w-2xl w-full bg-slate-900/70 border border-slate-700 rounded-2xl shadow-2xl p-8 backdrop-blur">
                {error && (
                    <div className="text-red-300 bg-red-500/10 border border-red-500/30 px-4 py-3 rounded-xl mb-4">
                        {error}
                    </div>
                )}

                {lobbyData && (
                    <>
                        <div className="mb-6">
                            <div className="flex items-center justify-between mb-4">
                                <div>
                                    <h2 className="text-2xl font-semibold text-white">
                                        {BossTypeDisplayNames[lobbyData.boss]} Lobby
                                    </h2>
                                    <p className="text-slate-400 text-sm">
                                        {lobbyData.members.length} / {lobbyData.targetSize - 1} Members
                                    </p>
                                </div>
                                <div className="flex gap-2 items-center">
                                    <span className="text-sm px-3 py-1 rounded-full bg-emerald-600/20 text-emerald-200 border border-emerald-700/50">
                                        {isLeader ? 'Leader' : 'Active'}
                                    </span>
                                    <button
                                        onClick={handleCopyInvite}
                                        className="text-xs px-3 py-1 rounded-lg bg-slate-700 hover:bg-slate-600 text-slate-200 border border-slate-600 transition-colors"
                                    >
                                        {copied ? '✓ Copied!' : 'Copy Invite'}
                                    </button>
                                </div>
                            </div>
                        </div>

                        <div className="flex gap-4 mb-6 overflow-x-auto min-w-96">
                            {lobbyData.members.map((member: MemberResponseContract) => (
                                <div
                                    key={member.id}
                                    className="shrink-0 w-24 bg-slate-800/50 border border-slate-700 rounded-xl p-4 flex flex-col items-center justify-center gap-3 aspect-square"
                                >
                                    <div className="text-center">
                                        <p className="text-white font-medium truncate text-sm">{member.username || 'No Username'}</p>
                                        <span className="text-xs text-slate-400">{member.accountType || 'No Type'}</span>
                                    </div>
                                </div>
                            ))}
                        </div>

                        <div className="flex gap-3">
                            {isMember ? (
                                <>
                                    {isLeader && (
                                        <button
                                            onClick={handleQueueToggle}
                                            disabled={queueLoading}
                                            className={`flex-1 flex items-center justify-center gap-2 font-medium py-3 rounded-xl transition-colors ${isQueued
                                                ? 'bg-purple-600 hover:bg-purple-500 disabled:bg-purple-800'
                                                : 'bg-green-600 hover:bg-green-500 disabled:bg-green-800'
                                                } disabled:cursor-not-allowed text-white`}
                                        >
                                            {queueLoading && (
                                                <svg className="w-5 h-5 animate-spin" fill="none" viewBox="0 0 24 24">
                                                    <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                                                    <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                                </svg>
                                            )}
                                            {isQueued ? `Queued ${formatTime(queueTimeElapsed)}` : 'Join Queue'}
                                        </button>
                                    )}

                                    {!isLeader && isQueued && (
                                        <div className="flex-1 flex items-center justify-center gap-2 font-medium py-3 rounded-xl bg-purple-600 text-white">
                                            <svg className="w-5 h-5 animate-spin" fill="none" viewBox="0 0 24 24">
                                                <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                                                <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                            </svg>
                                            Queued {formatTime(queueTimeElapsed)}
                                        </div>
                                    )}

                                    {/* Hide Leave and Disband buttons when queued */}
                                    {!isQueued && (
                                        <>
                                            <button
                                                onClick={handleLeaveLobby}
                                                disabled={leavingLobby}
                                                className="flex-1 bg-blue-600 hover:bg-blue-500 disabled:bg-blue-800 disabled:cursor-not-allowed text-white font-medium py-3 rounded-xl transition-colors"
                                            >
                                                {leavingLobby ? 'Leaving...' : 'Leave Lobby'}
                                            </button>

                                            {isLeader && (
                                                <button
                                                    onClick={handleDisbandLobby}
                                                    disabled={disbandingLobby}
                                                    className="flex-1 bg-red-600 hover:bg-red-500 disabled:bg-red-800 disabled:cursor-not-allowed text-white font-medium py-3 rounded-xl transition-colors"
                                                >
                                                    {disbandingLobby ? 'Disbanding...' : 'Disband Lobby'}
                                                </button>
                                            )}
                                        </>
                                    )}
                                </>
                            ) : null}
                        </div>
                    </>
                )}
            </div>
        </div>
    );
};

export default PreLobby;