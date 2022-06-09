using UnityEngine;

public class HellStick : AbstractLazerWeapon {
    
	protected override void Awake() {
		base.Awake();
		Name = "Hell stick";
		Mass = 20;
		AttackRange = 6;
		ReloadTime = 2000;
		Damage = 16;
		BasePosition = new Vector2(0f, 0f);
	}
	
}