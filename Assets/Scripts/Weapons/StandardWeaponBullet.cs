using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StandardWeaponBullet : MonoBehaviour, IBullet, IDescribable {

	[SerializeField] private string _name;

	[SerializeField] private float speed;
	public float Speed { get => speed; set => speed = value; }
	public float Damage { get; set; }
	public float LifeTime { get; set; }
	
	protected Sprite sprite;
	

	private void Awake() {
		sprite = GetComponent<SpriteRenderer>().sprite;
	}

	public void Init() {
		StartCoroutine(Fly());
		Invoke(nameof(Death), LifeTime);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other) {
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

	public IEnumerator Fly() {
		float secondsDelay = 0.02f;
		while (true) {
			transform.Translate(transform.right * Speed * secondsDelay, Space.World);
			yield return new WaitForSeconds(secondsDelay);
		}
	}

	private void Death() {
		Destroy(gameObject);
	}

	public List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite, _name));
		describeList.Add(new ChooseWindowRow($"Damage : {Damage}"));
		describeList.Add(new ChooseWindowRow($"Speed: {Speed}"));
		describeList.Add(new ChooseWindowRow($"Life time: {LifeTime}"));;
		return describeList;
	}
}