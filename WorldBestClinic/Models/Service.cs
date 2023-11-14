using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorldBestClinic.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        public int Price { get; set; } = 0;//New add field

        [DisplayName("Service Name")]
        public string ServiceName { get; set; } = string.Empty; //New add field


        [DisplayName("Service Photo")]
        public string FileName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsLab { get; set; } //New add field




    }
}
