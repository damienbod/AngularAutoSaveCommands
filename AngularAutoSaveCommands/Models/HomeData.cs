using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularAutoSaveCommands.Models
{
    public class HomeData
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}
