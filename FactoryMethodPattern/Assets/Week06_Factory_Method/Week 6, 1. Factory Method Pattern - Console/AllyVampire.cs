using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPattern
{
    public class AllyVampire : NPC
    {

        public AllyVampire()
        {
            this.NPCType = "Ally Vampire";
            this.Allegiance = AllegianceType.ALLY;
            this.Weapon = "Bite";
            this.Damage = 10;
            this.Speed = 5.0f;
        }
    }
}