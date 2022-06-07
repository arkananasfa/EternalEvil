using UnityEngine;

public class AbstractLazerWeapon : AbstractWeapon {

	public override bool Attack() {
		Debug.Log("Attack");
		return true;
	}
}