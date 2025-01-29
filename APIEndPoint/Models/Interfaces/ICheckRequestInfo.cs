using APIEndPoint.Models.EntityModels;

namespace APIEndPoint.Models.Interfaces
{
    public interface ICheckRequestInfo
    {
        public Massage CheckNationalCode(string NationalCode);
        public Massage CheckPlate(string Plate);
        public Massage CheckProductionDate(DateOnly date);
        public Massage CheckExist(string Ownername, string NationalCode, string Plate);
    }
}
