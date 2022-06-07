using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController {

	[SerializeField] private InputSystem inputs;
	[SerializeField] private GameObject playerGraphics;
	
	private Player player { get; set; }
	private PlayerAttacker attacker { get; set; }
	private Animator animator { get; set; }
	
	private SpriteRenderer weaponSprite { get; set; }

	private bool lookLeft;
	private readonly int IsMoving = Animator.StringToHash("isMoving");

	private void Awake() {
		player = GetComponent<Player>();
		attacker = GetComponent<PlayerAttacker>();
		animator = GetComponent<Animator>();
	}

	private void Start() {
		GameLoopEvents.OnWeaponChosen += SetupWeapon;
	}

	public void Acting() {
		
	}

	private void Update() {
		player.Velocity = inputs.movingVector;
		animator.SetBool(IsMoving , player.Velocity != Vector2.zero);
		attacker.WeaponParent.transform.right = inputs.attackingVector;
		lookLeft = inputs.attackingVector.x < 0;
		playerGraphics.transform.right = new Vector2(lookLeft ? -1 : 1, 0);
		if (weaponSprite != null) 
			weaponSprite.flipY = lookLeft;
	}

	private void SetupWeapon(AbstractWeapon weapon) {
		weaponSprite = weapon.transform.GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate() {
		player.Move();
	}

}