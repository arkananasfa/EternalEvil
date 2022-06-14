using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class AbstractWeapon : MonoBehaviour, IWeapon {

	public string Name { get; set; }
	public float Mass { get; set; }
	public float AttackRange { get; set; }
	public float ReloadTime { get; set; }
	public float Damage { get; set; }
	public Vector2 BasePosition { get; set; }

	public bool IsReloaded { get; set; }
	public bool IsAttacking { get; set; }
	protected virtual float realReloadTime {
		get => 100f / ReloadTime;
	}

	public virtual void Attack() {
		if (!IsReloaded) return;
		IsReloaded = false;
		Invoke(nameof(Reload), realReloadTime);
	}

	protected Sprite sprite;
	
	protected virtual void Awake() {
		sprite = GetComponent<SpriteRenderer>().sprite;
		IsReloaded = true;
		IsAttacking = false;
	}

	protected virtual void Reload() {
		IsReloaded = true;
	}

	public virtual List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite));
		describeList.Add(new ChooseWindowRow(Name, true));
		describeList.Add(new ChooseWindowRow($"Damage : {Damage}"));
		describeList.Add(new ChooseWindowRow($"Attack range: {AttackRange}"));
		describeList.Add(new ChooseWindowRow($"Reload time: {ReloadTime}"));
		describeList.Add(SpeedPenaltyRow());
		return describeList;
	}

	protected virtual ChooseWindowRow SpeedPenaltyRow() {
		if (Mass == 0) return new ChooseWindowRow("No speed penalties");
		return new ChooseWindowRow($"Speed penalty: -{Mass}%");
	}
}