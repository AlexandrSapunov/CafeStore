using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeStore.Model
{
    [Serializable]
    public class Position:BaseVM
    {
        private int _id;
        private string _title;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value; 
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}
