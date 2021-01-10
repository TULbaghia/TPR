using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataContext<T>
    {
        IEnumerable<T> GetItems();
        void AddItem(T item);
        void UpdateItem(T item);
        void DeleteItem(T item);
        T GetItem(int id);
    }
}
