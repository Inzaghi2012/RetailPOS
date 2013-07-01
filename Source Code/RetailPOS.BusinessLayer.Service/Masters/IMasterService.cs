﻿#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

#endregion

namespace RetailPOS.BusinessLayer.Service.Masters
{
    public interface IMasterService
    {
        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        IList<CountryDTO> GetCountryDetails();
    }
}