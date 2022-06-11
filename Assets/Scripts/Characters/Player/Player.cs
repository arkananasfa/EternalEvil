using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController), typeof(PlayerAttacker))]
public class Player : StandardCharacter
{

	public static Player Instance;

	private float baseSpeed;

	protected override void Awake() {
		base.Awake();
		Instance = this;
		baseSpeed = Speed;
	}

	private void OnEnable() {
		GameLoopEvents.OnWeaponChosen += ChangeSpeedByWeapon;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Q))
			GetDamage(30);
	}

	private void OnDisable() {
		GameLoopEvents.OnWeaponChosen -= ChangeSpeedByWeapon;
	}

	public override void Death() {
		GameLoopEvents.LoseGame();
	}

	private void ChangeSpeedByWeapon(AbstractWeapon weapon) {
		Speed = baseSpeed - baseSpeed * (weapon.Mass / 100);
	}

}
