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
    public partial class postcode : EntityBase
    {
        #region Primitive Properties
    
        public virtual int id
        {
            get;
            set;
        }
    
        public virtual string postcode1
        {
            get;
            set;
        }
    
        public virtual Nullable<short> LocalityId
        {
            get;
            set;
        }

        #endregion
    }
}
