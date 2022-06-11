using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StandardWeaponBullet : AbstractBullet, IDescribable {

	[SerializeField] private string bulletName;

	protected Sprite sprite;
	
	private void Awake() {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	protected override void OnTriggerEnter2D(Collider2D other) {
		switch ((ObjectsLayers)other.gameObject.layer) {
			case ObjectsLayers.Enemie :
				other.GetComponent<IHP>().GetDamage(Damage);
				Destroy(gameObject);
				break;
			case ObjectsLayers.Player :
				break;
			default:
				Destroy(gameObject);
				break;
		}
	}

	public List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite, bulletName));
		describeList.Add(new ChooseWindowRow($"Damage : {Damage}"));
		describeList.Add(new ChooseWindowRow($"Speed: {Speed}"));
		describeList.Add(new ChooseWindowRow($"Life time: {LifeTime}"));;
		return describeList;
	}
}