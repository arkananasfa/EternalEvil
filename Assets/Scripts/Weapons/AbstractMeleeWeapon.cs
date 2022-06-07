using UnityEngine;

public abstract class AbstractMeleeWeapon : AbstractWeapon {
	
	public override bool Attack() {
		Debug.Log("Attack");
		return true;
	}
	
}