using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.DataTransferObjects.Invoice
{
  public   class InvoicesDTO:BaseDTO
    {
      public int Id { get; set; }
      public int customer_id { get; set; }
      public string invoicenum { get; set; }
      public Nullable<DateTime> date { get; set; }
      public Nullable<DateTime> duedate { get; set; }
      public DateTime datepaid { get; set; }
      public decimal subtotal { get; set; }
      public decimal credit { get; set; }
      public decimal tax { get; set; }
      public decimal tax2 { get; set; }
      public decimal delivery_charge { get; set; }
      public decimal discount { get; set; }
      public decimal total { get; set; }
      public decimal balance { get; set; }
      public decimal taxrate { get; set; }
      public decimal taxrate2 { get; set; }
      public Nullable<decimal> discount_rate { get; set; }
      public string promotional_offer_code { get; set; }
      public string status { get; set; }
      public string paymentmethod { get; set; }
      public Nullable<int> notes { get; set; }
      public IList<InvoiceItemsDTO> InvoiceItems { get; set; }
    }
}
