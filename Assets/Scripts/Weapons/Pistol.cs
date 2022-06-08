using UnityEngine;

public class Pistol : AbstractShooterWeapon {

	protected override void Awake() {
		base.Awake();
		Name = "Pistol";
		Mass = 10;
		AttackRange = 100;
		ReloadTime = 100;
		Damage = 10;
		BasePosition = new Vector2(0.5f, 0f);
	}

}