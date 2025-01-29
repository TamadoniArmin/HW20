using System.ComponentModel.DataAnnotations;
using App.Domain.Core.MoayeneFani.Cars.Enum;

namespace APIEndPoint.Models
{
    public class ModelCar
    {
        [Required (ErrorMessage ="نام خودرو نمیتواند خالی باشد")]
        [StringLength (10,ErrorMessage ="نام خودرو باید حداکثر 10 کاراکتر باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage ="شرکت سازنده باید مشخص باشد")]
        public CompanyEnum Company { get; set; }
    }
}
