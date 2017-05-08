using AspMVC5Training.Infrastructure.CustomAttribute;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Mvc;

namespace AspMVC5Training.ViewModel
{
    public class DataViewModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(2)]
        public string Name { get; set; }

        [IpV4(ErrorMessage ="注意寫這裡沒用")]
        public string IpV4 { get; set; }

        //[Remote("IpV6", "Verification", ErrorMessage = "IpV6有問題喔 請在檢查看看")]
        //[Remote("IpV6", "Valid", "Tools", ErrorMessage = "IpV6有問題喔 請在檢查看看")]
        [Remote("IpV6", "Valid", "Tools", HttpMethod = "POST", 
            AdditionalFields = "Name,IpV4",ErrorMessage = "IpV6有問題喔 請在檢查看看")]

        public string IpV6 { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}