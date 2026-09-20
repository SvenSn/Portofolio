const Footer = () => {
    return (
        <div className="bg-linear-to-r from-blue-950 to-amber-900 text-white py-8 border border-black">
            <div className="max-w-7xl mx-auto px-6">
                <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                    {/* Brand */}
                    <div>
                        <h3 className="text-2xl font-bold text-blue-200 mb-2">Raidless</h3>
                        <p className="text-amber-200 text-sm">experimental</p>
                    </div>

                    {/* Description */}
                    <div className="flex items-center justify-center">
                        <p className="text-amber-100 text-center">A modern party finder experience</p>
                    </div>

                    {/* Copyright */}
                    <div className="flex items-center justify-end">
                        <p className="text-amber-200 text-sm">© 2025 Sven Snoeck</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Footer