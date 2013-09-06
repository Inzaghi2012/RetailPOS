namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class TownCityDTO : BaseDTO
    {
        public short Id { get; set; }
        public string towncity { get; set; }
        public int countryID { get; set; }
    }
}