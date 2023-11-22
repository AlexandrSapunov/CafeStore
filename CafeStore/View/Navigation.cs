using CafeStore.Model;
using CafeStore.Model.DataStorage;
using CafeStore.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CafeStore.View
{
    public class Navigation : INavigationWin
    {
        private NavigationFarme _currNavFrame = null;
        private Stack<NavigationFarme> _navigationHistory { get; set; }
        private class NavigationFarme
        {
            public WindowEnum CurrState { get; set; }
            public object CurrVm { get; set; }

            public NavigationFarme(WindowEnum currState, object currVm)
            {
                CurrState = currState;
                CurrVm = currVm;
            }
        }
        
        public Window CWindow { get; set; }

        public Navigation()
        {
            _navigationHistory = new Stack<NavigationFarme>();

        }
        public void Show(WindowEnum windowEnum, object itemVM)
        {
            if (!(_currNavFrame is null))
                _navigationHistory.Push(_currNavFrame);

            _showCore(new NavigationFarme(windowEnum, itemVM));
        }

        private void _showCore(NavigationFarme navigation)
        {
            Window prevWindow = CWindow;
            switch (navigation.CurrState)
            {
                case WindowEnum.loginView:
                    CWindow = new LoginView();
                    break;
                case WindowEnum.mainView:

                    break;
                case WindowEnum.adminView:
                    CWindow = new AdminView();
                    break;
                case WindowEnum.profileView:

                    break;
            }
            _currNavFrame = navigation;
            CWindow.DataContext = navigation.CurrVm;
            CWindow.Show();
            prevWindow?.Close();
        }

        public void Back()
        {
            NavigationFarme prevWin = _navigationHistory.Pop();
            _showCore(prevWin);
        }
    }
}
