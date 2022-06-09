using UnityEngine;

public class Daggers : AbstractThrownWeapon {
    
	protected override void Awake() {
		base.Awake();
		Name = "Daggers";
		Mass = 0;
		AttackRange = 1500;
		ReloadTime = 200;
		Damage = 5;
		BasePosition = new Vector2(0.4f, 0f);
	}
	
}
