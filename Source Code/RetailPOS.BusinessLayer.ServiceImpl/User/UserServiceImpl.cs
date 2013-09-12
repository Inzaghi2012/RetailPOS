using RetailPOS.BusinessLayer.Service.User;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.Mapper;
using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
using System.Linq;

namespace RetailPOS.BusinessLayer.ServiceImpl.User
{
    public class UserServiceImpl : UserBaseService, IUserService
    {
        /// <summary>
        /// Validate user credentials by verifying from database
        /// </summary>
        /// <param name="userName">username to validate</param>
        /// <param name="password">password to validate</param>
        /// <returns>returns boolean value indicating whether user credentials are verified or not</returns>
        bool IUserService.ValidateUserCredentials(string userName, string password)
        {
            StaffDTO userDetails = new StaffDTO();
            ObjectMapper.Map(base.StaffRepository.GetSingle(item => item.username == userName ||item.email==userName
                && item.password == password), userDetails);

            bool result = userDetails.Id > 0 ? true : false;
            return result;
        }
        /// <summary>
        /// To get staff detail if it is a valid user
        /// </summary>
        /// <returns>returns Staff detail for </returns>
        IList<StaffDTO> IUserService.GetUserDetail(string userName)
        {
            IList<StaffDTO> userDetails = new List<StaffDTO>();
            ObjectMapper.Map(base.StaffRepository.GetList(item => item.username == userName), userDetails);
            return userDetails;
        }
        /// <summary>
        /// To get order no of user if it is a valid user
        /// </summary>
        /// <returns>returns order no for </returns>
        IList<OrderMasterDTO> IUserService.GetOrderNoOfUser()
        {
            IList<OrderMasterDTO> userDetails = new List<OrderMasterDTO>();
            ObjectMapper.Map(base.OrderMasterRepository.GetList().ToList(), userDetails);
            return userDetails;           
        }
    }
}