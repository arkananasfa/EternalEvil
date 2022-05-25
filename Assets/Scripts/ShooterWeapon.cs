using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShooterWeapon : MonoBehaviour, IWeapon {
	
	public float Damage { get; set; }
	public float BulletSpeed { get; set; }
	public float ReloadTime { get; set; }
	public bool IsReloaded { get; set; }
	public float LifeTime { get; set; }
	[SerializeField] protected GameObject bulletPrefab;
	public GameObject BulletPrefab { get { return bulletPrefab;} set { bulletPrefab = value; } }
	[SerializeField] protected Transform bulletParent;
	public Transform BulletParent { get { return bulletParent;} set { bulletParent = value; } }
	public UnityEvent OnAttack { get; set; }
	public UnityEvent OnPastAttack { get; set; }
	public UnityEvent OnReload { get; set; }

	protected virtual void Start() {
		OnAttack.AddListener(Attack);
		IsReloaded = true;
	}

	public virtual Vector2 GetBulletSpawnPosition() {
		return bulletParent.position;
	}

	public virtual void Attack() {
		if (!IsReloaded) return;
		var bullet = Instantiate(bulletPrefab, GetBulletSpawnPosition(), bulletParent.rotation, bulletParent);
		IDamagable bulletDamagable = bullet.GetComponent<IDamagable>();
		bulletDamagable.Damage = GetCorrectDamage();
		bulletDamagable.Speed = BulletSpeed;
		bulletDamagable.LifeTime = LifeTime;
		IsReloaded = false;
		Invoke(nameof(Reload), ReloadTime);
	}

	public void Reload() {
		IsReloaded = true;
		OnReload?.Invoke();
	}

	public virtual float GetCorrectDamage() {
		return Damage;
	}
}