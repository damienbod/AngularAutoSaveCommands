using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular2AutoSaveCommands.Models
{
    public class AboutData
    {
        [Key]
        public long Id { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }
    }
}
