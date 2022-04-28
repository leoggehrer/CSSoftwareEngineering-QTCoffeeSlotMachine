using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace QTCoffeeSlotMachine.WpfApp.ViewModels
{
    public class CoffeeMachineViewModel : BaseViewModel
    {
        private Logic.Controllers.CoffeeMachineController Controller { get; set; }

        public CoffeeMachineViewModel()
        {
            Controller = new Logic.Controllers.CoffeeMachineController("HTL-Leonding");
            //Controller = new Logic.Controllers.CoffeeMachineController();

            Update();
        }

        private void Update()
        {
            SetDepotCounters();
            SetInsertCounters();
            SetEjectionCounters();
            OnPropertyChanged(nameof(ProductInfos));
        }
        private void SetDepotCounters()
        {
            Controller.GetCounterForDepot(5, out int counter);
            FiveCentInDepot = counter;

            Controller.GetCounterForDepot(10, out counter);
            TenCentInDepot = counter;

            Controller.GetCounterForDepot(20, out counter);
            TwentyCentInDepot = counter;

            Controller.GetCounterForDepot(50, out counter);
            FiftyCentInDepot = counter;

            Controller.GetCounterForDepot(100, out counter);
            HundredCentInDepot = counter;

            Controller.GetCounterForDepot(200, out counter);
            TwoHundredCentInDepot = counter;
        }
        private void SetInsertCounters()
        {
            Controller.GetCounterForInsert(5, out int counter);
            FiveCentInInsert = counter;

            Controller.GetCounterForInsert(10, out counter);
            TenCentInInsert = counter;

            Controller.GetCounterForInsert(20, out counter);
            TwentyCentInInsert = counter;

            Controller.GetCounterForInsert(50, out counter);
            FiftyCentInInsert = counter;

            Controller.GetCounterForInsert(100, out counter);
            HundredCentInInsert = counter;

            Controller.GetCounterForInsert(200, out counter);
            TwoHundredCentInInsert = counter;
        }
        private void SetEjectionCounters()
        {
            Controller.GetCounterForEjection(5, out int counter);
            FiveCentInEjection = counter;

            Controller.GetCounterForEjection(10, out counter);
            TenCentInEjection = counter;

            Controller.GetCounterForEjection(20, out counter);
            TwentyCentInEjection = counter;

            Controller.GetCounterForEjection(50, out counter);
            FiftyCentInEjection = counter;

            Controller.GetCounterForEjection(100, out counter);
            HundredCentInEjection = counter;

            Controller.GetCounterForEjection(200, out counter);
            TwoHundredCentInEjection = counter;
        }

        public string Location => Controller.Location;
        private int fiveCentInDepot;
        public int FiveCentInDepot
        {
            get { return fiveCentInDepot; }
            set
            {
                fiveCentInDepot = value;
                OnPropertyChanged(nameof(FiveCentInDepot));
            }
        }
        private int tenCentInDepot;
        public int TenCentInDepot
        {
            get { return tenCentInDepot; }
            set
            {
                tenCentInDepot = value;
                OnPropertyChanged(nameof(TenCentInDepot));
            }
        }
        private int twentyCentInDepot;
        public int TwentyCentInDepot
        {
            get { return twentyCentInDepot; }
            set
            {
                twentyCentInDepot = value;
                OnPropertyChanged(nameof(TwentyCentInDepot));
            }
        }
        private int fiftyCentInDepot;
        public int FiftyCentInDepot
        {
            get { return fiftyCentInDepot; }
            set
            {
                fiftyCentInDepot = value;
                OnPropertyChanged(nameof(FiftyCentInDepot));
            }
        }
        private int hundredCentInDepot;
        public int HundredCentInDepot
        {
            get { return hundredCentInDepot; }
            set
            {
                hundredCentInDepot = value;
                OnPropertyChanged(nameof(HundredCentInDepot));
            }
        }
        private int twoHundredCentInDepot;
        public int TwoHundredCentInDepot
        {
            get { return twoHundredCentInDepot; }
            set
            {
                twoHundredCentInDepot = value;
                OnPropertyChanged(nameof(TwoHundredCentInDepot));
            }
        }

        private int fiveCentInInsert;
        public int FiveCentInInsert
        {
            get { return fiveCentInInsert; }
            set
            {
                fiveCentInInsert = value;
                OnPropertyChanged(nameof(FiveCentInInsert));
            }
        }
        private int tenCentInInsert;
        public int TenCentInInsert
        {
            get { return tenCentInInsert; }
            set
            {
                tenCentInInsert = value;
                OnPropertyChanged(nameof(TenCentInInsert));
            }
        }
        private int twentyCentInInsert;
        public int TwentyCentInInsert
        {
            get { return twentyCentInInsert; }
            set
            {
                twentyCentInInsert = value;
                OnPropertyChanged(nameof(TwentyCentInInsert));
            }
        }
        private int fiftyCentInInsert;
        public int FiftyCentInInsert
        {
            get { return fiftyCentInInsert; }
            set
            {
                fiftyCentInInsert = value;
                OnPropertyChanged(nameof(FiftyCentInInsert));
            }
        }
        private int hundredCentInInsert;
        public int HundredCentInInsert
        {
            get { return hundredCentInInsert; }
            set
            {
                hundredCentInInsert = value;
                OnPropertyChanged(nameof(HundredCentInInsert));
            }
        }
        private int twoHundredCentInInsert;
        public int TwoHundredCentInInsert
        {
            get { return twoHundredCentInInsert; }
            set
            {
                twoHundredCentInInsert = value;
                OnPropertyChanged(nameof(TwoHundredCentInInsert));
            }
        }

        private int fiveCentInEjection;
        public int FiveCentInEjection
        {
            get { return fiveCentInEjection; }
            set
            {
                fiveCentInEjection = value;
                OnPropertyChanged(nameof(FiveCentInEjection));
            }
        }
        private int tenCentInEjection;
        public int TenCentInEjection
        {
            get { return tenCentInEjection; }
            set
            {
                tenCentInEjection = value;
                OnPropertyChanged(nameof(TenCentInEjection));
            }
        }
        private int twentyCentInEjection;
        public int TwentyCentInEjection
        {
            get { return twentyCentInEjection; }
            set
            {
                twentyCentInEjection = value;
                OnPropertyChanged(nameof(TwentyCentInEjection));
            }
        }
        private int fiftyCentInEjection;
        public int FiftyCentInEjection
        {
            get { return fiftyCentInEjection; }
            set
            {
                fiftyCentInEjection = value;
                OnPropertyChanged(nameof(FiftyCentInEjection));
            }
        }
        private int hundredCentInEjection;
        public int HundredCentInEjection
        {
            get { return hundredCentInEjection; }
            set
            {
                hundredCentInEjection = value;
                OnPropertyChanged(nameof(HundredCentInEjection));
            }
        }
        private int twoHundredCentInEjection;

        public int TwoHundredCentInEjection
        {
            get { return twoHundredCentInEjection; }
            set
            {
                twoHundredCentInEjection = value;
                OnPropertyChanged(nameof(TwoHundredCentInEjection));
            }
        }

        public string[] Coins
        {
            get
            {
                return new string[] { "5", "10", "20", "50", "100", "200" };
            }
        }
        public string[] ProductNames => Controller.ProductNames;
        public string[] ProductInfos
        {
            get
            {
                string[] result = Controller.ProductNames;

                for (int i = 0; i < result.Length; i++)
                {
                    Controller.GetCounterForProduct(result[i], out int counter);

                    while (result[i].Length < 30)
                        result[i] += " ";

                    result[i] = $"{result[i]}{counter}";
                }
                return result;
            }
        }

        public string SelectedCoin { get; set; } = string.Empty;
        public string SelectedProduct { get; set; } = string.Empty;
        public bool InsertCoin(int coin)
        {
            bool result = Controller.InsertCoin(coin);
            Update();
            return result;
        }
        public bool CanSelect => Controller.CanSelect;
        public bool SelectProduct(string product)
        {
            bool result = Controller.SelectProduct(product, out _);

            Update();
            return result;
        }
        public void CancelOrder()
        {
            Controller.CancelOrder();
            Update();
        }

        public void Eject()
        {
            Controller.EmptyEjection(out _);
            Update();
        }

        #region Commands
        private ICommand? insertCommand = null;
        public ICommand InsertCoinCommand
        {
            get => RelayCommand.CreateCommand(ref insertCommand, p =>
            {
                if (Int32.TryParse(SelectedCoin, out int coin))
                {
                    InsertCoin(coin);
                }
            });
        }
        private ICommand? cancelOrderCommand = null;
        public ICommand CancelOrderCommand
        {
            get => RelayCommand.CreateCommand(ref cancelOrderCommand, p =>
            {
                CancelOrder();
            });
        }
        private ICommand? ejectCommand = null;
        public ICommand EjectCommand
        {
            get => RelayCommand.CreateCommand(ref ejectCommand, p =>
            {
                Eject();
            });
        }
        private ICommand? selectCommand = null;
        public ICommand SelectCommand
        {
            get => RelayCommand.CreateCommand(ref selectCommand, p =>
            {
                SelectProduct(SelectedProduct);
            }, p => CanSelect);
        }
        #endregion Commands
    }
}
