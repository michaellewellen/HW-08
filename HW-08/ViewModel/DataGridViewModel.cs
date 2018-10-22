using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW_08.ViewModel
{
    public class DataGridViewModel:INotifyPropertyChanged,IDataErrorInfo
    {
        public DataGridViewModel()
        {
            PurchasePrice = 100000;
            IntSlider = 4;
            YrsSlider = 30;

            // Initial Mortgage Information
           
        }

        private double purchasePrice;
        public double PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                SetField(ref purchasePrice, value);
                OnPropertyChanged(nameof(MortgagePayment));
                if (IntSlider != 0)
                    Calculate();
            }
        }

        private double intSlider;
        public double IntSlider
        {
            get { return intSlider; }
            set
            {
                SetField(ref intSlider, value);
                OnPropertyChanged(nameof(MortgagePayment));
                if (YrsSlider !=0)
                    Calculate();
            }
        }

        private double yrsSlider;
        public double YrsSlider
        {
            get { return yrsSlider; }
            set
            {
                SetField(ref yrsSlider, value);
                OnPropertyChanged(nameof(MortgagePayment));
                Calculate();
            }
        }

        private double mortgagePayment;
        public double MortgagePayment
        {
            get { return mortgagePayment; }
            set
            {
                SetField(ref mortgagePayment, value);
            }
        }
        


        public void Calculate()
        {
            // Calculate Monthly Payment
            double expo = Math.Pow((1 + (IntSlider / 1200)), YrsSlider * 12);
            double d = (expo - 1) / ((IntSlider / 1200) * expo);
            double amount = PurchasePrice / d;
            MortgagePayment = Math.Round(amount, 2);

            amortizationSchedule = new ObservableCollection<Payment>();
            generatePaymentList();
            OnPropertyChanged(nameof(AmortizationSchedule));
        }

        private ObservableCollection<Payment> amortizationSchedule;
        public ObservableCollection<Payment> AmortizationSchedule
        {
            get { return amortizationSchedule; }
            set { SetField(ref amortizationSchedule, value); }
        }


        
        public void generatePaymentList()
        {
            double balance = PurchasePrice;
            while(balance > 0)
            {
                double interest = IntSlider / 1200 * balance;
                double principal = MortgagePayment - interest;
                balance -= principal;
                Payment month = new Payment(MortgagePayment, interest, principal, balance);
                AmortizationSchedule.Add(month);
            }

        }

        public string Error => throw new NotImplementedException();

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == nameof(IntSlider))
                {
                    if (IntSlider >= 0) { return null; }
                    else { return "Interest must be a positive value"; }
                }

                if (propertyName == nameof(YrsSlider))
                {
                    if (YrsSlider >= 0) { return null; }
                    else { return "Mortgage Period must be a postiive value"; }
                }

                if (propertyName == nameof(PurchasePrice))
                {
                    if (PurchasePrice >= 0) { return null; }
                    else { return "Purchase Price must be a postiive value"; }
                }
                return null;
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }


    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
