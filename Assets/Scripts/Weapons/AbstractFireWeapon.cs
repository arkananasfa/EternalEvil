using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFireWeapon : AbstractWeapon {

	[SerializeField] protected Transform DamageCenter;
	private LayerMask mask;

	protected void Start() {
		mask = LayerMask.GetMask("Enemies");
		StartCoroutine(Fire());
	}

	protected virtual IEnumerator Fire() {
		while (true) {
			Collider2D[] results = Physics2D.OverlapCircleAll(DamageCenter.position, AttackRange, mask);
			foreach (var collider in results) 
				collider.GetComponent<IHP>().GetDamage(Damage*realReloadTime);
			yield return new WaitForSeconds(realReloadTime);
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(DamageCenter.position, AttackRange);
	}

	public override List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite));
		describeList.Add(new ChooseWindowRow(Name, true));
		describeList.Add(new ChooseWindowRow($"Auto burning each {Math.Round(realReloadTime,2)}s"));
		describeList.Add(new ChooseWindowRow($"DPS : {Damage}"));
		describeList.Add(new ChooseWindowRow($"Radius : {AttackRange}"));
		describeList.Add(SpeedPenaltyRow());
		return describeList;
	}

}