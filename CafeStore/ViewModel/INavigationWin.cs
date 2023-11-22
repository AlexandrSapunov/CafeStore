using CafeStore.Model.DataStorage;
using CafeStore.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeStore.ViewModel
{
    public interface INavigationWin
    {
        void Show(WindowEnum windowEnum, object itemVM);
        void Back();
    }
}
