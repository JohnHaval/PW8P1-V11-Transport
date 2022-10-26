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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Transports;
using Transports.Children;

namespace PW8P1_V11_Transport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
        }
        Transport MainTranport = new Transport();
        Car MainCar = new Car();
        Bus MainBus = new Bus();
        Truck MainTruck = new Truck();
        private void FillComboBoxes()
        {
            List<Transport.TransportControl> transportControls = new List<Transport.TransportControl>()
            {
                Transport.TransportControl.Easy,
                Transport.TransportControl.Medium,
                Transport.TransportControl.Hard,
                Transport.TransportControl.Impossible
            };
            ControlSelector.ItemsSource = transportControls;
            ControlSelector.SelectedIndex = 0;
            List<Car.ComfortClass> carComforts = new List<Car.ComfortClass>()
            {
                Car.ComfortClass.None,
                Car.ComfortClass.Common,
                Car.ComfortClass.Luxury
            };
            ComfortSelector.ItemsSource = carComforts;
            ComfortSelector.SelectedIndex = 1;
        }
        private void AddTransport_Click(object sender, RoutedEventArgs e)
        {
            if (ComfortSelector.SelectedIndex == -1 || ControlSelector.SelectedIndex == -1)
                MessageBox.Show("Выберите класс-комфорт и управляемость для авто перед добавлением!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else GoCreating();
        }        
        private void GoCreating()
        {
            Transport transport = null;
            Car car = null;
            Bus bus = null;
            Truck truck = null;
            if (TransportCS.IsChecked == true)
            {
                transport = new Transport();                
            }
            if (CarCS.IsChecked == true)
            {
                car = new Car();
            }
            if (BusCS.IsChecked == true)
            {
                bus = new Bus();
            }
            if (TruckCS.IsChecked == true)
            {
                truck = new Truck();
            }
            if (transport != null) CreateTransport(transport);
            if (car != null) CreateCar(car);
            if (bus != null) CreateBus(bus);
            if (truck != null) CreateTruck(truck);
        }
        private void CreateTransport(Transport transport)
        {
            try
            {
                transport.MaxSpeed = Convert.ToInt32(MaxSpeed.Text);
                transport.Power = Convert.ToInt32(Power.Text);
                transport.ChangeCompany(Company.Text);
                transport.Control = MainCar.Control;
                transport.IsCrashed = (bool)SetCrash.IsChecked;
                transport.WinterTiresSetup((bool)SetWinterTires.IsChecked);
                MainTranport = transport;
                TransportList.Items.Add(transport);
            }
            catch
            {
                AddError();
            }
        }
        private void CreateCar(Car car)
        {
            try 
            { 
            car.MaxSpeed = Convert.ToInt32(MaxSpeed.Text);
            car.Power = Convert.ToInt32(Power.Text);
            car.ChangeCompany(Company.Text);            
            car.WinterTiresSetup((bool)SetWinterTires.IsChecked);
            if (!(bool)SetCrash.IsChecked)
            {
                car.Control = MainCar.Control;
                car.Comfort = MainCar.Comfort;
                car.OwnerSetup((bool)SetOwner.IsChecked);
            }
            else
            {
                if (car.HasOwner) car.DestroyTransport();
                else car.DeathCarSituation();
            }
            MainCar = car;
            TransportList.Items.Add(car);
            }
            catch
            {
                AddError();
            }
}
        private void CreateBus(Bus bus)
        {
            try
            { 
            bus.MaxSpeed = Convert.ToInt32(MaxSpeed.Text);
            bus.Power = Convert.ToInt32(Power.Text);
            bus.ChangeCompany(Company.Text);
            bus.Control = MainCar.Control;
            bus.IsCrashed = (bool)SetCrash.IsChecked;
            bus.WinterTiresSetup((bool)SetWinterTires.IsChecked);
            bus.MaxPassengers = Convert.ToInt32(MaxPassengers.Text);
            bus.ElectroBusSetup((bool)SetElectroBus.IsChecked);
            MainBus = bus;
            TransportList.Items.Add(bus);
            }
            catch
            {
                AddError();
            }
}
        private void CreateTruck(Truck truck)
        {
            try 
            { 
            truck.MaxSpeed = Convert.ToInt32(MaxSpeed.Text);
            truck.Power = Convert.ToInt32(Power.Text);
            truck.ChangeCompany(Company.Text);
            truck.Control = MainCar.Control;
            truck.IsCrashed = (bool)SetCrash.IsChecked;
            truck.WinterTiresSetup((bool)SetWinterTires.IsChecked);
            truck.MaxSpace = Convert.ToInt32(MaxPassengers.Text);
            MainTruck = truck;
            TransportList.Items.Add(truck);
            }
            catch
            {
                AddError();
            }
        }
        private void AddError()
        {
            MessageBox.Show("Необходимо установить подходящие параметры", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SetCrash_Click(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                MainCar.DestroyTransport();
                ControlSelector.SelectedItem = MainCar.Control;
                ComfortSelector.SelectedItem = MainCar.Comfort;
                ControlSelector.IsEnabled = ComfortSelector.IsEnabled = false;                
            }
            else
            {
                MainCar.RestoreTransport();
                ControlSelector.SelectedItem = MainCar.Control;
                ComfortSelector.SelectedItem = MainCar.Comfort;
                ControlSelector.IsEnabled = ComfortSelector.IsEnabled = true;
            }
        }

        private void SetDeathCarSituation_Click(object sender, RoutedEventArgs e)
        {
            SetCrash.IsChecked = true;
            try
            {
                MainCar.DeathCarSituation();
            }
            catch { }
            SetOwner.IsChecked = MainCar.HasOwner;
            ControlSelector.SelectedItem = MainCar.Control;
            ComfortSelector.SelectedItem = MainCar.Comfort;
            ControlSelector.IsEnabled = ComfortSelector.IsEnabled = false;
        }

        private void Space_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainTruck.CurrentSpace = Convert.ToInt32(e.NewValue);
            HoldedSpace.Text = MainTruck.CurrentSpace.ToString();
            FreeSpace.Text = MainTruck.FreeSpace.ToString();
        }

        private void MaxSpace_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaxOfSpace.Text = MainTruck.GetMaxSpace().ToString();
        }

        private void MaxPassengers_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaxOfPassengers.Text = MainBus.MaxPassengers.ToString();
        }

        private void Passengers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainBus.CurrentPassengers = Convert.ToInt32(e.NewValue);
            CurrentPassengers.Text = MainBus.CurrentPassengers.ToString();
            FreePlaces.Text = MainBus.FreePlaces.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TransportList.Items.Clear();
        }
        //Transport transport = new Transport();
        //Transport trp = new Car();
        //Transport trp2 = new Bus();
        //Transport trp3 = new Truck();
    }
}
