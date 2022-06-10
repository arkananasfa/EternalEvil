using System;
using System.Collections;
using UnityEngine;

public class BiterBlobAttacker : AbstractEnemyAttacker {

	private void Start() {
		Damage = 5f;
		AttackRange = 2.6f;
		ReloadTime = 1.0f;
		timeToAttack = 0.2f;
	}
	
	public override void Attack() {
		StartCoroutine(Bite());
	}

	private IEnumerator Bite() {
		IsAttacking = true;
		IsReloaded = false;
		transform.localScale *= 1.25f;
		yield return new WaitForSeconds(timeToAttack);
		transform.localScale *= 0.8f;
		if ((transform.position - Target.position).magnitude <= AttackRange) {
			Target.GetComponent<IHP>().GetDamage(Damage);
			IsAttacking = false;
			yield return new WaitForSeconds(ReloadTime);
		}
		IsAttacking = false;
		IsReloaded = true;
	}
}