using UnityEngine;

public class Radiance : AbstractFireWeapon {
	
	protected override void Awake() {
		base.Awake();
		Name = "Radiance";
		Mass = 25;
		AttackRange = 50;
		ReloadTime = 50;
		Damage = 40;
		BasePosition = new Vector2(0.1f, 0f);
	}
	
}