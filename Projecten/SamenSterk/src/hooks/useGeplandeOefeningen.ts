import { collection, getDocs, addDoc, deleteDoc, doc, updateDoc } from 'firebase/firestore'
import { db } from '../firebase'
import { useAppDispatch } from './ReduxHooks'
import { setGeplandeOefeningen, voegGeplandeOefeningToe, verwijderGeplandeOefening, setGedaan, setStatus } from '../store/geplandeOefeningSlice'
import { GeplandeOefening } from '../types/shared'

const useGeplandeOefeningen = (uid: string) => {
    const dispatch = useAppDispatch()

    const haalGeplandeOefeningenOp = async () => {
        dispatch(setStatus('loading'))
        try {
            const snapshot = await getDocs(collection(db, 'gebruikers', uid, 'geplandeOefeningen'))
            const data = snapshot.docs.map(doc => ({ id: doc.id, ...doc.data() } as GeplandeOefening))
            dispatch(setGeplandeOefeningen(data))
            dispatch(setStatus('succes'))
        } catch {
            dispatch(setStatus('error'))
        }
    }

    const voegOefeningToe = async (oefening: Omit<GeplandeOefening, 'id'>) => {
        try {
            const docRef = await addDoc(collection(db, 'gebruikers', uid, 'geplandeOefeningen'), oefening)
            dispatch(voegGeplandeOefeningToe({ id: docRef.id, ...oefening }))
        } catch {
            dispatch(setStatus('error'))
        }
    }

    const verwijderOefening = async (id: string) => {
        try {
            await deleteDoc(doc(db, 'gebruikers', uid, 'geplandeOefeningen', id))
            dispatch(verwijderGeplandeOefening(id))
        } catch {
            dispatch(setStatus('error'))
        }
    }

    const wisselGedaan = async (id: string, gedaan: boolean) => {
        try {
            await updateDoc(doc(db, 'gebruikers', uid, 'geplandeOefeningen', id), { gedaan })
            dispatch(setGedaan({ id, gedaan }))
        } catch {
            dispatch(setStatus('error'))
        }
    }

    return { haalGeplandeOefeningenOp, voegOefeningToe, verwijderOefening, wisselGedaan }
}

export default useGeplandeOefeningen