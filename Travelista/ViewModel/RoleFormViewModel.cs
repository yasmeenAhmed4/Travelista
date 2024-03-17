using System.ComponentModel.DataAnnotations;

namespace Travelista.ViewModel
{
    public class RoleFormViewModel
    {
        [Required,StringLength(256)]
        public string Name { get; set; }
    }
}
