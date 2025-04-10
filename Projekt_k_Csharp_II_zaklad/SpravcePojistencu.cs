using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_k_Csharp_II_zaklad
{
    /// <summary>
    /// Správce pojištěnců výpis do List<Pojistenec>. Interní datová struktura 
    /// umožňuje přidávat, vyhledávat a získávat pojištěnce. Vyhledání pomocí 
    /// (LINQ) jména + příjmení, nebo přijmení, nebo telefonního čísla, bez ohledu
    /// na velikost písmen (StringComparison.OrdinalIgnoreCase). Vrací se vždy
    /// kopie seznamu, aby se původní seznam nemohl měnit zvenčí.
    /// </summary>
    class SpravcePojistencu
    {
        /// <summary>
        /// Pro jednoduchou implementaci používám List<Pojistenec> jako interní
        /// datovou strukturu. Bez nutnosti indexace je List dostačující. Při 
        /// nárůstu datové struktury, je na zvážení Dictionary, nebo DB. Také 
        /// by volitelně šlo doplnit ukládání/načítání do/ze douboru, nebo DB.
        /// </summary>
        private List<Pojistenec> pojistenci;

        /// <summary>
        /// Inicializuje seznam Pojištěnců
        /// </summary>
        public SpravcePojistencu()
        {
            pojistenci = new List<Pojistenec>();
        }

        /// <summary>
        /// Metoda přidá pojištěnce se seznamu List<>.
        /// </summary>
        /// <param name="pojistenec"></param>
        public void PridatPojistence(Pojistenec pojistenec)
        {
            pojistenci.Add(pojistenec);
        }

        /// <summary>
        /// Metoda získá všechny pojištěnce a vrátí 
        /// </summary>
        /// <returns>Vrátí seznam Pojištěnců</returns>
        public List<Pojistenec> ZiskatVsechnyPojistence()
        {
            return pojistenci;
        }

        /// <summary>
        /// Vyhledá pojištěnce v kolekci pojistenci podle jména a příjmení.
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <returns>Vrátí výsledek jako seznam (List<Pojistenec>)</returns>
        public List<Pojistenec> VyhledatPojistence(string jmeno, string prijmeni)
        {
            // .Where použil jsem metodu Linq filtruje kolekci na základě podmínky.
            // Lambda výraz p => určuje co chci nechat
            // equals porovnává jméno a přijmení bez ohlednu na velikost písmen
            // && oboje musí být současně. Výstup Where je IEnumerable. A ToList() převede na List
            return pojistenci.Where(p => p.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase)
                    &&
                    p.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Vyhledá pojištěnce podle příjmení.
        /// </summary>
        public List<Pojistenec> VyhledatPodlePrijmeni(string prijmeni)
        {
            return pojistenci.Where(p => p.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase))
                             .ToList();
        }

        /// <summary>
        /// Vyhledá pojištěnce podle telefonního čísla.
        /// </summary>
        public List<Pojistenec> VyhledatPodleTelefonu(string telefon)
        {
            return pojistenci.Where(p => p.Telefon.Equals(telefon))
                             .ToList();
        }
    }
}
