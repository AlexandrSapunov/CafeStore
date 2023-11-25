using CafeStore.Model;
using CafeStore.Model.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeStore.ViewModel
{
    public class OrderViewModel:BaseVM
    {
        private DataKeeper _data;
        private INavigationWin _navigationWin;
        private RelayCommand _cmdPayment;
        private RelayCommand _cmdCancel;
        private Order _currentOrder;


        public User CurrentUser { get; set; }
        public DataKeeper Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        public Order CurrentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }


        public RelayCommand CmdPayment
        {
            get
            {
                return _cmdPayment ?? (_cmdPayment=new RelayCommand(obj =>
                {
                    Data.Orders.Add(CurrentOrder);
                    MainViewModel vm = new MainViewModel(_navigationWin,Data,CurrentUser);

                    _navigationWin.Show(View.WindowEnum.mainView, vm);
                }));
            }
        }
        public RelayCommand CmdCancel
        {
            get
            {
                return _cmdCancel ?? (_cmdCancel=new RelayCommand(obj =>
                {
                    _navigationWin.Back();
                }));
            }
        }

        public OrderViewModel(INavigationWin navigation, DataKeeper data,User currentUser,Order currentOrder)
        {
            _navigationWin = navigation;
            Data = data;
            CurrentUser = currentUser;
            CurrentOrder = currentOrder;
            _initCmd();
        }

        private void _initCmd()
        {
            CmdCancel.IsExecutable = true;
            CmdPayment.IsExecutable = true;
        }
    }
}
