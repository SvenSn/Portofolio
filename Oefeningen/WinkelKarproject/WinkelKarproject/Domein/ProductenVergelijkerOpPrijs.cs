namespace WinkelKarproject.Domein
{
    internal class ProductenVergelijkerOpPrijs : IComparer<Product>
    {
        public int Compare(Product o1, Product o2)
        {
            return (int)(o2.GeefPrijsZonderKorting() - o1.GeefPrijsZonderKorting());
        }

    }
}
