import { useSelector } from "react-redux";
import { selectActivePet } from "../store/pets/petSlice";


export const useActivePet = () => useSelector(selectActivePet);