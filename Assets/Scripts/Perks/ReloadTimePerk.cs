using UnityEngine;

public class ReloadTimePerk : Perk
{
    public ReloadTimePerk() : base("Attack Speed Up", 10, -1, new Color(0.2f, 0.2f, 0.9f), $"Add additional 5% attack speed to your weapons.") {}

    public override void Apply() {
        PerksBonuses.BonusReloadTime += 0.05f;
    }
}