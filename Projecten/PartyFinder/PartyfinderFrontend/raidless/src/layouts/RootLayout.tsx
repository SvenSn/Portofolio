
import Header from "../components/Header";
import Footer from "../components/Footer";
import { Outlet } from "react-router-dom";

const RootLayout = () => {
    return (
        <div className="min-h-screen flex flex-col">
            <Header />
            <div className="flex grow  justify-center items-center  bg-linear-to-r from-blue-950 to-amber-900">
                <Outlet />
            </div>
            <Footer />
        </div>
    );
};

export default RootLayout;