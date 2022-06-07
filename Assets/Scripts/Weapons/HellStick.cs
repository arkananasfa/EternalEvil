using UnityEngine;

public class HellStick : AbstractLazerWeapon {
    
	protected override void Awake() {
		base.Awake();
		Name = "Hell stick";
		Mass = 20;
		AttackRange = 80;
		ReloadTime = 0;
		Damage = 12;
		BasePosition = new Vector2(0f, 0f);
	}
	
}