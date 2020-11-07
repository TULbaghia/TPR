using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Zadanie1.Data;

namespace Zadanie1.Logic
{
    public class DataService
    {
        public DataService(IDataRepository iData)
        {
            IData = iData;
        }

        public IDataRepository IData { get; set; }

        // -=-=-=-=-

        public void AddKlient(Klient klient)
        {
            IData.AddKlient(klient);
        }
        public Klient GetKlient(int id)
        {
            return IData.GetKlient(id);
        }
        public IEnumerable<Klient> GetAllKlient()
        {
            return IData.GetAllKlient();
        }
        public void UpdateKlient(int id, string imie, string nazwisko)
        {
            IData.UpdateKlient(id, imie, nazwisko);
        }
        public void DeleteKlient(Klient klient)
        {
            IData.DeleteKlient(klient);
        }

        // -=-=-=-=-

        public void AddKsiazka(Ksiazka ksiazka)
        {
            IData.AddKsiazka(ksiazka);
        }
        public Ksiazka GetKsiazka(int id)
        {
            return IData.GetKsiazka(id);
        }
        public IEnumerable<Ksiazka> GetAllKsiazka()
        {
            return IData.GetAllKsiazka();
        }
        public void UpdateKsiazka(int id, string tytul, string autor)
        {
            IData.UpdateKsiazka(id, tytul, autor);
        }
        public void DeleteKsiazka(Ksiazka ksiazka)
        {
            IData.DeleteKsiazka(ksiazka);
        }

        // -=-=-=-=-

        public void AddStan(Stan stan)
        {
            IData.AddStan(stan);
        }
        public Stan GetStan(int id)
        {
            return IData.GetStan(id);
        }
        public IEnumerable<Stan> GetAllStan()
        {
            return IData.GetAllStan();
        }
        public void UpdateStan(Ksiazka ksiazka, string opis, int ilosc, DateTime dataZakupu)
        {
            IData.UpdateStan(ksiazka, opis, ilosc, dataZakupu);
        }
        public void DeleteStan(Stan stan)
        {
            IData.DeleteStan(stan);
        }

        // -=-=-=-=-

        public Zdarzenie GetZdarzenie(int id)
        {
            return IData.GetZdarzenie(id);
        }
        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return IData.GetAllZdarzenie();
        }
        public void UpdateZdarzenie()
        {
            //
        }
        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            IData.DeleteZdarzenie(zdarzenie);
        }

        // -=-=-=-=-

        public IEnumerable<Zdarzenie> GetAllZdarzeniaDlaKsiazki(Ksiazka ksiazka)
        {
            List<Zdarzenie> result = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Stan.Ksiazka.Equals(ksiazka))
                    result.Add(zdarzenie);
            }
            return result;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzeniaDlaKlienta(Klient klient)
        {
            List<Zdarzenie> result = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Klient.Equals(klient))
                    result.Add(zdarzenie);
            }
            return result;
        }


        public IEnumerable<Zdarzenie> GetAllZdarzeniaPomiedzyDatami(DateTime startTime, DateTime endTime)
        {
            List<Zdarzenie> zdarzenia = new List<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Data.CompareTo(startTime) >= 0 && zdarzenie.Data.CompareTo(endTime) >= 0)
                {
                    zdarzenia.Add(zdarzenie);
                }
            }
            return zdarzenia;
        }

        public void WypozyczKsiazke(Klient klient, Ksiazka ksiazka)
        {
            foreach (Stan stan in IData.GetAllStan())
            {
                if(stan.Ksiazka.Equals(ksiazka) && ((stan.Ilosc - 1) >= 0))
                {
                    IData.UpdateStan(stan.Ksiazka, "Pozostała ilość: " + (stan.Ilosc - 1), stan.Ilosc - 1, DateTime.Now);
                    IData.AddZdarzenie(new Wypozyczenie(klient, stan));
                    return;
                }
            }
            throw new ArgumentException("Aktualnie nie można wypożyczyć tej książki.");
        }

        public void ZwrocKsiazke(Klient klient, Ksiazka ksiazka)
        {
            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Stan.Ksiazka.Equals(ksiazka) &&  zdarzenie.Klient.Equals(klient) && zdarzenie is Wypozyczenie)
                {
                    Stan stan = zdarzenie.Stan;
                    IData.UpdateStan(zdarzenie.Stan.Ksiazka, "Pozostała ilość: " + (zdarzenie.Stan.Ilosc + 1), zdarzenie.Stan.Ilosc + 1, DateTime.Now);
                    IData.AddZdarzenie(new Zwrot(klient, stan));
                    return;
                }
            }
            throw new ArgumentException("Aktualnie nie można zwrócić tej książki.");
        }

    }
}
