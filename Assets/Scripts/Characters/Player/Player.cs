using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController), typeof(PlayerAttacker))]
public class Player : StandardCharacter
{

	public static Player Instance;

	protected override void Awake() {
		base.Awake();
		Instance = this;
	}

	private void OnEnable() {
		GameLoopEvents.OnWeaponChosen += ChangeSpeedByWeapon;
		GameLoopEvents.OnRoundEnded += RestoreHP;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Q))
			GetDamage(30);
	}

	private void OnDisable() {
		GameLoopEvents.OnWeaponChosen -= ChangeSpeedByWeapon;
		GameLoopEvents.OnRoundEnded -= RestoreHP;
	}

	public override void Death() {
		GameLoopEvents.LoseGame();
	}

	private void ChangeSpeedByWeapon(AbstractWeapon weapon) {
		Speed = BaseSpeed - BaseSpeed * (weapon.Mass / 100);
	}

	private void RestoreHP() {
		HP = BaseHP;
		GetDamage(0);
	}

}
