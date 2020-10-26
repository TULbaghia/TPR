using System;
using System.Runtime.InteropServices.ComTypes;
using Zadanie1;

namespace Zadanie1Tests
{
    public class WypelnianieStalymi : IDataFiller
    {
        public void Fill(DataContext context)
        {

            for (int i = 0; i < 10; i++)
            {
                context.Klienci.Add(new Klient(i, "Jan" + i, "Testowy" + i));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Ksiazki.Add(i, new Ksiazka(i, "TestowyTytul" + i, "TestowyAutor" + i));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Stany.Add(new Stan(i, context.Ksiazki[i], "Testowy opis" + i, new DateTime(2020, 10, i + 1, 13, i + 1, 30))) ;
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Wypozyczenie(i, context.Klienci[i], context.Stany[i], new DateTime(2020, 11, i + 1, 13, i + 1, 30)));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Zwrot(i, context.Klienci[i], context.Stany[i], new DateTime(2020, 12, i + 1, 13, i + 1, 30)));
            }

        }
    }
}
