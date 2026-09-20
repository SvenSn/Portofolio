import * as signalR from '@microsoft/signalr';
import { HubBaseURI } from '../uris';
import type { PreLobbyResponseContract, QueuePartyResponseContract } from '../types/types';

const BASE_URL = HubBaseURI;

class HubManager {
    private preLobbyConn: signalR.HubConnection | null = null;
    private preLobbyConnectPromise: Promise<signalR.HubConnection> | null = null;

    private lobbyConn: signalR.HubConnection | null = null;
    private lobbyConnectPromise: Promise<signalR.HubConnection> | null = null;

    private queueJoinedCallbacks: Array<(data: QueuePartyResponseContract) => void> = [];

    async connectPreLobbyHub(token: string): Promise<signalR.HubConnection> {
        if (this.preLobbyConn?.state === signalR.HubConnectionState.Connected) {
            return this.preLobbyConn;
        }
        if (this.preLobbyConnectPromise) {
            return this.preLobbyConnectPromise;
        }

        this.preLobbyConn = new signalR.HubConnectionBuilder()
            .withUrl(`${BASE_URL}/hubs/prelobby`, {
                accessTokenFactory: () => token
            })
            .configureLogging(signalR.LogLevel.Information)
            .withAutomaticReconnect()
            .build();
        this.preLobbyConn.serverTimeoutInMilliseconds = 180_000;
        this.preLobbyConn.keepAliveIntervalInMilliseconds = 30_000;
        this.preLobbyConnectPromise = (async () => {
            try {
                await this.preLobbyConn!.start();
                this.preLobbyConn!.off('QueueJoined');
                this.preLobbyConn!.on('QueueJoined', (data: any) => {
                    this.queueJoinedCallbacks.forEach(cb => cb(data));
                });
                return this.preLobbyConn!;
            } catch (err) {
                throw err;
            } finally {
                this.preLobbyConnectPromise = null;
            }
        })();

        return this.preLobbyConnectPromise;
    }

    async joinPreLobby(preLobbyId: string): Promise<void> {
        if (!this.preLobbyConn || this.preLobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to PreLobby hub');
        }
        await this.preLobbyConn.invoke('Join', preLobbyId);
    }

    async leavePreLobby(preLobbyId: string): Promise<void> {
        if (!this.preLobbyConn || this.preLobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to PreLobby hub');
        }
        await this.preLobbyConn.invoke('Leave', preLobbyId);
    }
    async disbandPreLobby(preLobbyId: string): Promise<void> {
        if (!this.preLobbyConn || this.preLobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to PreLobby hub');
        }
        await this.preLobbyConn.invoke('Disband', preLobbyId);
    }
    onPreLobbyUpdated(callback: (lobby: PreLobbyResponseContract) => void): void {
        if (!this.preLobbyConn) {
            return;
        }
        this.preLobbyConn.off('PreLobbyUpdated', callback);
        this.preLobbyConn.on('PreLobbyUpdated', callback);
    }

    onPreLobbyDisbanded(callback: (lobbyId: string) => void): void {
        if (!this.preLobbyConn) {
            return;
        }
        this.preLobbyConn.off('PreLobbyDisbanded', callback);
        this.preLobbyConn.on('PreLobbyDisbanded', callback);
    }

    offPreLobbyUpdated(callback: (lobby: PreLobbyResponseContract) => void): void {
        this.preLobbyConn?.off('PreLobbyUpdated', callback);
    }

    offPreLobbyDisbanded(callback: (lobbyId: string) => void): void {
        this.preLobbyConn?.off('PreLobbyDisbanded', callback);
    }

    isConnected(): boolean {
        return this.preLobbyConn?.state === signalR.HubConnectionState.Connected;
    }
    async disconnectPreLobbyHub(): Promise<void> {
        await this.preLobbyConn?.stop();
        this.preLobbyConn = null;
        this.preLobbyConnectPromise = null;
        this.queueJoinedCallbacks = [];
    }

    async disconnectAll(): Promise<void> {
        await this.disconnectPreLobbyHub();
    }

    async joinQueue(preLobbyId: string): Promise<void> {
        if (!this.preLobbyConn || this.preLobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to PreLobby hub');
        }
        await this.preLobbyConn.invoke('JoinQueue', preLobbyId);
    }

    async leaveQueue(queuePartyId: string): Promise<void> {
        if (!this.preLobbyConn || this.preLobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to PreLobby hub');
        }
        await this.preLobbyConn.invoke('LeaveQueue', queuePartyId);
    }

    onQueueJoined(callback: (data: QueuePartyResponseContract) => void) {
        if (!this.preLobbyConn) {
            return;
        }
        if (!this.queueJoinedCallbacks.includes(callback)) {
            this.queueJoinedCallbacks.push(callback);
        }
    }

    offQueueJoined(callback: (data: QueuePartyResponseContract) => void) {
        this.queueJoinedCallbacks = this.queueJoinedCallbacks.filter(cb => cb !== callback);
        if (this.queueJoinedCallbacks.length === 0 && this.preLobbyConn) {
            this.preLobbyConn.off('QueueJoined');
        }
    }

    onQueueLeft(callback: () => void) {
        if (this.preLobbyConn) {
            this.preLobbyConn.off('QueueLeft', callback);
            this.preLobbyConn.on('QueueLeft', callback);
        }
    }

    offQueueLeft(callback: () => void) {
        this.preLobbyConn?.off('QueueLeft', callback);
    }

    onQueueJoinedAllDebug(callback: (data: any) => void) {
        if (!this.preLobbyConn) return;
        this.preLobbyConn.off("QueueJoined_ALL_DEBUG", callback);
        this.preLobbyConn.on("QueueJoined_ALL_DEBUG", callback);
    }

    async connectLobbyHub(token: string): Promise<signalR.HubConnection> {
        if (this.lobbyConn?.state === signalR.HubConnectionState.Connected) {
            return this.lobbyConn;
        }
        if (this.lobbyConnectPromise) {
            return this.lobbyConnectPromise;
        }
        this.lobbyConn = new signalR.HubConnectionBuilder()
            .withUrl(`${HubBaseURI}/hubs/lobby`, {
                accessTokenFactory: () => token
            })
            .configureLogging(signalR.LogLevel.Information)
            .withAutomaticReconnect()
            .build();
        this.lobbyConn.serverTimeoutInMilliseconds = 180_000;
        this.lobbyConn.keepAliveIntervalInMilliseconds = 30_000;
        this.lobbyConnectPromise = (async () => {
            try {
                await this.lobbyConn!.start();
                return this.lobbyConn!;
            } catch (err) {
                throw err;
            } finally {
                this.lobbyConnectPromise = null;
            }
        })();
        return this.lobbyConnectPromise;
    }

    async sendLobbyMessage(lobbyId: string, message: string) {
        if (!this.lobbyConn || this.lobbyConn.state !== signalR.HubConnectionState.Connected) {
            throw new Error('Not connected to Lobby hub');
        }
        await this.lobbyConn.invoke('SendMessage', lobbyId, message);
    }
}

export const hubManager = new HubManager();

