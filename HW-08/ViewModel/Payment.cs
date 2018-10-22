using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_08.ViewModel
{
    public class Payment:INotifyPropertyChanged
    {
        public Payment(double monthlyPayment, double amountToInterest, double amountToPrincipal, double remainingBalance)
        {
            MonthlyPayment = monthlyPayment;
            AmountToInterest = amountToInterest;
            AmountToPrincipal = amountToPrincipal;
            RemainingBalance = remainingBalance;
        }
        private double monthlyPayment;
        public double MonthlyPayment
        {
            get { return monthlyPayment; }
            set { SetField(ref monthlyPayment, value); }
        }
        private double amountToInterest;
        public double AmountToInterest
        {
            get { return amountToInterest; }
            set { SetField(ref amountToInterest, value); }
        }
        private double amountToPrincipal;
        public double AmountToPrincipal
        {
            get { return amountToPrincipal; }
            set { SetField(ref amountToPrincipal, value); }
        }
        private double remainingBalance;
        public double RemainingBalance
        {
            get { return remainingBalance; }
            set { SetField(ref remainingBalance, value); }
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
}
