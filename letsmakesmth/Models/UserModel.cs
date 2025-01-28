using System.ComponentModel.DataAnnotations;

namespace letsmakesmth.Models
{
    public class UserModel
    {
        [Key]
        public Guid id { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public string Role { set; get; }

        public List<DeviceModel> Devices { get; set; } = new();

    }
}
