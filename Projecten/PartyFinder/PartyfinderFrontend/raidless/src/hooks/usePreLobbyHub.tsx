import { useEffect, useState, useCallback, useRef } from 'react';
import { useAuth } from 'react-oidc-context';
import { hubManager } from '../HubManagers/HubManager';
import type { PreLobbyResponseContract, QueuePartyResponseContract } from '../types/types';

export function usePreLobbyHub() {
    const auth = useAuth();
    const [currentLobby, setCurrentLobby] = useState<PreLobbyResponseContract | null>(null);
    const [isConnected, setIsConnected] = useState(false);
    const [queueParty, setQueueParty] = useState<QueuePartyResponseContract | null>(null);
    const [isQueued, setIsQueued] = useState(false);

    const listenersSetupRef = useRef(false);

    useEffect(() => {
        const token = auth.user?.access_token;
        if (!token) return;

        const connect = async () => {
            try {
                await hubManager.connectPreLobbyHub(token);
                setIsConnected(true);

                if (!listenersSetupRef.current) {
                    hubManager.onPreLobbyUpdated((lobby: PreLobbyResponseContract) => {
                        setCurrentLobby(lobby);
                    });
                    hubManager.onPreLobbyDisbanded(() => {
                        setCurrentLobby(null);
                    });
                    hubManager.onQueueJoined((data: QueuePartyResponseContract) => {
                        setQueueParty(data);
                        setIsQueued(true);
                    });
                    hubManager.onQueueLeft(() => {
                        setQueueParty(null);
                        setIsQueued(false);
                    });
                    hubManager.onQueueJoinedAllDebug(() => { });
                    listenersSetupRef.current = true;
                }
            } catch (error) {
                setIsConnected(false);
            }
        };

        connect();
        // No cleanup - connection stays alive
    }, [auth.user?.access_token]);

    const ensureConnected = useCallback(async () => {
        if (hubManager.isConnected()) return;
        const token = auth.user?.access_token;
        if (!token) throw new Error('No access token for hub connection');
        await hubManager.connectPreLobbyHub(token);
        setIsConnected(true);
    }, [auth.user?.access_token]);

    const joinPreLobby = useCallback(async (preLobbyId: string) => {
        let retries = 0;
        while (!hubManager.isConnected() && retries < 20) {
            await new Promise(resolve => setTimeout(resolve, 100));
            retries++;
        }
        if (!hubManager.isConnected()) throw new Error('Hub connection not established');
        await hubManager.joinPreLobby(preLobbyId);
    }, []);

    const joinQueue = useCallback(
        async (preLobbyId: string) => {
            let retries = 0;
            while (!hubManager.isConnected() && retries < 20) {
                await new Promise(resolve => setTimeout(resolve, 100));
                retries++;
            }
            if (!hubManager.isConnected()) throw new Error('Hub connection not established');
            await hubManager.joinQueue(preLobbyId);
        },
        []
    );

    const cancelQueue = useCallback(async () => {
        if (!queueParty) return;
        let retries = 0;
        while (!hubManager.isConnected() && retries < 20) {
            await new Promise(resolve => setTimeout(resolve, 100));
            retries++;
        }
        if (!hubManager.isConnected()) throw new Error('Hub connection not established');
        await hubManager.leaveQueue(queueParty.id);
    }, [queueParty]);

    const leavePreLobby = useCallback(async (preLobbyId: string) => {
        let retries = 0;
        while (!hubManager.isConnected() && retries < 20) {
            await new Promise(resolve => setTimeout(resolve, 100));
            retries++;
        }
        if (!hubManager.isConnected()) throw new Error('Hub connection not established');
        await hubManager.leavePreLobby(preLobbyId);
        setCurrentLobby(null);
    }, []);

    const disbandPreLobby = useCallback(async (preLobbyId: string) => {
        let retries = 0;
        while (!hubManager.isConnected() && retries < 20) {
            await new Promise(resolve => setTimeout(resolve, 100));
            retries++;
        }
        if (!hubManager.isConnected()) throw new Error('Hub connection not established');
        await hubManager.disbandPreLobby(preLobbyId);
    }, []);

    return {
        currentLobby,
        isConnected,
        isQueued,
        queueParty,
        ensureConnected,
        joinPreLobby,
        leavePreLobby,
        disbandPreLobby,
        joinQueue,
        cancelQueue
    };
}