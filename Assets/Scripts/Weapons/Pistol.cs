using UnityEngine;

public class Pistol : AbstractShooterWeapon {

	protected override void Awake() {
		base.Awake();
		Name = "Pistol";
		Mass = 10;
		AttackRange = 10;
		ReloadTime = 100;
		Damage = 10f;
		BasePosition = new Vector2(0.5f, 0f);
	}

}