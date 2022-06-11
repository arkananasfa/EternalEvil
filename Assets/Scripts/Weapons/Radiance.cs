using UnityEngine;

public class Radiance : AbstractFireWeapon {
	
	protected override void Awake() {
		base.Awake();
		Name = "Radiance";
		Mass = 20;
		AttackRange = 3f;
		ReloadTime = 1000;
		Damage = 10;
		BasePosition = new Vector2(0.1f, 0f);
	}
	
}