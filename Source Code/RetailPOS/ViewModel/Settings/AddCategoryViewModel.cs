#region Using directives

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System;

#endregion

namespace RetailPOS.ViewModel
{
    public class AddCategoryViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Declare Public and Private Data member

        public RelayCommand SaveCategoryCommand { get; private set; }
        public RelayCommand CancelCategoryCommand { get; private set; }
        public RelayCommand SearchCategoryCommand { get; private set; }
        public RelayCommand CancelSearchCommand { get; private set; }

        private IList<ProductCategoryDTO> _lstCategoryName { get; set; }

        /// <summary>
        /// The _staff name
        /// </summary>
        private string _name;

        /// <summary>
        /// The _order no
        /// </summary>
        private string _description;

        /// <summary>
        /// The _date time
        /// </summary>
        private string _selectedColor;

        /// <summary>
        /// The _sort order
        /// </summary>
        private int _sortOrder;

        //To make Error Message  textblock visible if null value is passed
        private Visibility _isCategoryNameVisible;
        private Visibility _isCategoryDiscriptionVisible;
        private Visibility _isColorVisible;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets list of categories for search items
        /// </summary>
        /// <value>
        /// The list of categories.
        /// </value>
        public IList<ProductCategoryDTO> LstCategoryName
        {
            get { return _lstCategoryName; }
            set
            {
                _lstCategoryName = value;
                RaisePropertyChanged("LstCategoryName");
            }
        }

        /// <summary>
        /// Gets or sets name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        /// <value>
        /// The category description.
        /// </value>
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the selected color.
        /// </summary>
        /// <value>
        /// The selected color.
        /// </value>
        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                if (value != string.Empty)
                {
                    _selectedColor = value;
                    RaisePropertyChanged("SelectedColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get { return _sortOrder; }
            set
            {
                _sortOrder = value;
                RaisePropertyChanged("SortOrder");
            }
        }

        /// <summary>
        /// Gets or sets visibility of error message categories for name
        /// </summary>
        /// <value>
        /// The visibility of error message categories.
        /// </value>
        public Visibility IsCategoryNameVisible
        {
            get { return _isCategoryNameVisible; }
            set
            {
                _isCategoryNameVisible = value;
                RaisePropertyChanged("IsCategoryNameVisible");
            }
        }

        /// <summary>
        /// Gets or sets visibility of error message categories for Description
        /// </summary>
        /// <value>
        /// The visibility of error message categories.
        /// </value>
        public Visibility IsCategoryDiscriptionVisible
        {
            get { return _isCategoryDiscriptionVisible; }
            set
            {
                _isCategoryDiscriptionVisible = value;
                RaisePropertyChanged("IsCategoryDiscriptionVisible");
            }
        }
        /// <summary>
        /// Gets or sets visibility of error message categories for color
        /// </summary>
        /// <value>
        /// The visibility of error message categories.
        /// </value>
        public Visibility IsColorVisible
        {
            get { return _isColorVisible; }
            set
            {
                _isColorVisible = value;
                RaisePropertyChanged("IsColorVisible");
            }
        }
     

        #endregion

        #region Constructor

        public AddCategoryViewModel()
        {
            LstCategoryName = new List<ProductCategoryDTO>();

            SaveCategoryCommand = new RelayCommand(SaveCategory);
            CancelCategoryCommand = new RelayCommand(CancelCategorySetting);
            SearchCategoryCommand = new RelayCommand(SearchCategoryByName);
            CancelSearchCommand = new RelayCommand(CancelSearch);

            GetCategoryDetails(string.Empty);
            IsCategoryDiscriptionVisible = Visibility.Collapsed;
            IsCategoryNameVisible = Visibility.Collapsed;
            IsColorVisible = Visibility.Collapsed;

            ////Clear the controls
            ClearControls();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            Name = string.Empty;
            Description = string.Empty;
            SelectedColor = string.Empty;
            IsCategoryDiscriptionVisible = Visibility.Collapsed;
            IsCategoryNameVisible = Visibility.Collapsed;
            IsColorVisible = Visibility.Collapsed;
        }

        /// <summary>
        /// Save category deatils in database
        /// </summary>
        private void SaveCategory()
        {
            if (IsValid())
            {
                var categoryDetails = InitializeCategoryDetails();
                ServiceFactory.ServiceClient.SaveCategoryDetails(categoryDetails);

                GetCategoryDetails(string.Empty);

                ////Clear the controls
                ClearControls();
            }
        }

        /// <summary>
        /// Initializes Category details with values from controls
        /// </summary>
        /// <returns></returns>
        private ProductCategoryDTO InitializeCategoryDetails()
        {
            return new ProductCategoryDTO
            {
                Name = Name,
                Description = Description,
                Color = SelectedColor
            };
        }

        private void SearchCategoryByName()
        {
            GetCategoryDetails(Name);
        }

        /// <summary>
        /// Cancels the current operation
        /// </summary>
        private void CancelSearch()
        {
            Name = string.Empty;
            GetCategoryDetails(string.Empty); 
        }

        private void CancelCategorySetting()
        {
        }

        /// <summary>
        /// Get category details from database
        /// </summary>
        /// <param name="categoryName">Category name to filter records</param>
        private void GetCategoryDetails(string categoryName)
        {
            LstCategoryName = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                      select item).ToList();
            if (!string.IsNullOrEmpty(categoryName))
            {
                LstCategoryName = LstCategoryName.Where(item => item.Name.Contains(categoryName)).ToList();
            }
        }

        #endregion

        #region Validation

        public bool IsValidating = false;

        public Dictionary<string, string> Errors = new Dictionary<string, string>();

        //To validate the field

        public bool IsValid()
        {
            IsValidating = true;
            try
            {
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => Description);
                RaisePropertyChanged(() => SelectedColor);
            }
            finally
            {
                if (Errors.Count > 0)
                {
                    IsValidating = false;
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
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                        {
                            IsCategoryNameVisible = Visibility.Visible;
                            result = " error!";
                            break;
                        }
                        else
                        {
                            IsCategoryNameVisible = Visibility.Collapsed;
                            break;
                        }
                    case "Description": if (string.IsNullOrEmpty(Description))
                        {
                            IsCategoryDiscriptionVisible = Visibility.Visible;
                            result = "error";
                            break;
                        }
                        else
                        {
                            IsCategoryDiscriptionVisible = Visibility.Collapsed;
                            break;
                        }
                    case "SelectedColor": if (string.IsNullOrEmpty(SelectedColor))
                        {
                            IsColorVisible = Visibility.Visible;
                            result = "error";
                            break;
                        }
                        else
                        {
                            IsColorVisible = Visibility.Collapsed;
                            break;
                        }
                }
                if (result != string.Empty) Errors.Add(columnName, result);
                return result;
            }
        }


        #endregion
    }
}