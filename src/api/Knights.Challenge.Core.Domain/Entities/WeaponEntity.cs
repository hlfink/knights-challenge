using System.ComponentModel.DataAnnotations;

namespace Knights.Challenge.Core.Domain.Entities
{
    public class WeaponEntity
    {
        public WeaponEntity()
        {
            this.Name = string.Empty;
            this.Equipped = false;
            this.Attr = string.Empty;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Mod { get; set; }
        [Required]
        public string Attr { get; set; }
        [Required]
        public bool Equipped { get; set; }
    }
}