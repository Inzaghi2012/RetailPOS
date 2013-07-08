﻿using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

namespace RetailPOS.BusinessLayer.ServiceImpl.Setting
{
    public class SettingBaseService
    {
        [Dependency]
        public IGenericRepository<shop_info> ShopSettingRepository
        {
            get;
            set;
        }
        /// <summary>
        /// Property to inject the persistence layer implementation class for customers
        /// </summary>
        [Dependency]
        public IGenericRepository<customer> CustomerRepository { get; set; }
    }
}