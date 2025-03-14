using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character { IsHero = true };

        public ICharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }
        public ICharacterBuilder SetHeight(int height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            _character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder AddInventoryItem(string inventoryItem)
        {
            _character.Inventory.Add(inventoryItem);
            return this;
        }
        public ICharacterBuilder SetSpecialPower(string specialPower)
        {
            SetHeroPower(specialPower);
            return this;
        }
        private void SetHeroPower(string power)
        {
            _character.SpecialPower = power;
        }

        public ICharacterBuilder PerformDeed(string deed)
        {
            AddGoodDeed(deed);
            return this;
        }
        private void AddGoodDeed(string deed)
        {
            _character.Deeds.Add($"Good deed - {deed}");
        }

        public Character Build()
        {
            return _character;
        }
    }
}
