namespace Zadanie1
{
    public class DataRepository
    {
        public DataRepository(IDataFiller dataFiller, DataContext dataContext)
        {
            DataContext = dataContext;
            dataFiller.Fill(DataContext);
        }

        public DataContext DataContext { get; private set; }
    }
}
