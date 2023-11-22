using CafeStore.Model.DataStorage;
using CafeStore.View;
using CafeStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CafeStore
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DataKeeper data = DataKeeper.Load();
            if (data == null)
                data = new DataKeeper();
            Navigation navigation = new Navigation();
            LoginViewModel lvm = new LoginViewModel(navigation,data);
            navigation.Show(WindowEnum.loginView, lvm);
        }
    }
}
