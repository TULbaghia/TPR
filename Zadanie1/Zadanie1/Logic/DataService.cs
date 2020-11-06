using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Zadanie1.Data;

namespace Zadanie1.Logic
{
    class DataService
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
        public void UpdateKlient()
        {
            //
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
        public void UpdateKsiazka()
        {
            //
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
        public void UpdateStan()
        {
            //
        }
        public void DeleteStan(Stan stan)
        {
            IData.DeleteStan(stan);
        }

        // -=-=-=-=-

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            IData.AddZdarzenie(zdarzenie);
        }
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

    }
}
