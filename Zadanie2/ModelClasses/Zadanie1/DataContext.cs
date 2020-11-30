using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ModelClasses.Zadanie1.Data
{
    public class DataContext
    {
        public List<Klient> Klienci { get; private set; } = new List<Klient>();
        public Dictionary<int, Ksiazka> Ksiazki { get; private set; } = new Dictionary<int, Ksiazka>();
        public List<Stan> Stany { get; private set; } = new List<Stan>();
        public ObservableCollection<Zdarzenie> Zdarzenia { get; private set; } = new ObservableCollection<Zdarzenie>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Klienci:\n");
            stringBuilder.Append(string.Join(", \n", Klienci));
            stringBuilder.Append("\nKsiazki:\n");
            stringBuilder.Append(string.Join(", \n", Ksiazki));
            stringBuilder.Append("\nStany:\n");
            stringBuilder.Append(string.Join(", \n", Stany));
            stringBuilder.Append("\nZdarzenia:\n");
            stringBuilder.Append(string.Join(", \n", Zdarzenia));
            return stringBuilder.ToString();
        }
    }
}
