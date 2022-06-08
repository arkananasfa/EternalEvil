using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMeleeWeapon : AbstractWeapon {

	[SerializeField] protected Transform DamageCenter;
	
	public override void Attack() {
		if (!IsReloaded) return;
		IsReloaded = false;
		IsAttacking = true;
		StartCoroutine(AttackProcess());
	}

	protected abstract IEnumerator AttackProcess();
	protected abstract void DealDamage();

}