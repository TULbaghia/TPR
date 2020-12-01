using ModelClasses.Zadanie1.Data;
using System;

namespace ConsoleApp
{
    class ConstDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Klienci.Add(new Klient("Jan" + i, "Testowy" + i));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Ksiazki.Add(i, new Ksiazka("TestowyTytul" + i, "TestowyAutor" + i));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Stany.Add(new Stan(context.Ksiazki[i], "TestowyOpis" + i, false, new DateTime(2020, 10, i + 1, 13, i + 1, 30)));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Wypozyczenie(context.Klienci[i], context.Stany[i], new DateTime(2020, 11, i + 1, 13, i + 1, 30)));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Zwrot(context.Klienci[i], context.Stany[i], new DateTime(2020, 12, i + 1, 13, i + 1, 30)));
            }
        }
    }
}
