import { onSnapshot, collection } from "firebase/firestore";
import { useEffect } from "react";
import { db } from "../firebase";
import { setExercises } from "../store/oefeningenSlice";
import { useAppDispatch } from "./ReduxHooks";
import { Exercise } from '../types/shared'

export const useOefeningenListener = () => {
  const dispatch = useAppDispatch()

  useEffect(() => {
    const subscribe = onSnapshot(collection(db, "Oefeningen"), (snapshot) => {
      const data = snapshot.docs.map(doc => ({
        id: doc.id,
        ...doc.data()
      } as Exercise));

      dispatch(setExercises(data));
      console.log("oefeningen gefetched");
    })

    return subscribe
  }, [])
}