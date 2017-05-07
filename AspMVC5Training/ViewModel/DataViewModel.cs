using AspMVC5Training.Infrastructure.CustomAttribute;
using System.ComponentModel.DataAnnotations;
using System.Net;

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

        public string IpV6 { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}