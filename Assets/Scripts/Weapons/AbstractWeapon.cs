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
	
	public abstract bool Attack();

	protected Sprite sprite;
	
	protected virtual void Awake() {
		sprite = GetComponent<SpriteRenderer>().sprite;
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