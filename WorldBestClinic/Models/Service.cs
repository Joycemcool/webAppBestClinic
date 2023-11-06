using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorldBestClinic.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        [DisplayName("Service Name")]
        public string FileName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //public Category Category { get; set; } = new();

    }
}
