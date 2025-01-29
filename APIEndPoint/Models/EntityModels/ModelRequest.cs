using System.ComponentModel.DataAnnotations;

namespace APIEndPoint.Models
{
    public class ModelRequest
    {
        [Required(ErrorMessage ="نام مالک خودرو الزامیست")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage ="کد ملی مالک خودرو الزامیست")]
        [StringLength(10,ErrorMessage ="کد ملی باید شامل 10 عدد باشد")]
        public string NationalCode { get; set; }
        [Required(ErrorMessage ="پلاک خودرو الزامیست")]
        public string Plate { get; set; }
        //public string CarName { get; set; }
        [Required(ErrorMessage ="کد خودرو الزامیست")]
        public int CarId { get; set; }
        [Required(ErrorMessage ="پر کردن این فیلد الزامیست")]
        public string City { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامیست")]
        public string Street { get; set; }
        //public CompanyEnum Company { get; set; }
        [Required(ErrorMessage ="وارد کردن سال تولید خودرو الزامیست")]
        public DateOnly ProductionDate { get; set; }
        [Required(ErrorMessage = "انتخاب روز معاینه الزامیست")]
        public DateTime Date { get; set; }
        //public DateTime? Date { get; set; }
        //public bool Confirmation { get; set; } = false;
        public DateTime TimeOfRequest { get; set; }
    }
}
