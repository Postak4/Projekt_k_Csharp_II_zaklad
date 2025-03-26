using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projekt_k_Csharp_II_zaklad
{
    /// <summary>
    /// Menu pojištěných, interakce s uživatelem a validace
    /// </summary>
    class MenuPojistenych
    {
        private readonly SpravcePojistencu spravce;

        /// <summary>
        /// Konstruktor umožňuje předat instanci SpravcePojistencu při vytvoření
        /// MenuPojistenych.
        /// </summary>
        public MenuPojistenych(SpravcePojistencu spravcePojistencu)
        {
            // ArgumentNullException zajistí, že při předání null se vyvolá vyjímka
            spravce = spravcePojistencu ?? throw new ArgumentNullException(nameof(spravcePojistencu));
        }

        /// <summary>
        /// Vykreslí hlavičku aplikace
        /// </summary>
        private void VykresliHlavicku()
        {
            DateTime datum = DateTime.Now;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
           ------------------------
           | Evidence Pojištěných |
           ------------------------");

            Console.WriteLine("\nVítejte v evidenci Pojištěných!");
            Console.WriteLine("Dnes je: {0} {1}", datum.ToString("dddd", new CultureInfo("cs-CZ")), DateTime.Now);
            Console.WriteLine("*************************************");
            Console.ResetColor();
        }

        /// <summary>
        /// Vykreslí hlavní menu
        /// </summary>
        private void VykresliHlavniMenu()
        {
            Console.WriteLine("\n < HLAVNÍ MENU EVIDENCE POJIŠTĚNÝCH > ");
            Console.WriteLine("**************************************");
            Console.WriteLine("1 - Přidat nového pojištěnce");
            Console.WriteLine("2 - Zobrazit všechny pojištěnce");
            Console.WriteLine("3 - Vyhledat konkrétního pojištěnce");
            Console.WriteLine("4 - Konec");
            Console.WriteLine("**************************************");
            Console.WriteLine("Vyberte akci (1-4):\n");
        }

        /// <summary>
        /// Metoda která pustí menu pro výběr akce
        /// </summary>
        public void SpustitMenu()
        {
            bool pokracovat = true;

            while (pokracovat)
            {
                VykresliHlavicku();
                VykresliHlavniMenu();

                char volba = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (volba)
                {
                    case '1':
                        PridatPojistence();
                        break;
                    case '2':
                        ZobrazitVsechnyPojistence();
                        break;
                    case '3':
                        VyhledatPojistence();
                        break;
                    case '4':
                        Console.WriteLine("\nUkončuji program...");
                        pokracovat = false;     // ukončí smyčku
                        break;
                    default:
                        Console.WriteLine("\nNeplatná volba, zkuste to znovu.");
                        break;
                }

                if (pokracovat)     // Aby se zobrazila výzva jen pokud program stále běží
                {
                    Console.WriteLine("\nStiskněte libovolnou klávesu pro návrat do menu...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Metoda přidává pojištěnce a komunikuje s uživatelem.
        /// </summary>
        private void PridatPojistence()
        {
            string[] atributy = { "jméno", "přijmení", "věk", "telefonní číslo (+420123456789)" };
            string[] vstupniHodnoty = new string[atributy.Length];

            bool platnyVstup = false;   // kontrolní proměnná pro ukončení cyklu

            while (!platnyVstup)
            {
                VykresliHlavicku();
                VykresliHlavniMenu();

                Console.WriteLine(" < PŘIDAT POJIŠTĚNCE > ");
                Console.WriteLine("**************************************");
                Console.WriteLine("(Zadejte 'X' pro návrat do hlavního menu)\n");

                // iterace přes atributy
                for (int i = 0; i < atributy.Length; i++)
                {
                    Console.Write($"Zadejte {atributy[i]}: ");
                    vstupniHodnoty[i] = Console.ReadLine().Trim();

                    // Pokud uživatel zadá 'X', ukončíme zadávání a vrátíme se do menu
                    if (vstupniHodnoty[i].Trim().Equals("X", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nNávrat do hlavního menu...");
                        return; 
                    }
                }

                // Validace vstupů (ověříme jméno, příjmení, vek a telefon)
                platnyVstup = ValidujVstupy(vstupniHodnoty[0], "jmeno")
                                &&
                               ValidujVstupy(vstupniHodnoty[1], "prijmeni")
                                &&
                               ValidujVstupy(vstupniHodnoty[2], "vek")
                                &&
                               ValidujVstupy(vstupniHodnoty[3], "telefon");

                if (!platnyVstup && !ZnovuNeboZpet())     // Pokud jsou všechny vstupy platné, ukončíme smyčku

                    return;
            }

            // vytvoření instance pojištěnce
            Pojistenec novyPojistenec = new Pojistenec(vstupniHodnoty[0], vstupniHodnoty[1], int.Parse(vstupniHodnoty[2]), vstupniHodnoty[3]);

            // přidání pojištěnce do správce
            spravce.PridatPojistence(novyPojistenec);

            Console.WriteLine("\nPojištěnec úspěšně přidán!");
            Console.ReadKey();
        }


        /// <summary>
        /// Metoda slouží pro validaci vstupů
        /// </summary>
        /// <param name="vstupy">Pole vstupních hodnot</param>
        /// <param name="typValidace">Určuje typ validace ("vek", "telefon", "prijmeni", "jmeno")</param>
        /// <returns>Vrací true, pokud je vstup v pořádku</returns>
        private bool ValidujVstupy(string vstup, string typValidace)
        {
            // ověření zda nejsou řetězce prázdné
            if (string.IsNullOrWhiteSpace(vstup))
            {
                Console.WriteLine("\nVstupy nesmí být prázdné!");
                return false;
            }

            // Validace přijmení a jména - \p{L} - jakékoli písmeno včetně diakritiky, délka min 3 znaky
            if ((typValidace == "jmeno" ||  typValidace == "prijmeni")
                 &&
                !System.Text.RegularExpressions.Regex.IsMatch(vstup, @"^\p{L}{2,}$"))
            {
                Console.WriteLine($"\n{(typValidace == "jmeno" ? "Jméno" : "Přijmení")} musí obsahovat pouze písmena o délce slespoň 2 znaky!");
                return false;
            }

            // kontrola věku nad 18 let (plnoletý) a do 120 let (nejstarší člověk má 112 let ;-))
            if (typValidace == "vek" && (!int.TryParse(vstup, out int vek) || vek < 18 || vek > 120))
            {
                Console.WriteLine("\nVěk musí být číslo mezi 18 a 120 lety!");
                return false;
            }

            // validace telefonního čísla (+420123456789, 00420123456789, 49123456789, 123456789)
            // bez mezer, pomlček a písmen - (\+|00)? může obahovat +420 nebo 00420; \d{9,15} - 9-15 číslic
            if (typValidace == "telefon" && !System.Text.RegularExpressions.Regex.IsMatch(vstup, @"^(\+|00)?\d{9,15}$"))
            {
                Console.WriteLine("\nTelefonní číslo není v platném formátu!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metoda pro zobrazení všech pojíštěnců
        /// </summary>
        private void ZobrazitVsechnyPojistence()
        {
            VykresliHlavicku();
            VykresliHlavniMenu();

            Console.WriteLine(" < SEZNAM POJIŠTĚNCŮ > ");
            Console.WriteLine("**************************************\n");

            List<Pojistenec> pojistenci = spravce.ZiskatVsechnyPojistence();

            if (pojistenci.Count == 0)
            {
                Console.WriteLine("\nŽádní pojištěnci nejsou evidovaní...");
            }
            else
            {
                Console.WriteLine("| Jméno           | Příjmení        | Věk     | Telefon         |");
                Console.WriteLine("-----------------------------------------------------------------");
                foreach (var p in pojistenci)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            
            Console.ReadKey();
        }

        /// <summary>
        /// Metoda hledající pojištěnce podle jména a přijmení
        /// </summary>
        private void VyhledatPojistence()
        {
            bool pokracovat = true;

            while (pokracovat)
            {
                VykresliHlavicku();
                VykresliHlavniMenu();

                Console.WriteLine(" < Vyhledat pojištěnce > ");
                Console.WriteLine("**************************************");
                Console.WriteLine("1 - Vyhledat podle jména a příjmení");
                Console.WriteLine("2 - Vyhledat podle příjmení");
                Console.WriteLine("3 - Vyhledat podle telefonu");
                Console.WriteLine("4 - Návrat do menu");
                Console.WriteLine("______________________________________");
                Console.WriteLine("\nVyberte možnost (1-4):");

                char volba = Console.ReadKey().KeyChar;
                Console.WriteLine();

                string[] atributy = { "jméno", "přijmení", "telefon" };
                string[] vstupniHodnoty = new string[atributy.Length];

                List<Pojistenec> nalezeniPojistenci = new List<Pojistenec>();

                switch (volba)
                {
                    case '1': // Vyhledávání podle jména a příjmení
                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine($"Zadejte {atributy[i]}: ");
                            vstupniHodnoty[i] = Console.ReadLine().Trim();
                        }

                        if (!ValidujVstupy(vstupniHodnoty[0], "jmeno") 
                             ||
                            !ValidujVstupy(vstupniHodnoty[1], "prijmeni"))
                        {
                            if (!ZnovuNeboZpet()) return;
                            continue;
                        }

                        nalezeniPojistenci = spravce.VyhledatPojistence(vstupniHodnoty[0], vstupniHodnoty[1]);
                        break;

                    case '2': // Vyhledání podle přijmení
                        Console.WriteLine($"Zadejte {atributy[1]}: ");
                        vstupniHodnoty[1] = Console.ReadLine().Trim();

                        if (!ValidujVstupy(vstupniHodnoty[1], "prijmeni"))
                        {
                            if (!ZnovuNeboZpet()) return;
                            continue;
                        }

                        nalezeniPojistenci = spravce.VyhledatPodlePrijmeni(vstupniHodnoty[1]);
                        break;

                    case '3': // Vyhledávání podle telefonu
                        Console.WriteLine($"Zadejte {atributy[2]}: ");
                        vstupniHodnoty[2] = Console.ReadLine().Trim();

                        if (!ValidujVstupy(vstupniHodnoty[2], "telefon"))
                        {
                            if (!ZnovuNeboZpet()) return;
                            continue;
                        }

                        nalezeniPojistenci = spravce.VyhledatPodleTelefonu(vstupniHodnoty[2]);
                        break;

                    case '4': // Ukončení vyhledávání
                        return;

                    default:
                        Console.WriteLine("\nNeplatná volba! Zkuste to znovu.");
                        Console.ReadKey();
                        continue;
                }

                // Výpis výsledků hledání
                VykresliVysledkyHledani(nalezeniPojistenci);
            }
        }

        /// <summary>
        /// Vykreslí výsledky hledání pojištěnců
        /// </summary>
        private void VykresliVysledkyHledani(List<Pojistenec> pojistenci)
        {
            Console.Clear();
            Console.WriteLine("\n < VÝSLEDKY HLEDÁNÍ > ");
            Console.WriteLine("**************************************\n");

            if (pojistenci.Count > 0)
            {
                Console.WriteLine("| Jméno           | Příjmení        | Věk     | Telefon         |");
                Console.WriteLine("-----------------------------------------------------------------");
                foreach (var p in pojistenci)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nŽádný pojištěnec nebyl nalezen.");
            }

            Console.WriteLine("\nStiskněte libovolnou klávesu pro návrat do vyhledávání nebo 'X' pro návrat do menu...");
            if (Console.ReadKey().Key == ConsoleKey.X)
            {
                Console.WriteLine("\nNávrat do hlavního menu...");
                return;
            }
        }

        /// <summary>
        /// Zobrazí výzvu při neplatném vstupu a čeká na stisk klávesy.
        /// Vrací false, pokud uživatel stiskne X (návrat do menu),
        /// jinak vrací true (opakování zadávání).
        /// </summary>
        /// <returns>True pokud chce uživatel opakovat, False pokud se vrátí do menu</returns>
        private bool ZnovuNeboZpet()
        {
            Console.WriteLine("\nNeplatný vstup!");
            Console.WriteLine("Stiskněte 'X' pro návrat do menu, nebo libovolnou klávesu pro opakování...");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.X)
            {
                Console.WriteLine("\nNávrat do hlavního menu...");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
