using HeatChargingSystem.api;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeatChargingSystem.view.homeAction
{
    /// <summary>
    /// HomeUserChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeAddUserActionWindow : WindowX
    {
        public HomeAddUserActionWindow()
        {
            InitializeComponent();
            this.Loaded += HomeAddUserActionWindow_Loaded;
        }

        class controllerType1
        {
            public int id { get; set; }
            public string name { get; set; }
            public controllerType1(int id, string name)
            {
                this.id = id;
                this.name = name;

            }
        }
        class userType
        {
            public int id { get; set; }
            public string name { get; set; }
            public userType(int id, string name)
            {
                this.id = id;
                this.name = name;

            }
        }


        public List<Region> province = new List<Region>();
        public List<Region> city = new List<Region>();
        public List<Region> county = new List<Region>();
        public List<Region> street = new List<Region>();
        public List<Region> village = new List<Region>();
        //0 民用；1商用；2：共建；3：其他类型
        private void HomeAddUserActionWindow_Loaded(object sender, RoutedEventArgs e)
        {

            List<userType> list = new List<userType>();
            list.Add(new userType(0, "民用"));
            list.Add(new userType(1, "商用"));
            list.Add(new userType(2, "共建"));
            list.Add(new userType(3, "其他类型"));
            this.usertype.ItemsSource = list;


            //获取省级列表
            //List<Region> response = new ApiImpl().GetRegion("2", "1");
            //if (response != null)
            //{
            //    com_province.ItemsSource = response;
            //}

            //List<controller_type> response1 = new ApiImpl().GetAllDictionary();
            //this.controllerType.ItemsSource = response1;

        }

        private void com_province_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            city.Clear();
            county.Clear();
            street.Clear();
            village.Clear();
            if (com_province.SelectedValue == null)
                return;
            Region s = (Region)com_province.SelectedValue;

            //获取城市列表
            com_city.ItemsSource = null;
            city = new ApiImpl().GetRegion("3", s.id);
            if (city != null)
            {
                com_city.ItemsSource = city;
                com_city.SelectedIndex = 0;
            }
        }

        private void com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            county.Clear();
            street.Clear();
            village.Clear();
            if (com_city.SelectedValue == null)
                return;
            Region s = (Region)com_city.SelectedValue;
            ////获取区/县列表
            county = new ApiImpl().GetRegion("4", s.id);
            if (county != null)
            {
                com_county.ItemsSource = null;
                com_county.ItemsSource = county;
                com_county.SelectedIndex = 0;
            }

        }
        private void com_county_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            street.Clear();
            village.Clear();
            if (com_county.SelectedValue == null)
                return;
            Region s = (Region)com_county.SelectedValue;
            ////获取街道列表
            street = new ApiImpl().GetRegion("4", s.id);
            if (street != null)
            {
                com_street.ItemsSource = null;
                com_street.ItemsSource = street;
                //com_street.SelectedIndex = 0;
            }
        }

        private void com_street_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            village.Clear();
            if (com_street.SelectedValue == null)
                return;
            Region s = (Region)com_street.SelectedValue;
            ////获取小区列表
            village = new ApiImpl().GetRegion("4", s.id);
            if (village != null)
            {
                com_village.ItemsSource = null;
                com_village.ItemsSource = street;
                //  com_county.SelectedIndex = 0;
            }
        }

        private void add_btn(object sender, RoutedEventArgs e)
        {
           
            if (this.userId.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("用户名不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.phone.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("联系方式不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.usertype.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("用户类型不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.area.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("供热面积不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.controllerType.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("门阀类型不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.controllerCode.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("门阀序列号不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.build.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("楼号不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.unit.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("单元不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.room.Text == String.Empty)
            {
                System.Windows.MessageBox.Show("室不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            if (this.com_province.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("省份不能为空", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            
          
            var userId = this.userId.Text.Trim();
            var phone = this.phone.Text.Trim();
            var usertype = this.usertype.SelectedIndex.ToString();          
            var area = this.area.Text.Trim();
            var controllerType = this.controllerType.SelectedIndex.ToString();
            var controllerCode = this.controllerCode.Text.Trim();
            var build = this.build.Text.Trim();
            var unit = this.unit.Text.Trim();
            var room = this.room.Text.Trim();

            ResponseUserInfoModel request = new ResponseUserInfoModel();
            request.name = userId;
            request.phone = phone;
            request.userType = usertype;
            request.area = area;
            request.controllerType = controllerType;
            request.controllerCode = controllerCode;
            request.build = build;
            request.unit = unit;
            request.room = room;

            request.hourseCode = "1231";
            request.provice = "浙江";
            request.city = "杭州"; ;
            request.county = "滨江"; ;
            request.street = "浦沿"; ;
            request.village = "新村"; ;

            BaseResponseModel response = new ApiImpl().AddUser(request);
            if (response != null&&response.code=="200")
            {
                //System.Windows.MessageBox.Show("添加成功", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                System.Windows.MessageBox.Show(response.msg.ToString(), "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
