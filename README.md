##########################################################
##  Evidence poji�t�n�ch � C# .NET 8 konzolov� aplikace ##
##########################################################

Tato aplikace slou�� pro **evidenci poji�t�n�ch osob**. Byla vytvo�ena jako v�ukov� projekt v jazyce C# s vyu�it�m dobr�ch program�torsk�ch praktik a objektov� orientovan�ho n�vrhu.

---

##  Funkce aplikace

- P�id�n� nov�ho poji�t�nce (jm�no, p��jmen�, v�k, telefon)
- Zobrazen� v�ech poji�t�nc�
- Vyhled�n� poji�t�nce:
  - podle jm�na a p��jmen�
  - podle p��jmen�
  - podle telefonn�ho ��sla
- Validace vstup� (nap�. pr�zdn� jm�no, neplatn� v�k, form�t telefonu)
- U�ivatelsk� menu v �esk�m jazyce

---

##  Technologie

- C# 12
- .NET 8.0 (konzolov� aplikace)
- Visual Studio 2022

---

##  Jak aplikaci spustit

1. Otev�i �e�en� v **Visual Studiu 2022**.
2. Stiskni **F5** pro spu�t�n� aplikace s lad�n�m nebo **Ctrl + F5** pro b�n� spu�t�n�.

---

##  Struktura k�du

- `Program.cs` � hlavn� vstupn� bod aplikace
- `Pojistenec.cs` � datov� t��da reprezentuj�c� jednoho poji�t�nce
- `SpravcePojistencu.cs` � t��da pro spr�vu kolekce poji�t�nc� (p�id�v�n�, vyhled�v�n�, z�sk�n� v�ech)
- `MenuPojistenych.cs` � interakce s u�ivatelem, zobrazen� menu, validace vstup�

---

##  Dobr� praktiky

Aplikace dodr�uje:
- **SRP (Single Responsibility Principle)** � ka�d� t��da m� jasn� dan� ��el
- **Separation of Concerns** � logika dat a komunikace s u�ivatelem jsou odd�leny
- **DRY (Don't Repeat Yourself)** � opakovan� k�d je refaktorov�n do metod
- **Validace vstup�** � nap�. kontrola pr�zdn�ch pol�, ��sel a form�tu telefonu

---

##  Omezen�

- Data se ukl�daj� pouze v pam�ti (b�hem b�hu programu)
- Nen� implementov�na editace nebo maz�n� z�znam�
- Po zav�en� programu se data ztr�c�

---

##  Autor

Patrik Kindl   
Projekt vytvo�en jako sou��st v�uky kurzu programov�n� webov�ch aplikac� v C#.NET 

---

##  Uk�zka v�stupu:


           ------------------------
           | Evidence Poji�t�n�ch |
           ------------------------

V�tejte v evidenci Poji�t�n�ch!
Dnes je: �tvrtek 27.03.2025 13:54:50
*************************************

 < HLAVN� MENU EVIDENCE POJI�T�N�CH >
**************************************
1 - P�idat nov�ho poji�t�nce
2 - Zobrazit v�echny poji�t�nce
3 - Vyhledat konkr�tn�ho poji�t�nce
4 - Konec
**************************************
Vyberte akci (1-4):

