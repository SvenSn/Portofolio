import { createSlice, PayloadAction } from '@reduxjs/toolkit'

interface GebruikerState {
    isAdmin: boolean | null
    status: 'idle' | 'loading' | 'error'
}

const initialState: GebruikerState = {
    isAdmin: null,
    status: 'idle'
}

const gebruikerSlice = createSlice({
    name: 'gebruiker',
    initialState,
    reducers: {
        setGebruiker(state, action: PayloadAction<{ isAdmin: boolean }>) {
            state.isAdmin = action.payload.isAdmin
            state.status = 'idle'
        },
        clearGebruiker(state) {
            state.isAdmin = null
            state.status = 'idle'
        }
    }
})

export const { setGebruiker, clearGebruiker } = gebruikerSlice.actions
export default gebruikerSlice.reducer