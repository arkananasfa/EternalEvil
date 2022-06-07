using UnityEngine;

public class Daggers : AbstractThrownWeapon {
    
	protected override void Awake() {
		base.Awake();
		Name = "Daggers";
		Mass = 0;
		AttackRange = 200;
		ReloadTime = 200;
		Damage = 8;
		BasePosition = new Vector2(0.6f, 0f);
	}
	
}
