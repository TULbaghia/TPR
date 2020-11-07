using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie1.Data
{
    public class DataRepository : IDataRepository
    {
        public DataContext DataContext { get; private set; }
        public DataRepository(IDataFiller dataFiller, DataContext dataContext)
        {
            DataContext = dataContext;
            dataFiller.Fill(DataContext);
        }

        #region Ksiazka

        public void AddKsiazka(Ksiazka ksiazka)
        {
            if (DataContext.Ksiazki.ContainsValue(ksiazka))
            {
                throw new Exception("Taka ksiazka juz istnieje");
            }
            int id = DataContext.Ksiazki.Keys.Count() == 0 ? 0 : DataContext.Ksiazki.Keys.Max()+1;
            DataContext.Ksiazki.Add(id, ksiazka);
            ksiazka.Id = id;
        }

        public Ksiazka GetKsiazka(int id)
        {
            if(DataContext.Ksiazki.ContainsKey(id))
            {
                return DataContext.Ksiazki[id];
            }
            throw new KeyNotFoundException("Ksiazka o takim id nie istnieje");
        }

        public IEnumerable<Ksiazka> GetAllKsiazka()
        {
            return DataContext.Ksiazki.Values;
        }

        public void UpdateKsiazka(int id, Ksiazka ksiazka)
        {
            if (DataContext.Ksiazki.ContainsValue(ksiazka))
            {
                throw new Exception("Taka ksiazka juz istnieje");
            }
            Ksiazka old = GetKsiazka(id);
            old.Autor = ksiazka.Autor;
            old.Tytul = ksiazka.Tytul;
        }

        public void DeleteKsiazka(Ksiazka ksiazka)
        {
            foreach (Stan stan in DataContext.Stany)
            {
                if (stan.Ksiazka == ksiazka)
                {
                    throw new Exception("Nie mozna usunac ksiazki posiadajacej stan");
                }
            }
            foreach (KeyValuePair<int, Ksiazka> k in DataContext.Ksiazki)
            {
                if (k.Value == ksiazka)
                {
                    DataContext.Ksiazki.Remove(k.Key);
                    return;
                }
            }
        }

        #endregion

        #region Stan

        public void AddStan(Stan stan)
        {
            DataContext.Stany.Add(stan);
        }

        public Stan GetStan(int id)
        {
            if (DataContext.Stany.ElementAtOrDefault(id) != null)
            {
                return DataContext.Stany[id];
            }
            throw new KeyNotFoundException("Stan o takim id nie istnieje");
        }

        public IEnumerable<Stan> GetAllStan()
        {
            return DataContext.Stany;
        }

        public void UpdateStan(int id, Stan stan)
        {
            Stan old = GetStan(id);
            if(stan.Ilosc < 0)
            {
                throw new Exception("Stan posiada nieprawidlowa ilosc");
            }
            old.Ksiazka = stan.Ksiazka;
            old.Opis = stan.Opis;
            old.Ilosc = stan.Ilosc;
            old.DataZakupu = stan.DataZakupu;
        }

        public void DeleteStan(Stan stan)
        {
            foreach (Zdarzenie z in DataContext.Zdarzenia)
            {
                if(z.Stan == stan)
                {
                    throw new Exception("Nie mozna usunac stanu posiadajacego zdarzenie");
                }
            }
            int index = 0;
            foreach (Stan s in DataContext.Stany)
            {
                if (s == stan)
                {
                    DataContext.Stany.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        #endregion

        #region Klient

        public void AddKlient(Klient klient)
        {
            DataContext.Klienci.Add(klient);
        }

        public Klient GetKlient(int id)
        {
            if (DataContext.Klienci.ElementAtOrDefault(id) != null)
            {
                return DataContext.Klienci[id];
            }
            throw new KeyNotFoundException("Klient o takim id nie istnieje");
        }

        public IEnumerable<Klient> GetAllKlient()
        {
            return DataContext.Klienci;
        }

        public void UpdateKlient(int id, Klient klient)
        {
            Klient oldKlient = GetKlient(id);
            oldKlient.Imie = klient.Imie;
            oldKlient.Nazwisko = klient.Nazwisko;
        }

        public void DeleteKlient(Klient klient)
        {
            foreach (Zdarzenie zdarzenie in DataContext.Zdarzenia)
            {
                if (zdarzenie.Klient == klient)
                {
                    throw new Exception("Nie mozna usunac klienta posiadajacego zdarzenie");
                }
            }
            int index = 0;
            foreach(Klient k in DataContext.Klienci)
            {
                if(k == klient)
                {
                    DataContext.Klienci.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        #endregion

        #region Zdarzenie

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            DataContext.Zdarzenia.Add(zdarzenie);
        }

        public Zdarzenie GetZdarzenie(int id)
        {
            if (DataContext.Zdarzenia.ElementAtOrDefault(id) != null)
            {
                return DataContext.Zdarzenia[id];
            }
            throw new KeyNotFoundException("Zdarzenie o takim id nie istnieje");
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return DataContext.Zdarzenia;
        }

        public void UpdateZdarzenie(int id, Zdarzenie zdarzenie)
        {
            GetZdarzenie(id);
            DataContext.Zdarzenia.RemoveAt(id);
            DataContext.Zdarzenia.Insert(id, zdarzenie);
        }

        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            int index = 0;
            foreach (Zdarzenie z in DataContext.Zdarzenia)
            {
                if (z == zdarzenie)
                {
                    DataContext.Zdarzenia.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        #endregion
    }
}
