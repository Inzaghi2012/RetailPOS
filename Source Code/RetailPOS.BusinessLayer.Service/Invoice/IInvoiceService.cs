using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Invoice;

namespace RetailPOS.BusinessLayer.Service.Invoice
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Get all Invoice detail  
        /// </summary>
        /// <returns>returns list of all invoices present in database</returns>
        IList<InvoicesDTO> GetAllInvoices();
        /// <summary>
        /// To save the invoice detail on print button
        /// </summary>
        /// <param name="invoiceDetail"></param>
        /// <returns></returns>
        bool SaveInvoiceDetail(InvoicesDTO invoiceDetail);
        ///// <summary>
        ///// To save the invoice item detail on print button
        ///// </summary>
        ///// <param name="invoiceItemDetail"></param>
        ///// <returns></returns>
        //bool SaveInvoiceItemDetail(InvoiceItemsDTO invoiceItemDetail);
    }
}
