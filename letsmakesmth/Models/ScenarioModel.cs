using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace letsmakesmth.Models
{
    public class ScenarioModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Condition { get; set; } = "{}";
        public string Action { get; set; } = "{}";

        [ForeignKey("Devices")]
        public Guid DeviceId { get; set; }
        public DeviceModel Device { get; set; }
    }
}
