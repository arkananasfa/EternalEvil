using System;
using UnityEngine;

public abstract class AbstractEnemyAttacker : MonoBehaviour, IAttackable {

	public Transform Target { get; set; }

	[SerializeField] private float damage;
	[SerializeField] private float attackRange;
	[SerializeField] private float reloadTime;
	public float Damage {
		get => damage;
		set => damage = value;
	}
	public float AttackRange {
		get => attackRange;
		set => attackRange = value;
	}
	public float ReloadTime {
		get => reloadTime;
		set => reloadTime = value;
	}
	public bool IsAttacking { get; protected set; }
	public bool IsReloaded { get; protected set; }
	public abstract void Attack();

	protected float timeToAttack;

	protected Vector3 ToTargetVector => Target.position - transform.position;

	protected virtual void Awake() {
		IsReloaded = true;
		IsAttacking = false;
	}

}