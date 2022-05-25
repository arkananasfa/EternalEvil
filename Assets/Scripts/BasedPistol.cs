public class BasedPistol : ShooterWeapon {

	protected override void Start() {
		base.Start();
		ReloadTime = 0.5f;
		Damage = 5f;
		BulletSpeed = 400f;
		IsReloaded = true;
		LifeTime = 3f;
	}

}