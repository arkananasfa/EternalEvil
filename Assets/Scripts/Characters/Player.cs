using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController), typeof(PlayerAttacker))]
public class Player : AbstractCharacter
{

	public static Player Instance;
	
	protected override void Awake() {
		Instance = this;
		rb = GetComponent<Rigidbody2D>();
	}
	
	private void Start() {
		Velocity = new Vector2();
		Speed = 3;
		HP = 100;
		GameLoopEvents.GameStart();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Q))
			GetDamage(30);
	}

	public override void Death() {
		GameLoopEvents.LoseGame();
	}

}
