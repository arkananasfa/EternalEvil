using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class AbstractThrownWeapon : AbstractWeapon {

	private SpriteRenderer spriteRenderer;

	protected Vector2 velocity;
	protected float speed;
	protected float currentLifeTime;
	protected AbstractThrownWeapon main;

	protected virtual float minReloadTime { get => realReloadTime / 2f; }

	protected override void Awake() {
		base.Awake();
		spriteRenderer = GetComponent<SpriteRenderer>();
		sprite = spriteRenderer.sprite;
	}

	public override void Attack() {
		if (!IsReloaded) return;
		IsReloaded = false;
		AbstractThrownWeapon copy = Instantiate(gameObject, transform.position, transform.rotation).GetComponent<AbstractThrownWeapon>();
		copy.speed = AttackRange / ReloadTime;
		copy.velocity = transform.right.normalized*copy.speed;
		copy.GetComponent<Collider2D>().enabled = true;
		copy.main = this;
		copy.StartCoroutine(copy.Fly());
		spriteRenderer.sprite = null;
	}

	protected virtual IEnumerator Fly() {
		float secondsDelay = 0.02f;
		currentLifeTime = 0;
		while (currentLifeTime<realReloadTime) {
			currentLifeTime += secondsDelay;
			transform.Translate(velocity * secondsDelay, Space.World);
			transform.Rotate(0f, 0f, 10f);
			yield return new WaitForSeconds(secondsDelay);
		}
		main.Reload();
		Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other) {
		switch ((ObjectsLayers)other.gameObject.layer) {
			case ObjectsLayers.Enemie :
				other.GetComponent<IHP>().GetDamage(Damage);
				break;
			case ObjectsLayers.Player :
				return;
		}
		if (currentLifeTime < main.minReloadTime)
			main.StartCoroutine(main.Reload(main.minReloadTime - currentLifeTime));
		else
			main.Reload();
		Destroy(gameObject);
	}

	protected override void Reload() {
		IsReloaded = true;
		spriteRenderer.sprite = sprite;
	}

	protected virtual IEnumerator Reload(float seconds) {
		yield return new WaitForSeconds(seconds);
		Reload();
	}

	public override List<ChooseWindowRow> GenerateDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow(sprite));
		describeList.Add(new ChooseWindowRow(Name, true));
		describeList.Add(new ChooseWindowRow($"Damage : {Damage}"));
		describeList.Add(new ChooseWindowRow($"Attack range: {AttackRange}"));
		describeList.AddRange(GenerateReloadDescribe());
		describeList.Add(SpeedPenaltyRow());
		return describeList;
	}

	protected virtual List<ChooseWindowRow> GenerateReloadDescribe() {
		var describeList = new List<ChooseWindowRow>();
		describeList.Add(new ChooseWindowRow($"Max reload time: {ReloadTime}"));
		describeList.Add(new ChooseWindowRow($"Min reload time: {ReloadTime*(realReloadTime/minReloadTime)}"));
		return describeList;
	}

}