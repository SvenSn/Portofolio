import React, { useState } from "react";
import type { ChatBoxProps } from "../types/types";

const Chat = ({ messages, onSend }: ChatBoxProps) => {
    const [input, setInput] = useState("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!input.trim()) return;
        await onSend(input.trim());
        setInput("");
    };

    return (
        <div className="flex flex-col h-full">
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
            <form className="flex gap-2 mt-2" onSubmit={handleSubmit}>
                <input
                    type="text"
                    className="flex-1 rounded-lg px-4 py-2 bg-gray-800 text-white border border-blue-400 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    placeholder="Type your message..."
                    value={input}
                    onChange={e => setInput(e.target.value)}
                    autoComplete="off"
                />
                <button
                    type="submit"
                    className="bg-blue-600 text-white font-semibold px-6 py-2 rounded-lg disabled:opacity-50"
                    disabled={!input.trim()}
                >
                    Send
                </button>
            </form>
        </div>
    );
};

export default Chat;