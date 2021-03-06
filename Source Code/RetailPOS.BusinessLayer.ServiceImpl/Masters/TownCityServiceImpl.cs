﻿#region Using directives

using System.Collections.Generic;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public partial class MasterServiceImpl
    {
        /// <summary>
        /// Retrieves available Town/City details from database
        /// </summary>
        /// <returns>returns list of Town/City else empty list</returns>
        IList<TownCityDTO> IMasterService.GetTownCityDetails(int countryId)
        {
            IList<TownCityDTO> lstTownCity = new List<TownCityDTO>();
            ObjectMapper.Map(base.TownCityRepository.GetList(item => item.CountryId == countryId), lstTownCity);
            return lstTownCity;
        }
    }
}