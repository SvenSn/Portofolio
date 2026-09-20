import { collection, addDoc, doc, updateDoc } from "firebase/firestore";
import { db } from "../config/firebase";
import { Pet, PetType } from "../types";
import { maakHuisdier } from "../utils/pets/MakePet";

export async function createPet(
    userId: string,
    name: string,
    type: PetType,
    imageUrl: string
) {
    const petsRef = collection(db, "users", userId, "pets");

    const pet = maakHuisdier("", name, type, imageUrl);

    const docRef = await addDoc(petsRef, pet);

    await updateDoc(docRef, {
        id: docRef.id,
    });
}

export async function updatePet(userId: string, pet: Pet) {
    await updateDoc(doc(db, "users", userId, "pets", pet.id), {
        ...pet,
        updatedAt: Date.now(),
    });
}