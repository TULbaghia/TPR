using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1.Data
{
    public class DataContext
    {
        public List<Klient> Klienci = new List<Klient>();
        public Dictionary<int, Ksiazka> Ksiazki = new Dictionary<int, Ksiazka>();
        public List<Stan> Stany = new List<Stan>();
        public ObservableCollection<Zdarzenie> Zdarzenia = new ObservableCollection<Zdarzenie>();
    }
}
