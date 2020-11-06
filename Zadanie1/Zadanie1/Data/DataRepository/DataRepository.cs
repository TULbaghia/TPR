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

        // -=-=-=-=-

        public void AddKsiazka(Ksiazka ksiazka)
        {
            int id = DataContext.Ksiazki.Keys.Count() == 0 ? 0 : DataContext.Ksiazki.Keys.Max()+1;
            DataContext.Ksiazki.Add(id, ksiazka);
        }

        public Ksiazka GetKsiazka(int id)
        {
            if(DataContext.Ksiazki.ContainsKey(id))
            {
                return DataContext.Ksiazki[id];
            }
            throw new KeyNotFoundException();
        }

        public IEnumerable<Ksiazka> GetAllKsiazka()
        {
            return DataContext.Ksiazki.Values;
        }

        public void UpdateKsiazka(int id, Ksiazka ksiazka)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteKsiazka(Ksiazka ksiazka)
        {
            
            foreach (KeyValuePair<int, Ksiazka> k in DataContext.Ksiazki)
            {
                if(k.Value == ksiazka)
                {
                    DataContext.Ksiazki.Remove(k.Key);
                    break;
                }
            }
        }

        // -=-=-=-=-

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
            throw new KeyNotFoundException();
        }

        public IEnumerable<Stan> GetAllStan()
        {
            return DataContext.Stany;
        }

        public void UpdateStan(int id, Stan stan)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStan(Stan stan)
        {
            DataContext.Stany.Remove(stan);
        }

        // -=-=-=-=-

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
            throw new KeyNotFoundException();
        }

        public IEnumerable<Klient> GetAllKlient()
        {
            return DataContext.Klienci;
        }

        public void UpdateKlient(int id, Stan stan)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteKlient(Klient klient)
        {
            DataContext.Klienci.Remove(klient);
        }

        // -=-=-=-=-

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
            throw new KeyNotFoundException();
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return DataContext.Zdarzenia;
        }

        public void UpdateZdarzenie(int id, Zdarzenie zdarzenie)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            DataContext.Zdarzenia.Remove(zdarzenie);
        }
    }
}
