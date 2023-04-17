using System.ComponentModel.DataAnnotations;
using Knights.Challenge.Core.Domain.Constants;

namespace Knights.Challenge.Core.Domain.Entities
{
    public class KnightEntity
    {
        public KnightEntity()
        {
            this.Weapons = new List<WeaponEntity>();
            this.Name = string.Empty;
            this.NickName = string.Empty;
            this.KeyAttribute = string.Empty;
            this.Attributes = new Dictionary<string, int>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public List<WeaponEntity> Weapons { get; set; }
        [Required]
        public Dictionary<string, int> Attributes { get; set; }
        [Required]
        public string KeyAttribute { get; set; }

        public int GetAge()
        {
            return DateTime.Now.Year - Birthday.Year;
        }

        public int GetAttack()
        {
            if (Attributes.FirstOrDefault(x => x.Key.Equals(KeyAttribute)).Key == null) return 0;

            if (Weapons.Count == 0 || !Weapons.Any(x => x.Equipped)) return 0;

            return 10 + ModifierAttributeConstant.GetValue(Attributes[KeyAttribute]) + Weapons.First(x => x.Equipped == true).Mod;
        }

        public int GetExperiense()
        {
            var exp = Math.Floor(Convert.ToDecimal(GetAge() - 7)) * Convert.ToDecimal(Math.Pow(22, 1.45));
            
            if (exp < 0) return 0;
            
            return Convert.ToInt32(exp);
        }
    }
}
