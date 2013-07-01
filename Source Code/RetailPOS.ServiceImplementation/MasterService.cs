﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        public IList<CountryDTO> GetCountryDetails()
        {
            return MasterService.GetCountryDetails();
        }
    }
}