//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RetailPOS.PersistenceLayer.Repository.Entities
{
    public partial class invoiceitem : EntityBase
    {
        #region Primitive Properties
    
        public virtual long id
        {
            get;
            set;
        }
    
        public virtual long invoice_id
        {
            get;
            set;
        }
    
        public virtual int customer_id
        {
            get;
            set;
        }
    
        public virtual string type
        {
            get;
            set;
        }
    
        public virtual Nullable<long> relid
        {
            get;
            set;
        }
    
        public virtual string description
        {
            get;
            set;
        }
    
        public virtual decimal amount
        {
            get;
            set;
        }
    
        public virtual int taxed
        {
            get;
            set;
        }

        #endregion
    }
}
