using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Invoice;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Get all Invoice detail
        /// </summary>
        /// <returns>returns list of all invoices present in database</returns>
       public  IList<InvoicesDTO> GetAllInvoices()
        {
            return InvoiceService.GetAllInvoices();
        }
        /// Save Invoice details in database
        /// </summary>
        /// <param name="invoiceDetail">Invoice detail to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>

        public bool SaveInvoiceDetail(InvoicesDTO invoiceDetail)
        {
            return InvoiceService.SaveInvoiceDetail(invoiceDetail);
        }
    }
}
