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
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(T item);
        T GetItem(int id);
    }
}
