using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Windows;
using RetailPOS.View;
using System.Windows.Threading;
using System;
using System.Windows.Input;

namespace RetailPOS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public ObservableCollection<StaffDTO> lstUsers { get; private set; }
        //To get the detail of logged in user
        public ObservableCollection<StaffDTO> lstDetailLoginUser { get; private set; }
        //To get the order no of loggerd in user
        public ObservableCollection<OrderMasterDTO> OrderNoUser { get; private set; }
        public RelayCommand<StaffDTO> SelectUserCommand { get; private set; }
        public RelayCommand <object> LoginCommand { get; private set; }

        private string _fullName;
        private string _userName;
        private string _password;
        private bool _isEnabled;
        /// <summary>
        /// The _staff name
        /// </summary>
        private string _staffName;

        /// <summary>
        /// The _order no
        /// </summary>
        private string _orderNo;
        /// <summary>
        /// The _date time
        /// </summary>
        private string _dateTime;
        /// <summary>
        /// The UserId
        /// </summary>
        private int _userId;
        private Visibility _messageVisibility;
            
        #endregion

        #region Public Properties

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                RaisePropertyChanged("FullName");
            }
        }

        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Visibility MessageVisibility
        {
            get { return _messageVisibility ; }
            set 
            { 
                _messageVisibility = value;
                RaisePropertyChanged("MessageVisibility");
            }
        }

        /// <summary>
        /// Gets or sets the name of the staff.
        /// </summary>
        /// <value>
        /// The name of the staff.
        /// </value>
        public string StaffName
        {
            get { return _staffName; }
            set
            {
                _staffName = value;
                RaisePropertyChanged("StaffName");
            }
        }


        /// <summary>
        /// Gets or sets the order no.
        /// </summary>
        /// <value>
        /// The order no.
        /// </value>
        public string OrderNo
        {
            get { return _orderNo; }
            set
            {
                _orderNo = value;
                RaisePropertyChanged("OrderNo");
            }
        }
        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public string DateTime
        {
            get { return _dateTime; }
            set
            {
                if (value != DateTime)
                {
                    _dateTime = value;
                    RaisePropertyChanged("DateTime");
                }
            }
        }
        ///Get or set the UserId
        public int UserId
        {
            get { return _userId; }
            set
            {             
                
                    _userId = value;
                    RaisePropertyChanged("UserId");
                
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            MessageVisibility = Visibility.Hidden;
            lstUsers = new ObservableCollection<StaffDTO>();
            GetUsers();
            lstDetailLoginUser = new ObservableCollection<StaffDTO>();
            GetDetailLoginUser();
            OrderNoUser = new ObservableCollection<OrderMasterDTO>();
            GetOrderNoOfUser();
            SelectUserCommand = new RelayCommand<StaffDTO>(SelectedUserName);
            LoginCommand = new RelayCommand<object>(ValidateUserCredentials);
        }

        #endregion

        /// <summary>
        /// Checks the user exists.
        /// </summary>
        private void ValidateUserCredentials(object passwordDetails)
        {
            var passwordBox = passwordDetails as PasswordBox;
            Password = passwordBox.Password;

            bool isUserValidate = ServiceFactory.ServiceClient.ValidateUserCredentials(UserName, Password);
            
            if (!isUserValidate)
            {
                MessageVisibility = Visibility.Visible;
            }
            else
            {
                ////Sets the message visibility as hidden
                MessageVisibility = Visibility.Hidden;
                GetDetailLoginUser();
                //Name of the user
                StaffName = lstDetailLoginUser.FirstOrDefault().UserName;
                UserId = lstDetailLoginUser.FirstOrDefault().Id;             
                OrderNo = OrderNoUser.LastOrDefault().Order_No;
                DateTime = GetCurrentDateTime();
                ////Opens up main window
                var mainWindow = new Dashboard();
                mainWindow.Show();             
                ////Closes login window
                LoginWindow._LoginWindow.Close();
            }
        }

        /// <summary>
        /// Selecteds the name of the user.
        /// </summary>
        /// <param name="userDT">The user DT.</param>
        private void SelectedUserName(StaffDTO userDetails)
        {
            UserName = userDetails.UserName;
            StaffName = userDetails.UserName;
            this.DateTime = GetCurrentDateTime();
            //OrderNo=u
        }

        /// <summary>
        /// Get the users.
        /// </summary>
        private void GetUsers()
        {
           lstUsers = new ObservableCollection<StaffDTO>(from item in ServiceFactory.ServiceClient.GetStaffDetails()
                                                          select item);            
        }
        /// <summary>
        /// To get the detail of logeed in user
        /// </summary>
        private void GetDetailLoginUser()
        {
            lstDetailLoginUser = new ObservableCollection<StaffDTO>(from item in ServiceFactory.ServiceClient.GetUserDetail(UserName)
                                                                    select item);
        }
        /// <summary>
        /// Gets the current date time.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDateTime()
        {
            try
            {
                DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
                return DateTime;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            this.DateTime = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToString(" HH:mm tt");

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        ///To get the order No of Loggerd in user
        private void GetOrderNoOfUser()
        {
            OrderNoUser = new ObservableCollection<OrderMasterDTO>(from item in ServiceFactory.ServiceClient.GetOrderNoOfUser()
                                                                       select item);
        }

    }
}