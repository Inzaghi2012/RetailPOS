﻿using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Collections.Generic;
using RetailPOS.Utility;
using System.Windows;

namespace RetailPOS.ViewModel
{
    public partial class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        /// <summary>
        /// To open the product popup
        /// </summary>
        public RelayCommand<object> ShowProductCommand { get; private set; }
        
        public RelayCommand OpenFirstPopupCommand { get; private set; }
        public RelayCommand OpenLooseCatPopupCommand { get; private set; }
        public RelayCommand<ProductCategoryDTO> FillProductCommand { get; private set; }
        public RelayCommand RefershListBoxCommand { get; private set; }

        public IList<ProductDTO> LstSearchProduct { get; private set; }
        public ObservableCollection<ProductCategoryDTO> lstLooseCategories { get; private set; }

        private ObservableCollection<ProductCategoryDTO> _lstCategories;        
        private ObservableCollection<ProductDTO> _lstProduct;
        //private ProductDTO _selectedProduct;

        private bool _firstPopupIsOpen;
        private bool _OpenLooseCatPopupIsOpen;
        private bool _IsProductPopupOpen;

        #endregion

        #region Public Properties

        //public ProductDTO SelectedProduct
        //{
        //    get { return _selectedProduct; }
        //    set
        //    {
        //        _selectedProduct = value;
        //        RaisePropertyChanged("SelectedProduct");
        //    }
        //}

        public ObservableCollection<ProductCategoryDTO> lstCategories
        {
            get { return _lstCategories; }
            set
            {
                _lstCategories = value;
                RaisePropertyChanged("lstCategories");
            }
        }

        public ObservableCollection<ProductDTO> LstProduct
        {
            get { return _lstProduct; }
            set
            {
                _lstProduct = value;
                RaisePropertyChanged("LstProduct");
            }
        }

        public bool OpenLooseCatPopupIsOpen
        {
            get { return _OpenLooseCatPopupIsOpen; }
            set
            {
                _OpenLooseCatPopupIsOpen = value;
                RaisePropertyChanged("OpenLooseCatPopupIsOpen");
            }
        }

        public bool FirstPopupIsOpen
        {
            get { return _firstPopupIsOpen; }
            set
            {
                _firstPopupIsOpen = value;
                RaisePropertyChanged("FirstPopupIsOpen");
            }
        }

        public bool IsProductPopupOpen
        {
            get { return _IsProductPopupOpen; }
            set
            {
                _IsProductPopupOpen = value;
                RaisePropertyChanged("IsProductPopupOpen");
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        //public ProductGridViewModel()
        //{
        //    lstCategories = new ObservableCollection<ProductCategoryDTO>();
        //    lstLooseCategories = new ObservableCollection<ProductCategoryDTO>();
        //    LstProduct = new ObservableCollection<ProductDTO>();
        //    LstSearchProduct = new List<ProductDTO>();

        //    Mediator.Register("CloseProductPopUpWindow", OnCloseProductPopUpWindow);

        //    AddCategories();
        //    AddLooseCategories();
        //    FillCommonProducts();
        //    GetSearchAttributes();

        //    ShowProductCommand = new RelayCommand<object>(OnOpenProductPopUp);

        //    FillProductCommand = new RelayCommand<ProductCategoryDTO>(FillProducts);
        //    OpenFirstPopupCommand = new RelayCommand(OpenFirstPopupClick);
        //    OpenLooseCatPopupCommand = new RelayCommand(OpenLooseCatPopupClick);
        //    RefershListBoxCommand = new RelayCommand(RefereshListBox);
        //}

        #endregion

        #region Private Methods
        
        private void OnCloseProductPopUpWindow(object args)
        {
            IsProductPopupOpen = false;
        }

        /// <summary>
        /// Adds the loose categories.
        /// </summary>
        private void AddLooseCategories()
        {
            lstLooseCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                         select item);
        }

        /// <summary>
        /// Refereshes the list box.
        /// </summary>
        private void RefereshListBox()
        {
            lstCategories.Clear();
            AddCategories();
        }

        /// <summary>
        /// Fills the products.
        /// </summary>
        /// <param name="productCategory">The product category.</param>
        private void FillProducts(ProductCategoryDTO productCategory)
        {
            LstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetProductByCategory(productCategory.Id)
                                                                         select item);
            OpenLooseCatPopupIsOpen = false;
            FirstPopupIsOpen = false;
        }

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        private void FillCommonProducts()
        {
            LstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetCommonProduct() 
                                                                          select item);
        }

        /// <summary>
        /// Opens the first popup click.
        /// </summary>
        private void OpenFirstPopupClick()
        {
            FirstPopupIsOpen = true;
        }

        /// <summary>
        /// Opens the loose cat popup click.
        /// </summary>
        private void OpenLooseCatPopupClick()
        {
            OpenLooseCatPopupIsOpen = true;
        }

        /// <summary>
        /// Adds the categories.
        /// </summary>
        private void AddCategories()
        {
            try
            {
                lstCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                             select item);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Fills the list search.
        /// </summary>
        /// TODO --- Search the place where its used
        //private void GetSearchAttributes()
        //{
        //    LstSearchProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
        //                                                            select item).ToList();
        //}

        #endregion

        #region ShowProduct.xmal

        /// <summary>
        /// To bind Grid on selected item
        /// </summary>ShowProductCommand
        private void BindGrid(object selectedProduct)
        {
            SetSelectedProduct(selectedProduct);
            BindProductDetails(selectedProduct);
        }

        #endregion
    }
}