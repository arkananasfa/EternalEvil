using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController {

	[SerializeField] private InputSystem inputs;
	[SerializeField] private GameObject playerGraphics;
	
	private Player player { get; set; }
	private PlayerAttacker attacker { get; set; }
	private Animator animator { get; set; }
	
	private Transform weaponTransform { get; set; }

	private bool lookLeft;
	private bool weaponLeft;
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
		lookLeft = inputs.attackingVector.x < 0;
		
		if (weaponTransform == null) return;
		if (!attacker.weapon.IsAttacking) {
			playerGraphics.transform.right = new Vector2(lookLeft ? -1 : 1, 0);
			attacker.WeaponParent.transform.right = inputs.attackingVector;
			if (lookLeft != weaponLeft) {
				weaponTransform.Rotate(180, 0, 0);
				weaponLeft = lookLeft;
			}
		}
		if (inputs.IsAttacking)
			attacker.Attack();
	}

	private void SetupWeapon(AbstractWeapon weapon) {
		weaponTransform = weapon.transform;
	}
	
}