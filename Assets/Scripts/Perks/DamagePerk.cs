using UnityEngine;

public class DamagePerk : Perk
{
    public DamagePerk() : base("Damage Up", 10, -1, new Color(0.9f, 0.2f, 0.2f), $"Add additional 5% damage to your weapons.") {}

    public override void Apply() {
        PerksBonuses.BonusDamage += 0.05f;
    }
}
