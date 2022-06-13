using UnityEngine;

public class AdditionWeaponPerk : Perk
{
    public AdditionWeaponPerk() : base("One More Weapon", 1, 1, new Color(0.9f, 0.9f, 0.2f), $"Add one additional weapon you can choose in menu.") {}

    public override void Apply() {
        PerksBonuses.WeaponsCountToChoose=4;
    }
}