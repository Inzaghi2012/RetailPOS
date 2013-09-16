using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.Invoice;
using RetailPOS.CommonLayer.DataTransferObjects.Invoice;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Invoice
{
   public  class InvoiceServiceImpl : InvoiceBaseService,IInvoiceService
    {
       IList<InvoicesDTO> IInvoiceService.GetAllInvoices()
       {
           IList<InvoicesDTO> lstInvoice = new List<InvoicesDTO>();
           ObjectMapper.Map(base.InvoiceRepository.GetList().ToList(), lstInvoice);
           return lstInvoice;
       }
        bool IInvoiceService.SaveInvoiceDetail(InvoicesDTO invoiceDetail)
        {
            invoice invoiceEntity = new invoice();
            ObjectMapper.Map(invoiceDetail, invoiceEntity);
            return InvoiceRepository.Save(invoiceEntity);
        }
        ///// <summary>
        ///// To save the invoice item detail on print button
        ///// </summary>
        ///// <param name="invoiceItemDetail"></param>
        ///// <returns></returns>
        //bool IInvoiceService.SaveInvoiceItemDetail(InvoiceItemsDTO invoiceItemDetail)
        //{
        //    invoiceitem invoiceItemEntity = new invoiceitem();
        //    ObjectMapper.Map(invoiceItemDetail, invoiceItemEntity);
        //    return InvoiceItemRepository.Save(invoiceItemEntity);
        //}
    }
}
