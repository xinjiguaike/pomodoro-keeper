using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GridGroupTestProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static ObservableCollection<Province> list = new ObservableCollection<Province>();
        static MainPage()
        {
            ObservableCollection<City> ctyHeNan = new ObservableCollection<City>();
            ctyHeNan.Add(new City() { CityID = 0, CityName = "ZhengZhou" });
            ctyHeNan.Add(new City() { CityID = 1, CityName = "KaiFeng" });
            ctyHeNan.Add(new City() { CityID = 2, CityName = "LuoYang" });

            ObservableCollection<City> ctyZheJiang = new ObservableCollection<City>();
            ctyZheJiang.Add(new City() { CityID = 3, CityName = "HangZhou" });
            ctyZheJiang.Add(new City() { CityID = 4, CityName = "WenZhou" });
            ctyZheJiang.Add(new City() { CityID = 5, CityName = "NingBo" });

            ObservableCollection<City> ctyJiLin = new ObservableCollection<City>();
            ctyJiLin.Add(new City() { CityID = 6, CityName = "ChangChun" });
            ctyJiLin.Add(new City() { CityID = 7, CityName = "TongHua" });
            ctyJiLin.Add(new City() { CityID = 8, CityName = "SiPing" });

            ObservableCollection<City> ctyAAA = new ObservableCollection<City>();
            ctyAAA.Add(new City() { CityID = 6, CityName = "ChangChun" });
            ctyAAA.Add(new City() { CityID = 7, CityName = "TongHua" });
            ctyAAA.Add(new City() { CityID = 8, CityName = "SiPing" });

            ObservableCollection<City> ctyBBB = new ObservableCollection<City>();
            ctyBBB.Add(new City() { CityID = 6, CityName = "ChangChun" });
            ctyBBB.Add(new City() { CityID = 7, CityName = "TongHua" });
            ctyBBB.Add(new City() { CityID = 8, CityName = "SiPing" });

            ObservableCollection<City> ctyCCC = new ObservableCollection<City>();
            ctyCCC.Add(new City() { CityID = 6, CityName = "ChangChun" });
            ctyCCC.Add(new City() { CityID = 7, CityName = "TongHua" });
            ctyCCC.Add(new City() { CityID = 8, CityName = "SiPing" });


            list.Add(new Province() { ProvinceName = "HeNan", Cities = ctyHeNan });
            list.Add(new Province() { ProvinceName = "ZheJiang", Cities = ctyZheJiang });
            list.Add(new Province() { ProvinceName = "JiLin", Cities = ctyJiLin });
            list.Add(new Province() { ProvinceName = "AAA", Cities = ctyAAA });
            //list.Add(new Province() { ProvinceName = "BBB", Cities = ctyBBB });
            //list.Add(new Province() { ProvinceName = "CCC", Cities = ctyCCC });
            
        }


        public MainPage()
        {
            this.InitializeComponent();
            InfoList.Source = list;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
