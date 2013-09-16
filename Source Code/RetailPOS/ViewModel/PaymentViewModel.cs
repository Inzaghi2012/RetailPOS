using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using System.Collections.ObjectModel;

namespace RetailPOS.ViewModel
{
    public partial class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member
        /// <summary>
        /// To get the list of invoice detail
        /// </summary>
        private IList<InvoicesDTO> _lstInvoice;
        private string _invoiceNo;
        public RelayCommand SaveInvoices { get; private set; }
        #endregion

        #region Public Properties
        public IList<InvoicesDTO> LstInvoice
        {
            get { return _lstInvoice; }
            set
            {
                _lstInvoice = value;
                RaisePropertyChanged("LstInvoice");
            }
        }
        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                _invoiceNo = value;
                RaisePropertyChanged("InvoiceNo");
            }
        }
        #endregion
       
        #region Private Methods
        //To get the invoice detail list
        private void GetInvoiceListDetail()
        {
            LstInvoice = new ObservableCollection<InvoicesDTO>(from item in ServiceFactory.ServiceClient.GetAllInvoices()
                                                               orderby item.invoicenum descending
                                                               select item).ToList();
            var x = LstInvoice.FirstOrDefault().invoicenum;
            int y = int.Parse(x) + 1;
            InvoiceNo = y.ToString();                                 
        }
        ///To save the sale(invoice) in invoices table          
        private void SaveInvoiceDetail()
        {
            if (LstProductDetails.Count > 0)
            {
                var SaveInvoiceData = InitializeInvoce();
                ServiceFactory.ServiceClient.SaveInvoiceDetail(SaveInvoiceData);
                ResetControls();
            }
        }
        private InvoicesDTO InitializeInvoce()
        {
            return new InvoicesDTO
            {
                customer_id=4,
                invoicenum = InvoiceNo,
                date=DateTime.Now,
                subtotal=Total,
                credit=(decimal)0.00,
                tax = (decimal)0.00,
                tax2 = (decimal)0.00,
                delivery_charge = (decimal)0.00,
                discount=Discount,
                total=Total,
                balance=(decimal)0.00,
                taxrate = (decimal)0.00,
                taxrate2 = (decimal)0.00,
                status="",
                InvoiceItems=InitializeInvoiceItems(),
            };
        }
        private List<InvoiceItemsDTO> InitializeInvoiceItems()
        {
            List<InvoiceItemsDTO> lstInvoiceItemDetail = (from item in LstProductDetails
                                                          select new InvoiceItemsDTO
                                                          {                                                             
                                                              customer_id = 4,
                                                              type = "OrderInvoice",
                                                              description = (string)item.Quantity.ToString() + item.Name + item.Weight,
                                                              taxed = 0
                                                          }).ToList();
            return lstInvoiceItemDetail;
           
        }
        #endregion
    }
}
