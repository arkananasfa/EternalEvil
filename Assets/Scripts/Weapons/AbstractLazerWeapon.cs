using UnityEngine;

public class AbstractLazerWeapon : AbstractWeapon {

	public override void Attack() {
		if (!IsReloaded) return;
		IsReloaded = false;
		Invoke(nameof(Reload), realReloadTime);
		Debug.Log("Attack");
	}
}