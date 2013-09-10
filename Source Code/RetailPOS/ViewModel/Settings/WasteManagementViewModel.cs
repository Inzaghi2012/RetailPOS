﻿#region Using directives

using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;

#endregion

namespace RetailPOS.ViewModel.Settings
{
    public class WasteManagementViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Declare Public and Private Data member

        public ObservableCollection<ProductDTO> LstProduct { get; set; }

        public RelayCommand SetWeightToVisibile { get; private set; }
        public RelayCommand SetWeightToInVisibile { get; private set; }
        public RelayCommand SaveWasteManagementCommand { get; private set; }
        public RelayCommand CancelWasteManagementCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand CancelSearchCommand { get; private set; }

        private IList<WasteManagementDTO> _lstWasteManagement;
        private ProductDTO _selectedProduct;

        private Visibility _isWeightVisible;
        private string _name;
        private string _barCode;
        private string _description;
        private decimal _weight;
        private decimal _quantity;
        private int _productId;

        #endregion

        #region Public Properties

        public IList<WasteManagementDTO> LstWasteManagement
        {
            get { return _lstWasteManagement; }
            set
            {
                _lstWasteManagement = value;
                RaisePropertyChanged("LstWasteManagement");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string BarCode
        {
            get { return _barCode; }
            set
            {
                _barCode = value;
                RaisePropertyChanged("BarCode");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        public decimal Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        public Visibility IsWeightVisible
        {
            get { return _isWeightVisible; }
            set
            {
                _isWeightVisible = value;
                RaisePropertyChanged("IsWeightVisible");
            }
        }

        public ProductDTO SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (value != null)
                {
                    _selectedProduct = value;
                    RaisePropertyChanged("SelectedProduct");

                    BindProductDetails();
                }
            }
        }

        #endregion
        
        #region Constructor

        public WasteManagementViewModel()
        {
            LstProduct = new ObservableCollection<ProductDTO>();

            SetWeightToVisibile = new RelayCommand(ShowWeight);
            SetWeightToInVisibile = new RelayCommand(HideWeight);
            SaveWasteManagementCommand = new RelayCommand(SaveWasteManagement);
            CancelWasteManagementCommand = new RelayCommand(CancelSetting);
            SearchCommand = new RelayCommand(SearchWasteManagement);
            CancelSearchCommand = new RelayCommand(CancelSearch);

            ////Get waste management details from database
            GetWasteManagementDetails(string.Empty);

            GetProductDetails();

            HideWeight();
        }

        #endregion

        private void BindProductDetails()
        {
            ProductDTO selectedProduct = SelectedProduct;
            BarCode = selectedProduct.BarCode;
            Description = selectedProduct.Description;
        }

        private void GetProductDetails()
        {
            LstProduct = new ObservableCollection<ProductDTO>(ServiceFactory.ServiceClient.GetAllProducts());
        }

        private void CancelSetting()
        {
            //WasteManagementViewModel viewModel = new WasteManagementViewModel();
            ClearControls();
        }

        private void CancelSearch()
        {
            ClearControls();

            ////Get waste management details from database
            GetWasteManagementDetails(string.Empty);
        }

        private void SearchWasteManagement()
        {
            ////Get waste management details from database
            GetWasteManagementDetails(Name);
        }

        ////Get waste management details from database
        private void GetWasteManagementDetails(string name)
        {
            LstWasteManagement = ServiceFactory.ServiceClient.GetWasteManagementDetails();

            if(!string.IsNullOrEmpty(name))
            {
                LstWasteManagement = (from item in LstWasteManagement
                                      where item.ProductName == name
                                      select item).ToList();
            }
        }

        private void SaveWasteManagement()
        {
            if (IsValid())
            {
                var wasteManagementDetails = InitializeWasteManagementDetails();
                ServiceFactory.ServiceClient.SaveWasteManagement(wasteManagementDetails);

                ////Get waste management details from database
                GetWasteManagementDetails(string.Empty);

                ClearControls();
            }
        }

        private WasteManagementDTO InitializeWasteManagementDetails()
        {
            return new WasteManagementDTO
            {
                Id = 0,
                ProductId = SelectedProduct.Id,
                Quantity = Quantity,
                Weight = Weight,
                CreatedDate = DateTime.Now
            };
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            SelectedProduct = null;
            Quantity = 0;
            Weight = 0;
            BarCode = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
        }

        private void ShowWeight()
        {
            IsWeightVisible = Visibility.Visible;
        }

        private void HideWeight()
        {
            IsWeightVisible = Visibility.Hidden;
        }

        #region Validation

        public bool IsValidating = false;

        public List<string> Errors = new List<string>();

        //To validate the field
        //Will check if fields are validated or not
        public bool IsValid()
        {
            IsValidating = true;
            Errors.Clear();
            try
            {
                RaisePropertyChanged(() => SelectedProduct);
                RaisePropertyChanged(() => BarCode);
                RaisePropertyChanged(() => Description);
                RaisePropertyChanged(() => Quantity);
                RaisePropertyChanged(() => Weight);
            }
            finally
            {
                if (Errors.Count > 0)
                {

                    IsValidating = false;
                    MessageBox.Show(string.Join(",", Errors));
                }
            }
            return (Errors.Count == 0);
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (!IsValidating) return result;
                Errors.Remove(columnName);
                if (IsWeightVisible == Visibility.Visible)
                {

                    switch (columnName)
                    {
                        case "SelectedProduct":
                            if (SelectedProduct == null)
                            {
                                result = " ProductName is required!";
                                break;
                            }
                            else
                            {
                                break;
                            }


                        case "BarCode": if (string.IsNullOrEmpty(BarCode))
                            {
                                result = " BarCode is required!";
                                break;
                            }
                            else
                            { break; }

                        case "Description":
                            if (string.IsNullOrEmpty(Description))
                            {
                                result = " Description is required!";
                                break;
                            }
                            else { break; }

                        case "Quantity":
                            if (Quantity <= 0)
                            {
                                result = " Quantity is required!";
                                break;
                            }
                            else { break; }

                        case "Weight":
                            if (Weight <= 0)
                            {
                                result = " Weight is required!";
                                break;
                            }
                            else { break; }



                    }
                }
                else
                {
                    switch (columnName)
                    {
                        case "SelectedProduct":
                            if (SelectedProduct == null)
                            {
                                result = " ProductName is required!";
                                break;
                            }
                            else
                            {
                                break;
                            }


                        case "BarCode": if (string.IsNullOrEmpty(BarCode))
                            {
                                result = " BarCode is required!";
                                break;
                            }
                            else
                            { break; }

                        case "Description":
                            if (string.IsNullOrEmpty(Description))
                            {
                                result = " Description is required!";
                                break;
                            }
                            else { break; }

                        case "Quantity":
                            if (Quantity <= 0)
                            {
                                result = " Quantity is required!";
                                break;
                            }
                            else { break; }
                    }
                }
                if (result != string.Empty) Errors.Add(result);
                return result;
            }
        }


        #endregion
    }
}