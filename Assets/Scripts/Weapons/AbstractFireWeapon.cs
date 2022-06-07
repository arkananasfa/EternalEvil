using UnityEngine;

public class AbstractFireWeapon : AbstractWeapon {

	public override bool Attack() {
		Debug.Log("Attack");
		return true;
	}

}