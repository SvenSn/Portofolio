using ContainerProject.Domein;
using System.Collections.Immutable;

namespace ContainerProject.CUI
{
    public class ContainerApp
    {
        public void Run()
        {
            List<Container> containers = new List<Container>();

            containers.Add(new Container("Antwerpen", 60, 150, 1234));
            containers.Add(new Container("Rotterdam", 70, 110, 2568));
            containers.Add(new Container("Calais", 80, 90, 8569));
            containers.Add(new Container("Brugge", 70, 100, 8564));


            containers.Sort();
            Console.WriteLine("\nContainers op natuurlijk sorteren: ");
            foreach (Container container in containers)
            {
                Console.WriteLine(container);
            }

            containers.Sort(new SorterenOpMassa());
            Console.WriteLine("\nContainers Massa sorteren: ");
            foreach (Container container in containers)
            {
                Console.WriteLine(container);
            }

            containers.Sort(new SorteerBijEigenaar());
            Console.WriteLine("\nContainers op eigenaar sorteren: ");
            foreach (Container container in containers)
            {
                Console.WriteLine(container);
            }

            Container nieuweContainer = new Container("Antwerpen", 70, 75, 8564);

            // Kijk na of de nieuwe container reeds in de lijst aanwezig is en
            // druk het resultaat af op het scherm.


        }
    }
}
