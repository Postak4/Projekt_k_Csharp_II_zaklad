using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_k_Csharp_II_zaklad
{
    /// <summary>
    /// Třída Pojištěnec - všechny vlastnosti jsou jen pro čtení {get;} hodnoty se nastavují jen v kontruktoru
    /// </summary>
    class Pojistenec
    {
        public string Jmeno { get; }
        public string Prijmeni { get; }
        public int Vek { get; }
        public string Telefon { get; }

        /// <summary>
        /// Konstruktor třídy Pojištěnec
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefon"></param>
        public Pojistenec(string jmeno, string prijmeni, int vek, string telefon)
        { 
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        /// <summary>
        /// Vypsání třídy Pojištěnec - Formátuje jméno a přijmení, první písmeno velké ostatní malá.
        /// Zarovnání pomocí string (interpolation) a šířky sloupců s rezervací na 15 mezer. Ošetření
        /// prázdných řetězců pomocí string.IsNullOrWhiteSpace()
        /// </summary>
        /// <returns>Vrací Jméno, Přijmení, Věk, Telefon</returns>
        public override string ToString()
        {
            // {Jmeno.Substring(0,1).ToUpper()}{Jmeno.Substring(1).ToLower()} - my selhaval při prázdném řetězci
            // použito: char.ToUpper() + Substring().. {Jmeno, -15} => -15 znamená zarovnání doleva s rezervací 15 mezer za jmenem
            string jmenoFormat = string.IsNullOrWhiteSpace(Jmeno) ? "" : char.ToUpper(Jmeno[0]) + Jmeno.Substring(1).ToLower();
            string prijmeniFormat = string.IsNullOrWhiteSpace(Prijmeni) ? "" : char.ToUpper(Prijmeni[0]) + Prijmeni.Substring(1).ToLower();
            
            return $"| {jmenoFormat, -15} | {prijmeniFormat, -15} | {Vek, 3} let | {Telefon, 15} |";
        }
    }
}
