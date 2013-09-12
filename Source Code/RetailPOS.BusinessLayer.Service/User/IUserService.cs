using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
namespace RetailPOS.BusinessLayer.Service.User
{
    public interface IUserService
    {
        /// <summary>
        /// Validate user credentials by verifying from database
        /// </summary>
        /// <returns>returns boolean value for </returns>
        bool ValidateUserCredentials(string userName, string password);
        /// <summary>
        /// To get staff detail if it is a valid user
        /// </summary>
        /// <returns>returns Staff detail for </returns>
        IList<StaffDTO> GetUserDetail(string userName);
        /// <summary>
        /// To get order no of user if it is a valid user
        /// </summary>
        /// <returns>returns order no for </returns>
        IList<OrderMasterDTO> GetOrderNoOfUser();
    }
}