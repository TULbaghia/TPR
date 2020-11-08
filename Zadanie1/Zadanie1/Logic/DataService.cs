using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Klient
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

        #endregion

        #region Ksiazka
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

        #endregion

        #region Stan
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
        public void UpdateStan(int id, Ksiazka ksiazka, string opis, bool czyWypozyczona, DateTime dataZakupu)
        {
            IData.UpdateStan(id, ksiazka, opis, czyWypozyczona, dataZakupu);
        }
        public void DeleteStan(Stan stan)
        {
            IData.DeleteStan(stan);
        }

        #endregion

        #region Zdarzenie
        public Zdarzenie GetZdarzenie(int id)
        {
            return IData.GetZdarzenie(id);
        }
        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return IData.GetAllZdarzenie();
        }
        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            IData.DeleteZdarzenie(zdarzenie);
        }

        #endregion

        #region Filters
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

        public IEnumerable<Zdarzenie> GetAllZdarzeniaDlaStanu(Stan stan)
        {
            List<Zdarzenie> result = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Stan == stan)
                    result.Add(zdarzenie);
            }
            return result;
        }
        public IEnumerable<Stan> GetAllStanyDlaKsiazki(Ksiazka ksiazka)
        {
            List<Stan> result = new List<Stan>();
            foreach (Stan stan in IData.GetAllStan())
            {
                if (stan.Ksiazka.Equals(ksiazka))
                {
                    result.Add(stan);
                }
            }
            return result;
        }


        public IEnumerable<Zdarzenie> GetAllZdarzeniaPomiedzyDatami(DateTime startTime, DateTime endTime)
        {
            List<Zdarzenie> zdarzenia = new List<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.Data.CompareTo(startTime) >= 0 && zdarzenie.Data.CompareTo(endTime) <= 0)
                {
                    zdarzenia.Add(zdarzenie);
                }
            }
            return zdarzenia;
        }
        #endregion

        #region Wypozyczanie/Zwrot
        public void WypozyczKsiazke(Klient klient, Stan stan)
        {
            if (!stan.CzyWypozyczona)
            {
                int index = IData.GetAllStan().ToList<Stan>().FindIndex(s => s == stan);
                IData.UpdateStan(index, stan.Ksiazka, "Egzemplarz wypożyczony", true, DateTime.Now);
                IData.AddZdarzenie(new Wypozyczenie(klient, stan));
                return;
            }
            throw new ArgumentException("Aktualnie nie można wypożyczyć tej książki.");
        }

        public void ZwrocKsiazke(Klient klient, Stan stan)
        {
            Klient ktoWypozyczyl = IData.GetAllZdarzenie().ToList().Find(x => x.Stan == stan).Klient;

            if (stan.CzyWypozyczona && ktoWypozyczyl == klient)
            {
                int index = IData.GetAllStan().ToList<Stan>().FindIndex(s => s == stan);
                IData.UpdateStan(index, stan.Ksiazka, "Egzemplarz dostępny", false, DateTime.Now);
                IData.AddZdarzenie(new Zwrot(klient, stan));
                return;
            }
            throw new ArgumentException("Aktualnie nie można zwrócić tej książki.");
        }
        #endregion

        #region Wyszukaj
        public IEnumerable<Ksiazka> FindInKsiazki(string query)
        {
            List<Ksiazka> result = new List<Ksiazka>();
            foreach (Ksiazka ksiazka in IData.GetAllKsiazka())
            {
                if (ksiazka.ToString().Contains(query))
                {
                    result.Add(ksiazka);
                }
            }
            return result;
        }

        public IEnumerable<Stan> FindInStany(string query)
        {
            List<Stan> result = new List<Stan>();
            foreach (Stan stan in IData.GetAllStan())
            {
                if (stan.ToString().Contains(query))
                {
                    result.Add(stan);
                }
            }
            return result;
        }
        public IEnumerable<Klient> FindInKlienci(string query)
        {
            List<Klient> result = new List<Klient>();
            foreach (Klient klient in IData.GetAllKlient())
            {
                if (klient.ToString().Contains(query))
                {
                    result.Add(klient);
                }
            }
            return result;
        }

        public IEnumerable<Zdarzenie> FindInZdarzenia(string query)
        {
            List<Zdarzenie> result = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in IData.GetAllZdarzenie())
            {
                if (zdarzenie.ToString().Contains(query))
                {
                    result.Add(zdarzenie);
                }
            }
            return result;
        }
        #endregion
    }
}
