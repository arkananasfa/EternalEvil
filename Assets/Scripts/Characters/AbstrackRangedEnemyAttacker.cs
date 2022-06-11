using UnityEngine;

public abstract class AbstractRangedEnemyAttacker : AbstractEnemyAttacker {

	[SerializeField] private StandardEnemyProjectile ProjectilePrefab;
	[SerializeField] private Transform ProjectileStart;
	
	protected readonly int attacking = Animator.StringToHash("IsAttacking");

	public override void Attack() {
		IsAttacking = true;
		IsReloaded = false;
	}
	
	public virtual void Throw() {
		StandardEnemyProjectile projectile = Instantiate(ProjectilePrefab, ProjectileStart.position, Quaternion.identity);
		projectile.transform.right = ToTargetVector;
		projectile.Damage = Damage;
		projectile.LifeTime = AttackRange/projectile.Speed;
		projectile.Init();
		IsAttacking = false;
		Invoke(nameof(Reload), ReloadTime);
	}

	protected virtual void Reload() {
		IsReloaded = true;
	}
	
}