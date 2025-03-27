##########################################################
##  Evidence pojištìných – C# .NET 8 konzolová aplikace ##
##########################################################

Tato aplikace slouží pro **evidenci pojištìných osob**. Byla vytvoøena jako výukový projekt v jazyce C# s využitím dobrých programátorských praktik a objektovì orientovaného návrhu.

---

##  Funkce aplikace

- Pøidání nového pojištìnce (jméno, pøíjmení, vìk, telefon)
- Zobrazení všech pojištìncù
- Vyhledání pojištìnce:
  - podle jména a pøíjmení
  - podle pøíjmení
  - podle telefonního èísla
- Validace vstupù (napø. prázdné jméno, neplatný vìk, formát telefonu)
- Uživatelské menu v èeském jazyce

---

##  Technologie

- C# 12
- .NET 8.0 (konzolová aplikace)
- Visual Studio 2022

---

##  Jak aplikaci spustit

1. Otevøi øešení v **Visual Studiu 2022**.
2. Stiskni **F5** pro spuštìní aplikace s ladìním nebo **Ctrl + F5** pro bìžné spuštìní.

---

##  Struktura kódu

- `Program.cs` – hlavní vstupní bod aplikace
- `Pojistenec.cs` – datová tøída reprezentující jednoho pojištìnce
- `SpravcePojistencu.cs` – tøída pro správu kolekce pojištìncù (pøidávání, vyhledávání, získání všech)
- `MenuPojistenych.cs` – interakce s uživatelem, zobrazení menu, validace vstupù

---

##  Dobré praktiky

Aplikace dodržuje:
- **SRP (Single Responsibility Principle)** – každá tøída má jasnì daný úèel
- **Separation of Concerns** – logika dat a komunikace s uživatelem jsou oddìleny
- **DRY (Don't Repeat Yourself)** – opakovaný kód je refaktorován do metod
- **Validace vstupù** – napø. kontrola prázdných polí, èísel a formátu telefonu

---

##  Omezení

- Data se ukládají pouze v pamìti (bìhem bìhu programu)
- Není implementována editace nebo mazání záznamù
- Po zavøení programu se data ztrácí

---

##  Autor

Patrik Kindl   
Projekt vytvoøen jako souèást výuky kurzu programování webových aplikací v C#.NET 

---

##  Ukázka výstupu:


           ------------------------
           | Evidence Pojištìných |
           ------------------------

Vítejte v evidenci Pojištìných!
Dnes je: ètvrtek 27.03.2025 13:54:50
*************************************

 < HLAVNÍ MENU EVIDENCE POJIŠTÌNÝCH >
**************************************
1 - Pøidat nového pojištìnce
2 - Zobrazit všechny pojištìnce
3 - Vyhledat konkrétního pojištìnce
4 - Konec
**************************************
Vyberte akci (1-4):

