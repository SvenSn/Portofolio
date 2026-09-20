import { useState, useCallback, useEffect } from "react";
import { useLobbyHub } from "../hooks/useLobbyHub";
import type { LobbyResponseContract, MemberResponseContract, Message } from "../types/types";
import { useLocation } from "react-router-dom";

const Lobby = ({ lobbyId }: { lobbyId: string }) => {
    const location = useLocation();
    const lobby = location.state?.lobby;

    // Initialize members from lobby if available
    const [members, setMembers] = useState<MemberResponseContract[]>(lobby?.members ?? []);
    const [messages, setMessages] = useState<Message[]>([]);
    const [input, setInput] = useState("");
    // Boss state
    const [boss, setBoss] = useState<string>(lobby?.boss ?? "");

    const handleMessage = useCallback((msg: Message) => {
        setMessages((prev) => [...prev, msg]);
    }, []);

    const handleMatchFound = useCallback((lobby: LobbyResponseContract) => {
        setMembers(lobby.members);
        setBoss(lobby.boss);
    }, []);

    useEffect(() => {
        console.log("[Lobby] Updated members:", members);
    }, [members]);

    const { sendMessage } = useLobbyHub(lobbyId, handleMessage, handleMatchFound);

    // No React.FormEvent, just a plain function
    const handleSend = async () => {
        if (!input.trim()) return;
        try {
            await sendMessage(lobbyId, input.trim());
            setInput("");
        } catch (err) {
            // Optionally handle error
        }
    };

    return (
        <div className="flex flex-col w-full h-full px-4 py-8">
            {/* Boss display above members and chat, with a better color */}
            <section className="w-full bg-white/5 rounded-xl border border-white/10 p-6 shadow mb-8 flex flex-col items-center">
                <h2 className="text-xl font-bold text-blue-300 mb-2 text-center">Boss</h2>
                <div className="flex justify-center items-center h-16">
                    <span className="text-4xl font-extrabold text-blue-400 uppercase tracking-wide drop-shadow-lg">
                        {boss ? boss : "No Boss Selected"}
                    </span>
                </div>
            </section>
            <div className="flex flex-col md:flex-row gap-6 w-full h-full">
                <section className="flex-1 bg-white/5 rounded-xl border border-white/10 p-6 shadow">
                    <h2 className="text-xl font-bold text-blue-100 mb-4">Members</h2>
                    <div className="flex flex-col gap-3">
                        {members.length === 0 ? (
                            <div className="text-blue-200/70">No members yet.</div>
                        ) : (
                            members.map((m) => (
                                <div
                                    key={m.id}
                                    className="rounded-lg bg-blue-950/80 px-4 py-2 text-blue-100 shadow"
                                >
                                    {m.username}
                                </div>
                            ))
                        )}
                    </div>
                </section>

                <aside className="w-full md:w-100 bg-white/5 rounded-xl border border-white/10 p-6 shadow flex flex-col">
                    <h2 className="text-xl font-bold text-blue-100 mb-4">Chat</h2>
                    <div className="flex-1 flex flex-col gap-2 overflow-y-auto mb-4">
                        {messages.length === 0 ? (
                            <div className="text-gray-400 text-center my-auto">No messages yet. Say hi!</div>
                        ) : (
                            messages.map((msg, idx) => (
                                <div key={idx} className="text-blue-100">
                                    <span className="font-bold text-amber-200">{msg.username}:</span>{" "}
                                    <span>{msg.message}</span>
                                    <span className="ml-2 text-xs text-blue-200/60">
                                        {new Date(msg.timestamp).toLocaleTimeString()}
                                    </span>
                                </div>
                            ))
                        )}
                    </div>
                    <div className="flex gap-2 mt-2">
                        <input
                            type="text"
                            className="flex-1 rounded-lg px-4 py-2 bg-gray-800 text-white border border-blue-400 focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="Type your message..."
                            value={input}
                            onChange={e => setInput(e.target.value)}
                            autoComplete="off"
                            onKeyDown={e => {
                                if (e.key === "Enter") handleSend();
                            }}
                        />
                        <button
                            type="button"
                            className="bg-blue-600 text-white font-semibold px-6 py-2 rounded-lg disabled:opacity-50"
                            disabled={!input.trim()}
                            onClick={handleSend}
                        >
                            Send
                        </button>
                    </div>
                </aside>
            </div>
        </div>
    );
};

export default Lobby;