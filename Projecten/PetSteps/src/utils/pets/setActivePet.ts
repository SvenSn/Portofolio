import { doc, updateDoc } from "firebase/firestore";
import { db } from "../../config/firebase";


export const setActivePet = async (userId: string, petId: string) => {
    await updateDoc(doc(db, "users", userId), { activePetId: petId });
};