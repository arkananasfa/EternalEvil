using System;
using UnityEngine;

[RequireComponent(typeof(AbstractCharacter))]
public abstract class AbstractEnemyAttacker : MonoBehaviour, IAttackable {

	public Transform Target { get; set; }
	
	public float Damage { get; set; }
	public float AttackRange { get; set; }
	public float ReloadTime { get; set; }
	public bool IsAttacking { get; protected set; }
	public bool IsReloaded { get; protected set; }
	public abstract void Attack();

	protected float timeToAttack;

	private void Awake() {
		IsReloaded = true;
		IsAttacking = false;
	}

}