using UnityEngine;

public abstract class AbstractThrownWeapon : AbstractWeapon {

	public override bool Attack() {
		Debug.Log("Attack");
		return true;
	}
}