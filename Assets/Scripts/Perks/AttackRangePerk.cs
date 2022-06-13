using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangePerk : Perk
{
    public AttackRangePerk() : base("Attack Range Up", 10, -1, new Color(0.6f, 0.1f, 0.6f), $"Add additional 5% attack range to your weapons.") {}

    public override void Apply() {
        PerksBonuses.BonusAttackRange += 0.05f;
    }
}