using System.ComponentModel.DataAnnotations;

namespace letsmakesmth.Models
{
    public class DeviceModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public string State { get; set; } = "{}";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string SerialBarcode { get; set; }

        public Guid UserId { get; set; }
        public UserModel Users { get; set; }
    }
}
