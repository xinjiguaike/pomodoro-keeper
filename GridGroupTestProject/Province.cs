using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGroupTestProject
{
    public struct City
    {
        public string CityName { get; set; }
        public int CityID { get; set; }
    }

    public class Province
    {
        public string ProvinceName { set; get; }
        public ObservableCollection<City> Cities { set; get; }
    }

    
}
