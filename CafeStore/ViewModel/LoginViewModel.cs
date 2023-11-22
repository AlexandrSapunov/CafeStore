using CafeStore.Model;
using CafeStore.Model.DataStorage;
using System.Windows;

namespace CafeStore.ViewModel
{
    public class LoginViewModel : BaseVM
    {
        private RelayCommand _cmdSignIn;
        private RelayCommand _cmdClose;
        private INavigationWin _navigation;
        private User _currentUser;
        private DataKeeper _data;

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
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
        public RelayCommand CmdSignIn
        {
            get
            {
                return _cmdSignIn ?? (_cmdSignIn = new RelayCommand(obj =>
                {
                    if (Data.SignIn(CurrentUser))
                    {

                    }
                }));
            }
        }
        public RelayCommand CmdClose
        {
            get
            {
                return _cmdClose ?? (_cmdClose = new RelayCommand(obj =>
                {
                    Application.Current.Shutdown();
                }));
            }
        }

        public LoginViewModel(INavigationWin navigation, DataKeeper data)
        {
            _navigation = navigation;
            _iniCmd();
        }
        public LoginViewModel()
        {
            _iniCmd();
        }
        private void _iniCmd()
        {
            CmdSignIn.IsExecutable = true;
            CmdClose.IsExecutable = true;
        }
    }
}
