using UnityEngine;

public class Sword : AbstractMeleeWeapon {
    
	protected override void Awake() {
		base.Awake();
		Name = "Sword";
		Mass = 15;
		AttackRange = 35;
		ReloadTime = 120;
		Damage = 20;
		BasePosition = new Vector2(0.2f, 0f);
	}
	
}