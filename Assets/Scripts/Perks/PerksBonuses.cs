public static class PerksBonuses {

	public static float BonusDamage = 1f;
	public static float BonusReloadTime = 1f;
	public static float BonusAttackRange = 1f;
	public static int WeaponsCountToChoose = 3;

	public static void UpgradeWeapon(AbstractWeapon weapon) {
		weapon.Damage *= BonusDamage;
		weapon.AttackRange *= BonusAttackRange;
		weapon.ReloadTime *= BonusAttackRange;
	}

}