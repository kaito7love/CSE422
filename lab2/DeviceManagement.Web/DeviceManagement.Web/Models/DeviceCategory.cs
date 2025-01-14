using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Web.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
