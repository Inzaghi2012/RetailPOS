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
    public partial class user : EntityBase
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual string Password
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> IsActive
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<staff> staffs
        {
            get
            {
                if (_staffs == null)
                {
                    var newCollection = new FixupCollection<staff>();
                    newCollection.CollectionChanged += Fixupstaffs;
                    _staffs = newCollection;
                }
                return _staffs;
            }
            set
            {
                if (!ReferenceEquals(_staffs, value))
                {
                    var previousValue = _staffs as FixupCollection<staff>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupstaffs;
                    }
                    _staffs = value;
                    var newValue = value as FixupCollection<staff>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupstaffs;
                    }
                }
            }
        }
        private ICollection<staff> _staffs;

        #endregion
        #region Association Fixup
    
        private void Fixupstaffs(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (staff item in e.NewItems)
                {
                    item.user = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (staff item in e.OldItems)
                {
                    if (ReferenceEquals(item.user, this))
                    {
                        item.user = null;
                    }
                }
            }
        }

        #endregion
    }
}
