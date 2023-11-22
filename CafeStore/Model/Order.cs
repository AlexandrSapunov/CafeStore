﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeStore.Model
{
    public class Order:BaseVM
    {
        private User _salesman;
        private DateTime _dateOfPurchase;
        private int _sum;

        public User Salesman
        {
            get
            {
                return _salesman;
            }
            set
            {
                _salesman = value;
                OnPropertyChanged(nameof(Salesman));
            }
        }
        public DateTime DateOfPurchase
        {
            get
            {
                return _dateOfPurchase;
            }
            set
            {
                _dateOfPurchase = value;
                OnPropertyChanged(nameof(DateOfPurchase));
            }
        }
        public int Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }
        public ObservableCollection<Product.Product> Products { get; set; }

        public Order()
        {
            Products = new ObservableCollection<Product.Product>();
        }

    }
}
