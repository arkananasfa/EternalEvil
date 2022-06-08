using UnityEngine;

public abstract class AbstractThrownWeapon : AbstractWeapon {


	private Sprite sprite;
	private bool isFlying;

	private SpriteRenderer renderer;
	public override void Attack() {
		if (!IsReloaded) return;
		IsReloaded = false;
		isFlying = true;
		
		Invoke(nameof(Reload), realReloadTime);
	}

	protected override void Reload() {
		IsReloaded = true;
		isFlying = false;
		
	}

}