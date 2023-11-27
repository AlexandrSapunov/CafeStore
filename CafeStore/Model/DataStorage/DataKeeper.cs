using CafeStore.Model.Product;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CafeStore.Model.DataStorage
{
    [Serializable]
    public class DataKeeper
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Product.Product> Products { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public DataKeeper()
        {
            Users = new ObservableCollection<User>();
            Positions = new ObservableCollection<Position>();
            Categories = new ObservableCollection<Category>();
            Products = new ObservableCollection<Product.Product>();
            Orders = new ObservableCollection<Order>();
        }

        public static void Save(DataKeeper data)
        {
            XmlSerializer xml = new XmlSerializer(typeof(DataKeeper));

            using (TextWriter writer = new StreamWriter("Data.dat"))
            {
                xml.Serialize(writer, data);
            }
        }
        public static DataKeeper Load()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataKeeper));

                using (TextReader reader = new StreamReader("Data.dat"))
                {
                    return (DataKeeper)serializer.Deserialize(reader);
                }
            }
            catch
            {
                return null;
            }
        }

        #region User
        public bool AddUser(User user)
        {
            if (user.Fname.Length > 0 && user.Sname.Length > 0)
            {
                if (user.Email.Length > 8)
                {
                    if (user.Password.Length >= 8)
                    {
                        if (user.Post != null)
                        {
                            user.ID = _getMaxIDUser();
                            Users.Add(user);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool DelUser(User user)
        {
            if (user != null)
            {
                if (Users.Contains(user))
                {
                    Users.Remove(user);
                    return true;
                }
            }
            return false;
        }
        public bool SignIn(User user)
        {
            if (user != null)
            {
                if (user.Email.Length > 0)
                {
                    if (user.Password.Length > 7)
                    {
                        foreach(var item in Users)
                        {
                            if (item.Email == user.Email && item.Password==user.Password)
                            {
                                user = item;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private int _getMaxIDUser()
        {
            int max = Users.Count + 1;
            if (Users.Count > 0)
            {
                max = Users.Max(p => p.ID);
            }

            return max;
        }
        #endregion

        #region Position
        public bool AddPosition(Position position)
        {
            if (position.Title.Length > 4)
            {
                position.ID = _getMaxIDPosition();
                Positions.Add(position);
                return true;
            }
            return false;
        }
        public bool DelPosition(Position position)
        {
            if (position != null)
            {
                Positions.Remove(position);
                return true;
            }
            return false;
        }
        private int _getMaxIDPosition()
        {
            int max = Positions.Count + 1;
            if (Positions.Count > 0)
            {
                max = Positions.Max(p => p.ID);
            }

            return max+1;
        }
        #endregion

        #region Category
        public bool AddCategory(Category category)
        {
            if (category != null)
            {
                if (category.Name.Length > 4)
                {
                    category.ID = _getMaxIDCategory();
                    Categories.Add(category);
                    return true;
                }
            }
            return false;
        }
        public bool DelCategory(Category category)
        {
            if (category != null)
            {
                Categories.Remove(category);
                return true;
            }
            return false;
        }
        private int _getMaxIDCategory()
        {
            int max = Categories.Count+1;
            if (Categories.Count > 0)
            {
                max = Categories.Max(p => p.ID);
            }
            return max+1;
        }
        #endregion

        #region Product
        public bool AddProduct(Product.Product product)
        {
            if(product.Title.Length>0 && product.Price > 0)
            {
                product.ID = _getMaxIDProduct();
                Products.Add(product);
                return true;
            }
            return false;
        }
        public bool DelProduct(Product.Product product)
        {
            if (product != null)
            {
                Products.Remove(product);
                return true;
            }
            return false;
        }
        private int _getMaxIDProduct()
        {
            int max = Products.Count+1;
            if (Products.Count > 0)
            {
                max = Products.Max(p=>p.ID);
            }
            return max + 1;
        }
        #endregion

        #region Order
        public bool AddOrder(Order order)
        {
            if (order.Products.Count > 0)
            {
                if (order.Salesman != null)
                {
                    Orders.Add(order);
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
