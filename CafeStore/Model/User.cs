using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeStore.Model
{
    [Serializable]
    public class User:BaseVM
    {
        private int _id;
        private string _fname;
        private string _sname;
        private string _email;
        private string _password;
        private Position _post;

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
        public string Fname
        {
            get
            {
                return _fname;
            }
            set
            {
                _fname = value;
                OnPropertyChanged(nameof(Fname));
            }
        }
        public string Sname
        {
            get
            {
                return _sname;
            }
            set
            {
                _sname = value;
                OnPropertyChanged(nameof(Sname));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public Position Post
        {
            get
            {
                return _post;
            }
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }
    }
}
