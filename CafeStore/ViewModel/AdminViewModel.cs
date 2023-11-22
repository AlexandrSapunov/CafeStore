using CafeStore.Model;
using CafeStore.Model.DataStorage;
using CafeStore.Model.Product;

namespace CafeStore.ViewModel
{
    public class AdminViewModel : BaseVM
    {
        public DataKeeper Data { get; set; }


        public AdminViewModel()
        {
            Data = DataKeeper.Load();
            if (Data == null)
                Data = new DataKeeper();
            _initState();
        }

        #region User
        private RelayCommand _cmdAddUser;
        private RelayCommand _cmdRemoveUser;
        private RelayCommand _cmdCancelUser;
        private RelayCommand _cmdSaveUser;
        private User _selectedUser;
        private bool _isSLU;

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public bool IsSelectedListUser
        {
            get
            {
                return _isSLU;
            }
            set
            {
                _isSLU = value;
                OnPropertyChanged(nameof(IsSelectedListUser));
            }
        }

        public RelayCommand CmdAddUser
        {
            get
            {
                return _cmdAddUser ?? (_cmdAddUser = new RelayCommand(obj =>
                {
                    SelectedUser = new User();

                    _setUserState(ViewState.edit);
                }));
            }
        }
        public RelayCommand CmdRemoveUser
        {
            get
            {
                return _cmdRemoveUser ?? (_cmdRemoveUser = new RelayCommand(obj =>
                {
                    if (SelectedUser != null)
                    {
                        Data.DelUser(SelectedUser);
                        DataKeeper.Save(Data);
                    }
                }));
            }
        }
        public RelayCommand CmdCancelUser
        {
            get
            {
                return _cmdCancelUser ?? (_cmdCancelUser = new RelayCommand(obj =>
                {
                    SelectedUser = new User();
                    _setUserState(ViewState.view);
                }));
            }
        }
        public RelayCommand CmdSaveUser
        {
            get
            {
                return _cmdSaveUser ?? (_cmdSaveUser = new RelayCommand(obj =>
                {
                    Data.AddUser(SelectedUser);
                    DataKeeper.Save(Data);
                    _setUserState(ViewState.view);
                    SelectedUser = new User();
                }));
            }
        }


        private void _setUserState(ViewState state)
        {
            switch (state)
            {
                case ViewState.view:
                    CmdAddUser.IsExecutable = true;
                    CmdRemoveUser.IsExecutable = true;
                    CmdCancelUser.IsExecutable = false;
                    CmdSaveUser.IsExecutable = false;
                    IsSelectedListUser = true;
                    break;
                case ViewState.edit:
                    CmdAddUser.IsExecutable = false;
                    CmdRemoveUser.IsExecutable = false;
                    CmdCancelUser.IsExecutable = true;
                    CmdSaveUser.IsExecutable = true;
                    IsSelectedListUser = false;
                    break;
            }
        }
        #endregion

        #region Position
        private RelayCommand _cmdAddPosition;
        private RelayCommand _cmdRemovePosition;
        private RelayCommand _cmdCancelPosition;
        private RelayCommand _cmdSavePosition;
        private Position _selectedPosition;
        private bool _isSLP;

        public Position SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }
            set
            {
                _selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public bool IsSelectedListPosition
        {
            get
            {
                return _isSLP;
            }
            set
            {
                _isSLP = value;
                OnPropertyChanged(nameof(IsSelectedListPosition));
            }
        }

        public RelayCommand CmdAddPosition
        {
            get
            {
                return _cmdAddPosition ?? (_cmdAddPosition = new RelayCommand(obj =>
                {
                    SelectedPosition = new Position();
                    _setPositionState(ViewState.edit);
                }));
            }
        }
        public RelayCommand CmdRemovePosition
        {
            get
            {
                return _cmdRemovePosition ?? (_cmdRemovePosition = new RelayCommand(obj =>
                {
                    Data.DelPosition(SelectedPosition);
                    DataKeeper.Save(Data);
                }));
            }
        }
        public RelayCommand CmdCancelPosition
        {
            get
            {
                return _cmdCancelPosition ?? (_cmdCancelPosition = new RelayCommand(obj =>
                {
                    SelectedPosition = new Position();
                    _setPositionState(ViewState.view);
                }));
            }
        }
        public RelayCommand CmdSavePosition
        {
            get
            {
                return _cmdSavePosition ?? (_cmdSavePosition = new RelayCommand(obj =>
                {
                    Data.AddPosition(SelectedPosition);
                    DataKeeper.Save(Data);
                    _setPositionState(ViewState.view);
                    SelectedPosition = new Position();
                }));
            }
        }

        private void _setPositionState(ViewState state)
        {
            switch (state)
            {
                case ViewState.view:
                    CmdAddPosition.IsExecutable = true;
                    CmdRemovePosition.IsExecutable = true;
                    CmdCancelPosition.IsExecutable = false;
                    CmdSavePosition.IsExecutable = false;
                    IsSelectedListPosition = true;
                    break;
                case ViewState.edit:
                    CmdAddPosition.IsExecutable = false;
                    CmdRemovePosition.IsExecutable = false;
                    CmdCancelPosition.IsExecutable = true;
                    CmdSavePosition.IsExecutable = true;
                    IsSelectedListPosition = false;
                    break;
            }
        }
        #endregion

        #region Category
        private Category _selectedCategory;
        private RelayCommand _cmdAddCategory;
        private RelayCommand _cmdRemoveCategory;
        private RelayCommand _cmdCancelCategory;
        private RelayCommand _cmdSaveCategory;
        private bool _isSLC;

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
            }
        }
        public bool IsSelectedListCategory
        {
            get
            {
                return _isSLC;
            }
            set
            {
                _isSLC = value;
                OnPropertyChanged(nameof(IsSelectedListCategory));
            }
        }
        public RelayCommand CmdAddCategory
        {
            get
            {
                return _cmdAddCategory ?? (_cmdAddCategory = new RelayCommand(obj =>
                {
                    SelectedCategory = new Category();
                    _setCategoryState(ViewState.edit);
                }));
            }
        }
        public RelayCommand CmdRemoveCategory
        {
            get
            {
                return _cmdRemoveCategory ?? (_cmdRemoveCategory = new RelayCommand(obj =>
                {
                    Data.DelCategory(SelectedCategory);
                }));
            }
        }
        public RelayCommand CmdCancelCategory
        {
            get
            {
                return _cmdCancelCategory ?? (_cmdCancelCategory = new RelayCommand(obj =>
                {
                    SelectedCategory = new Category();
                    _setCategoryState(ViewState.view);
                }));
            }
        }
        public RelayCommand CmdSaveCategory
        {
            get
            {
                return _cmdSaveCategory ?? (_cmdSaveCategory = new RelayCommand(obj =>
                {
                    Data.AddCategory(SelectedCategory);
                    DataKeeper.Save(Data);
                    _setCategoryState(ViewState.view);
                    SelectedCategory = new Category();
                }));
            }
        }

        private void _setCategoryState(ViewState state)
        {
            switch (state)
            {
                case ViewState.view:
                    CmdAddCategory.IsExecutable = true;
                    CmdRemoveCategory.IsExecutable = true;
                    CmdCancelCategory.IsExecutable = false;
                    CmdSaveCategory.IsExecutable = false;
                    IsSelectedListCategory = true;
                    break;
                case ViewState.edit:
                    CmdAddCategory.IsExecutable = false;
                    CmdRemoveCategory.IsExecutable = false;
                    CmdCancelCategory.IsExecutable = true;
                    CmdSaveCategory.IsExecutable = true;
                    IsSelectedListCategory = false;
                    break;
            }
        }
        #endregion

        #region Product
        private Product _selectedProduct;
        private RelayCommand _cmdAddProduct;
        private RelayCommand _cmdRemoveProduct;
        private RelayCommand _cmdCancelProduct;
        private RelayCommand _cmdSaveProduct;
        private bool _isSelectedListProduct;

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
        public bool IsSelectedListProduct
        {
            get
            {
                return _isSelectedListProduct;
            }
            set
            {
                _isSelectedListProduct = value;
                OnPropertyChanged(nameof(IsSelectedListProduct));
            }
        }
        public RelayCommand CmdAddProduct
        {
            get
            {
                return _cmdAddProduct ?? (_cmdAddProduct = new RelayCommand(obj =>
                {
                    SelectedProduct = new Product();
                    _setProductState(ViewState.edit);
                }));
            }
        }
        public RelayCommand CmdRemoveProduct
        {
            get
            {
                return _cmdRemoveProduct ?? (_cmdRemoveProduct = new RelayCommand(obj =>
                {
                    Data.DelProduct(SelectedProduct);
                }));
            }
        }
        public RelayCommand CmdCancelProduct
        {
            get
            {
                return _cmdCancelProduct ?? (_cmdCancelProduct = new RelayCommand(obj =>
                {
                    SelectedProduct = new Product();
                    _setProductState(ViewState.view);
                }));
            }
        }
        public RelayCommand CmdSaveProduct
        {
            get
            {
                return _cmdSaveProduct ?? (_cmdSaveProduct = new RelayCommand(obj =>
                {
                    Data.AddProduct(SelectedProduct);
                    DataKeeper.Save(Data);
                    _setProductState(ViewState.view);
                    SelectedProduct = new Product();
                }));
            }
        }

        private void _setProductState(ViewState state)
        {
            switch (state)
            {
                case ViewState.view:
                    CmdAddProduct.IsExecutable = true;
                    CmdRemoveProduct.IsExecutable = true;
                    CmdCancelProduct.IsExecutable = false;
                    CmdSaveProduct.IsExecutable = false;
                    IsSelectedListProduct = true;
                    break;
                case ViewState.edit:
                    CmdAddProduct.IsExecutable = false;
                    CmdRemoveProduct.IsExecutable = false;
                    CmdCancelProduct.IsExecutable = true;
                    CmdSaveProduct.IsExecutable = true;
                    IsSelectedListProduct = false;
                    break;
            }
        }
        #endregion
        private void _initState()
        {
            _setUserState(ViewState.view);
            _setPositionState(ViewState.view);
            _setCategoryState(ViewState.view);
            _setProductState(ViewState.view);
        }
    }
}
