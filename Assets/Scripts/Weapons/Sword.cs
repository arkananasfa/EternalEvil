using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Sword : AbstractMeleeWeapon {

	protected override void Awake() {
		base.Awake();
		Name = "Sword";
		Mass = 10;
		AttackRange = 1.2f;
		ReloadTime = 200;
		Damage = 25;
		BasePosition = new Vector2(0.2f, 0f);
	}

	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(DamageCenter.position, 1.2f);
	}

	protected override IEnumerator AttackProcess() {
		int framesCount = 90;
		float rotationDiff = -90;
		float macroFrame = framesCount / 3;
		float frameTime = realReloadTime / framesCount;
		float frameRotation = rotationDiff/macroFrame;
		
		for (int i = 0; i < macroFrame; i++) {
			transform.Rotate(0,0,frameRotation);
			yield return new WaitForSeconds(frameTime);
		}
		DealDamage();
		for (int i = 0; i < macroFrame; i++) {
			transform.Rotate(0,0,-frameRotation);
			yield return new WaitForSeconds(frameTime);
		}
		transform.Rotate(0, 0, 0 - transform.localRotation.z);
		IsAttacking = false;
		yield return new WaitForSeconds(frameTime*macroFrame);
		IsReloaded = true;
	}

	protected override void DealDamage() {
		LayerMask mask = LayerMask.GetMask("Enemies", "EnemyBullets");
		Collider2D[] results = Physics2D.OverlapCircleAll(DamageCenter.position, AttackRange, mask);
		foreach (var collider in results) {
			if (collider.gameObject.layer == (int)ObjectsLayers.Enemie)
				collider.GetComponent<IHP>().GetDamage(Damage);
			else
				Destroy(collider.gameObject);
		}
	}
}