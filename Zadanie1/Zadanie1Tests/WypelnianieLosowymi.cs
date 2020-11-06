using System;
using System.Text;
using Zadanie1.Data;

namespace Zadanie1Tests
{
    public class WypelnianieLosowymi : IDataFiller
    {
        Random rand = new Random();

        public void Fill(DataContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Klienci.Add(new Klient(RandString(rand.Next(5, 10)), RandString(rand.Next(5, 10))));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Ksiazki.Add(i, new Ksiazka(RandString(rand.Next(5, 10)), RandString(rand.Next(5, 10))));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Stany.Add(new Stan(context.Ksiazki[i], RandString(rand.Next(5, 10)), rand.Next(1, 10), 
                    new DateTime(rand.Next(2017, 2020), rand.Next(1, 12), rand.Next(1, 27), rand.Next(8, 18), rand.Next(1, 55), rand.Next(1, 55))));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Wypozyczenie(context.Klienci[i], context.Stany[i],
                    new DateTime(rand.Next(2017, 2020), rand.Next(1, 12), rand.Next(1, 27), rand.Next(8, 18), rand.Next(1, 55), rand.Next(1, 55))));
            }

            for (int i = 0; i < 10; i++)
            {
                context.Zdarzenia.Add(new Zwrot(context.Klienci[i], context.Stany[i],
                    new DateTime(rand.Next(2017, 2020), rand.Next(1, 12), rand.Next(1, 27), rand.Next(8, 18), rand.Next(1, 55), rand.Next(1, 55))));
            }

        }
        private string RandString(int length)
        {
            string availableChars = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder randString = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                randString.Append(availableChars[rand.Next(availableChars.Length)]);
            }

            return randString.ToString();
        }
    }
}
