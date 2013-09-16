using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.DataTransferObjects.Invoice
{
   public  class InvoiceItemsDTO:BaseDTO
    {
       public int invoice_id { get; set; }
       public int customer_id { get; set; }
       public string type { get; set; }
       public Nullable<int> relid { get; set; }
       public string description { get; set; }
       public decimal amount { get; set; }
       public int taxed { get; set; }
    }
}
