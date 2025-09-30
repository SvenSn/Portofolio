namespace ContainerProject.Domein
{
    public class SorteerBijEigenaar : IComparer<Container>
    {
        public int Compare(Container x, Container y)
        {
            if (x == null || y == null) return 0;
            return x.Eigenaar.CompareTo(y.Eigenaar);
        }
    }
}
