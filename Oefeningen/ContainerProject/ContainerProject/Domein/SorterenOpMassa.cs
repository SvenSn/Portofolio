namespace ContainerProject.Domein
{
    public class SorterenOpMassa : IComparer<Container>
    {
        public int Compare(Container x, Container y)
        {
            if (x == null || y == null) return 0;
            return x.Massa.CompareTo(y.Massa);
        }
    }
}
