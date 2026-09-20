import Lobby from '../components/Lobby'
import { useParams } from 'react-router-dom'

const LobbyPage = () => {
    const { lobbyId } = useParams<{ lobbyId: string }>();

    return (
        <div>
            <Lobby lobbyId={lobbyId ?? ''} />
        </div>
    )
}

export default LobbyPage