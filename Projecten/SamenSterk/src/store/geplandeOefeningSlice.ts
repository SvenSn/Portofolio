import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { GeplandeOefening } from '../types/shared'

interface GeplandeOefeningenState {
    geplandeOefeningen: GeplandeOefening[]
    status: 'idle' | 'loading' | 'error' | 'succes'
}

const initialState: GeplandeOefeningenState = {
    geplandeOefeningen: [],
    status: 'idle'
}

const geplandeOefeningenSlice = createSlice({
    name: 'geplandeOefeningen',
    initialState,
    reducers: {
        setGeplandeOefeningen: (state, action: PayloadAction<GeplandeOefening[]>) => {
            state.geplandeOefeningen = action.payload
        },
        voegGeplandeOefeningToe: (state, action: PayloadAction<GeplandeOefening>) => {
            state.geplandeOefeningen.push(action.payload)
        },
        verwijderGeplandeOefening: (state, action: PayloadAction<string>) => {
            state.geplandeOefeningen = state.geplandeOefeningen.filter(e => e.id !== action.payload)
        },
        setGedaan: (state, action: PayloadAction<{ id: string, gedaan: boolean }>) => {
            const oefening = state.geplandeOefeningen.find(e => e.id === action.payload.id)
            if (oefening) oefening.gedaan = action.payload.gedaan
        },
        setStatus: (state, action: PayloadAction<'idle' | 'loading' | 'error' | 'succes'>) => {
            state.status = action.payload
        }
    }
})

export const { setGeplandeOefeningen, voegGeplandeOefeningToe, verwijderGeplandeOefening, setGedaan, setStatus } = geplandeOefeningenSlice.actions
export default geplandeOefeningenSlice.reducer