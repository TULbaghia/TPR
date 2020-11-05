using System;
using System.Collections.Generic;
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

        void foo()
        {
            IData.AddKlient(new Klient("1", "2"));
        }
    }
}
