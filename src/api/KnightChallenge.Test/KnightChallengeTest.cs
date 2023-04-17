using Knights.Challenge.Core.Domain.Entities;
using Xunit;

namespace KnightChallenge.Test
{
    public class KnightChallengeTest
    {
        KnightEntity entity;
        public KnightChallengeTest()
        {

            entity = new KnightEntity()
            {
                Attributes = new Dictionary<string, int> {
                    { "strength", 11 },
                    { "dexterity", 0 },
                    { "constitution", 0 },
                    { "intelligence", 0 },
                    { "wisdom", 0 },
                    { "charisma", 0 },
                },
                Birthday = Convert.ToDateTime("1989-02-11 00:00:00"),
                Id = Guid.NewGuid(),
                Name = "Test",
                NickName = "Test",
                KeyAttribute = "strength",
                Weapons = new List<WeaponEntity> { 
                    new WeaponEntity() { Attr ="",Name ="", Equipped = true, Mod = 3 }}
            };
        }

        [Fact]
        public void When_GetAttack_By_Attibute_Strength()
        {
            //ACT
            var attack = entity.GetAttack();

            //Assert
            Assert.True(attack == 13);
        }
        
        [Fact]
        public void When_GetAttack_Nothing_Weapons()
        {
            //Arrage
            entity.Weapons = new List<WeaponEntity>();

            //ACT
            var attack = entity.GetAttack();

            //Assert
            Assert.True(attack == 0);
        }
        [Fact]
        public void When_GetAttack_Attribute_NotFound()
        {
            //Arrage
            entity.Attributes = new Dictionary<string, int>();

            //ACT
            var attack = entity.GetAttack();

            //Assert
            Assert.True(attack == 0);
        }
        [Fact]
        public void When_GetAge_Return_Value()
        {
            //Arrage
            entity.Birthday = Convert.ToDateTime($"{DateTime.Now.Year - 34}-01-01 00:00:00");
            //ACT
            var age = entity.GetAge();

            //Assert
            Assert.True(age == 34);
        }

        [Fact]
        public void When_GetExperiense_Return_Value()
        {
            //ACT
            var exp = entity.GetExperiense();

            //Assert
            Assert.True(exp == 2387);
        }

        [Fact]
        public void When_GetExperiense_Return_Zero()
        {
            //Arrange
            entity.Birthday = Convert.ToDateTime($"{DateTime.Now.Year - 6}-01-01 00:00:00");

            //ACT
            var exp = entity.GetExperiense();

            //Assert
            Assert.True(exp == 0);
        }


    }
}