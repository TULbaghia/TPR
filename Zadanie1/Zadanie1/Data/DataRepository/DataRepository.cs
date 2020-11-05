using System.Collections.Generic;

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

        // TODO: fix 1
        public void AddKsiazka(Ksiazka ksiazka)
        {
            DataContext.Ksiazki.Add(1, ksiazka);
        }

        public Ksiazka GetKsiazka(int id)
        {
            return DataContext.Ksiazki[id];
        }

        public IEnumerable<Ksiazka> GetAllKsiazka()
        {
            return (IEnumerable<Ksiazka>)DataContext.Ksiazki;
        }

        public void UpdateKsiazka(int id, Ksiazka ksiazka)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteKsiazka(Ksiazka ksiazka)
        {
            throw new System.NotImplementedException();
        }

        // -=-=-=-=-

        public void AddStan(Stan stan)
        {
            DataContext.Stany.Add(stan);
        }

        public Stan GetStan(int id)
        {
            return DataContext.Stany[id];
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
            throw new System.NotImplementedException();
        }

        // -=-=-=-=-

        public void AddKlient(Klient klient)
        {
            DataContext.Klienci.Add(klient);
        }

        public Klient GetKlient(int id)
        {
            return DataContext.Klienci[id];
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
            throw new System.NotImplementedException();
        }

        // -=-=-=-=-

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            DataContext.Zdarzenia.Add(zdarzenie);
        }

        public Zdarzenie GetZdarzenie(int id)
        {
            return DataContext.Zdarzenia[id];
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
            throw new System.NotImplementedException();
        }
    }
}
