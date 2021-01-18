using System.Collections.Generic;

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
