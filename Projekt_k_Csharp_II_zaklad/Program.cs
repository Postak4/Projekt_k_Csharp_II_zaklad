namespace Projekt_k_Csharp_II_zaklad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ------------------------
            | Evidence Pojištěných |
            ------------------------
            */
            // Nastaví velikost okna dynamicky (šířka, výška) s vyjímkou pro kompatibilitu
            try
            { 
                Console.SetWindowSize(Math.Min(Console.LargestWindowWidth, 100), Math.Min(Console.LargestWindowHeight, 40));
            }
            catch 
            {
                Console.WriteLine("Nelze měnit velikost konzole.");
            }

            // instance menu
            SpravcePojistencu spravce = new();

            MenuPojistenych menu = new MenuPojistenych(spravce);

            menu.SpustitMenu();

            Console.ReadKey();
        }
    }
}
