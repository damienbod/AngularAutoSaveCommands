using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSaveCommandsApi.Models
{
    public class AboutData
    {
        [Key]
        public long Id { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }
    }
}
