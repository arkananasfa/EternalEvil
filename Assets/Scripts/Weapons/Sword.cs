using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Sword : AbstractMeleeWeapon {

	protected override void Awake() {
		base.Awake();
		Name = "Sword";
		Mass = 15;
		AttackRange = 0.8f;
		ReloadTime = 120;
		Damage = 20;
		BasePosition = new Vector2(0.2f, 0f);
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
		LayerMask mask = LayerMask.GetMask("Enemies");
		Collider2D[] results = Physics2D.OverlapCircleAll(DamageCenter.position, AttackRange, mask);
		foreach (var collider in results) 
			collider.GetComponent<AbstractCharacter>().GetDamage(Damage);
	}
}