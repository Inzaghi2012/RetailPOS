using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Users: This service implementation class is used to get staff details from repository
        /// </summary>
        /// <returns>return list of product by category</returns>
        /// <remarks></remarks>
        public bool ValidateUserCredentials(string userName, string password)
        {
            return UserService.ValidateUserCredentials(userName, password);
        }
        /// <summary>
        /// To get staff detail if it is a valid user
        /// </summary>
        /// <returns>returns Staff detail for </returns>
      public  IList<StaffDTO> GetUserDetail(string userName)
        {
            return UserService.GetUserDetail(userName);
        }
        /// <summary>
        /// To get order no of user if it is a valid user
        /// </summary>
        /// <returns>returns order no for </returns>
      public IList<OrderMasterDTO> GetOrderNoOfUser()
      {
          return UserService.GetOrderNoOfUser();
      }
    }
}