using CafeStore.Model;
using CafeStore.Model.DataStorage;
using CafeStore.Model.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CafeStore.ViewModel
{
    public class MainViewModel : BaseVM
    {
        private DataKeeper _data;
        private INavigationWin _navigation;
        private RelayCommand _cmdPayment;
        private RelayCommand _cmdAdmin;

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
        public User CurrentUser { get; set; }
        public RelayCommand CmdPayment
        {
            get
            {
                return _cmdPayment ?? (_cmdPayment=new RelayCommand(obj =>
                {
                    _transmit();
                    if (CurrentOrder.Products.Count > 0)
                    {
                        CurrentOrder.Salesman = CurrentUser;
                        CurrentOrder.DateOfPurchase = DateTime.Now;
                        OrderViewModel orderViewModel = new OrderViewModel(_navigation, Data, CurrentUser, CurrentOrder);
                        _navigation.Show(View.WindowEnum.orderView, orderViewModel);
                    }
                }));
            }
        }
        public RelayCommand CmdAdmin
        {
            get
            {
                return _cmdAdmin ?? (_cmdAdmin=new RelayCommand(obj =>
                {
                    AdminViewModel advm = new AdminViewModel(_navigation);
                    _navigation.Show(View.WindowEnum.adminView,advm);
                }));
            }
        }

        #region Category
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                onUpdate();
            }
        }
        private void onUpdate() 
        {
            ProductList.Clear();
            foreach(var item in Data.Products)
            {
                if(item.PCategory.ID == SelectedCategory.ID)
                {
                    ProductList.Add(item);
                }
            }
        
        }
        #endregion

        #region ProductList obj
        private RelayCommand _addInOrder;
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;

        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ObservableCollection<Product> ProductList
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        public RelayCommand AddInOrder
        {
            get
            {
                return _addInOrder ?? (_addInOrder = new RelayCommand(obj =>
                {
                    if (SelectedProduct != null)
                    {
                        if (!OrderProducts.Contains(SelectedProduct))
                        {
                            SelectedProduct.Quantity=1;
                            CurrentOrder.Sum += SelectedProduct.Price;
                            OrderProducts.Add(SelectedProduct);
                        }
                        else 
                        { 
                            var product = OrderProducts.FirstOrDefault(p => p.Equals(SelectedProduct)); 
                            if (product != null) 
                            {
                                CurrentOrder.Sum += SelectedProduct.Price;
                                product.Quantity++; 
                            } 
                        }
                    }
                }));
            }
        }
        #endregion

        #region Order list
        private Order _currentOrder;
        private RelayCommand _addQuantity;
        private RelayCommand _removeQuantity;
        private RelayCommand _delProductInOrder;
        private Product _selectedProductInOrder;

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
        public RelayCommand AddQuantity
        {
            get
            {
                return _addQuantity ?? (_addQuantity = new RelayCommand(obj =>
                {
                    if (SelectedProductInOrder != null)
                    {
                        SelectedProductInOrder.Quantity++;
                        CurrentOrder.Sum += SelectedProductInOrder.Price;
                    }
                }));
            }
        }
        public RelayCommand RemoveQuantity
        {
            get
            {
                return _removeQuantity ?? (_removeQuantity = new RelayCommand(obj =>
                {
                    if (SelectedProductInOrder != null)
                    {
                        if (SelectedProductInOrder.Quantity <= 1)
                        {
                            CurrentOrder.Sum -= SelectedProductInOrder.Price;
                            OrderProducts.Remove(SelectedProductInOrder);
                        }
                        else
                        {
                            SelectedProductInOrder.Quantity--;
                            CurrentOrder.Sum -= SelectedProductInOrder.Price;
                        }
                    }
                }));
            }
        }
        public RelayCommand DelProductInOrder
        {
            get
            {
                return _delProductInOrder ?? (_delProductInOrder=new RelayCommand(obj =>
                {
                    if (SelectedProductInOrder != null)
                    {
                        int tempSum = SelectedProductInOrder.Quantity * SelectedProductInOrder.Price;
                        OrderProducts.Remove(SelectedProductInOrder);
                        CurrentOrder.Sum -= tempSum;
                        SelectedProductInOrder = new Product();
                    }
                }));
            }
        }
        public Product SelectedProductInOrder
        {
            get
            {
                return _selectedProductInOrder;
            }
            set
            {
                _selectedProductInOrder = value;
                OnPropertyChanged(nameof(SelectedProductInOrder));
            }
        }

        public ObservableCollection<Product> OrderProducts { get; set; } = new ObservableCollection<Product>();

        #endregion

        public MainViewModel(INavigationWin navigation,DataKeeper data,User currentUser)
        {
            Data = data;
            _navigation=navigation;
            ProductList = new ObservableCollection<Product>(Data.Products);
            CurrentOrder = new Order();
            CurrentUser = currentUser;
            _initCmd();
        }

        private void _initCmd()
        {
            AddInOrder.IsExecutable = true;
            AddQuantity.IsExecutable = true;
            RemoveQuantity.IsExecutable= true;
            DelProductInOrder.IsExecutable = true;
            CmdPayment.IsExecutable = true;
        }

        private void _transmit()
        {
            CurrentOrder.Products.Clear();
            foreach(var item in OrderProducts)
            {
                CurrentOrder.Products.Add(item);
            }
        }
    }
}
