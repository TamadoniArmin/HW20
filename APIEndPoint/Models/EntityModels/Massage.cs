namespace APIEndPoint.Models.EntityModels
{
    public class Massage
    {
        public bool Result { get; set; }
        public string? ErrorMassage { get; set; }
        public Massage(bool Res,string? Massage)
        {
            Result = Res;
            ErrorMassage = Massage;
        }
    }
}
