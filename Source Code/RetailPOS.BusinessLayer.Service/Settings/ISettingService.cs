﻿#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;

#endregion

namespace RetailPOS.BusinessLayer.Service.Settings
{
    public interface ISettingService
    {
        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveShopSetting(ShopSettingDTO shopSettingDetails);

        /// <summary>
        /// Retrieves available PromotionalOffer details from database
        /// </summary>
        /// <returns>returns list of PromotioanlOffer else empty list</returns>
        IList<PromotionalOfferDTO> GetPromotionalOfferDetail();

        /// <summary>
        /// Get waste management details from database
        /// </summary>
        /// <returns>returns list of Waste management details else empty list</returns>
        IList<WasteManagementDTO> GetWasteManagementDetails();

        /// <summary>
        /// Save Waste management details in database
        /// </summary>
        /// <param name="wasteManagementDetails">WasteManagement object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveWasteManagement(WasteManagementDTO wasteManagementDetails);

        /// <summary>
        /// Save Promotional offer details in database
        /// </summary>
        /// <param name="promitonalOfferDetails">Promotional offer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SavePromotionalOffer(PromotionalOfferDTO promitonalOfferDetails);

        /// <summary>
        /// Retrieves available Purchase History details from database
        /// </summary>
        /// <returns>returns list of Purchase History else empty list</returns>
        IList<PurchaseHistoryDTO> GetPurchaseHistoryDetails();
    }
}