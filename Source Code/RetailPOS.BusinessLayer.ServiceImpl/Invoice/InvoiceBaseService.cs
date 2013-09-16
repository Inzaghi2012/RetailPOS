using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;
using Microsoft.Practices.Unity;

namespace RetailPOS.BusinessLayer.ServiceImpl.Invoice
{
   public  class InvoiceBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for invoice
        /// </summary>
        [Dependency]
        public IGenericRepository<invoice> InvoiceRepository { get; set; }
        /// <summary>
        /// Property to inject the persistence layer implementation class for invoiceItem
        /// </summary>
        [Dependency]
        public IGenericRepository<invoiceitem> InvoiceItemRepository { get; set; }

    }
}
