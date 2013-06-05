﻿#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Users;
using RetailPOS.CommonLayer.DataTransferObjects;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Users
{
    public class StaffServiceImpl : UserBaseService, IStaffService
    {
        /// <summary>
        /// Get all active Staff details
        /// </summary>
        /// <returns>returns list of active staff users</returns>
        IList<StaffDTO> IStaffService.GetStaffDetails()
        {
            IList<StaffDTO> lstUserName = (from item in base.StaffRepository.GetList(item => item.status_id == 1).ToList()
                                           select new StaffDTO
                                           {
                                               FullName = item.first_name + " " + item.last_name,
                                               UserName = item.user == null ? string.Empty : item.user.UserName
                                           }).ToList();

            return lstUserName;
        }
    }
}