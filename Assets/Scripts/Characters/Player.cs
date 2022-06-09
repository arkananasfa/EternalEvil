using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController), typeof(PlayerAttacker))]
public class Player : AbstractCharacter
{

	public static Player Instance;

	private float baseSpeed;

	protected override void Awake() {
		Instance = this;
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable() {
		GameLoopEvents.OnWeaponChosen += ChangeSpeedByWeapon;
	}

	private void Start() {
		Velocity = new Vector2();
		Speed = 3;
		baseSpeed = Speed;
		HP = 100;
		GameLoopEvents.GameStart();
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
