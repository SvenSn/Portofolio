import { useRef, useEffect, useCallback } from "react";
import { useAuth } from "react-oidc-context";
import { hubManager } from "../HubManagers/HubManager";
import type { LobbyResponseContract, Message } from "../types/types";

export function useLobbyHub(
    lobbyId: string,
    onMessage: (msg: Message) => void,
    onMatchFound?: (lobby: LobbyResponseContract) => void
) {
    const auth = useAuth();
    const callbackRef = useRef(onMessage);
    const matchFoundRef = useRef(onMatchFound);
    const connRef = useRef<any>(null);

    useEffect(() => {
        callbackRef.current = onMessage;
        matchFoundRef.current = onMatchFound;
    }, [onMessage, onMatchFound]);

    const receiveMessageHandler = useCallback((msg: Message) => {
        callbackRef.current(msg);
    }, []);

    const matchFoundHandler = useCallback((lobby: LobbyResponseContract) => {
        matchFoundRef.current?.(lobby);
    }, []);

    useEffect(() => {
        if (!auth.user?.access_token || !lobbyId) return;

        let connection: any = null;

        const connect = async () => {
            if (connRef.current) {
                connRef.current.off?.("ReceiveMessage", receiveMessageHandler);
                connRef.current.off?.("MatchFound", matchFoundHandler);
                await connRef.current.stop?.();
                connRef.current = null;
            }

            connection = await hubManager.connectLobbyHub(auth.user!.access_token);
            connRef.current = connection;

            await connection.invoke("JoinLobby", lobbyId);

            connection.on("ReceiveMessage", receiveMessageHandler);
            connection.on("MatchFound", matchFoundHandler);
        };

        connect();

        return () => {
            if (connRef.current) {
                connRef.current.off?.("ReceiveMessage", receiveMessageHandler);
                connRef.current.off?.("MatchFound", matchFoundHandler);
                connRef.current.stop?.();
                connRef.current = null;
            }
        };
    }, [auth.user?.access_token, lobbyId, receiveMessageHandler, matchFoundHandler]);

    const sendMessage = async (lobbyId: string, message: string) => {
        if (!connRef.current) return;
        await connRef.current.invoke("SendMessage", lobbyId, message);
    };

    return { sendMessage };
}