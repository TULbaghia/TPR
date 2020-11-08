using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1.Data
{
    public class DataContext
    {
        public List<Klient> Klienci { get; private set; } = new List<Klient>();
        public Dictionary<int, Ksiazka> Ksiazki { get; private set; } = new Dictionary<int, Ksiazka>();
        public List<Stan> Stany { get; private set; } = new List<Stan>();
        public ObservableCollection<Zdarzenie> Zdarzenia { get; private set; } = new ObservableCollection<Zdarzenie>();
    }
}
