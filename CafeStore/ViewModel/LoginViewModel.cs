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
                        MainViewModel vm = new MainViewModel(_navigation,Data);
                        _navigation.Show(View.WindowEnum.mainView, vm);
                    }
                    else
                        MessageBox.Show("Incorrect email or password!");
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
            Data = data;
            CurrentUser = new User();
            _iniCmd();
        }
        private void _iniCmd()
        {
            CmdSignIn.IsExecutable = true;
            CmdClose.IsExecutable = true;
        }
    }
}
