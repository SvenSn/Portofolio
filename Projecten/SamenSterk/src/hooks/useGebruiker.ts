import { useAppSelector } from '../hooks/ReduxHooks'

export const useGebruiker = () => {
    const isAdmin = useAppSelector(state => state.gebruiker.isAdmin)
    const status = useAppSelector(state => state.gebruiker.status)

    return {
        isAdmin,
        isLoading: status === 'loading',
    }
}