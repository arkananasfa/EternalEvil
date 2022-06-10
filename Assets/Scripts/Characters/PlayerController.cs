using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController {
	
	[SerializeField] private GameObject playerGraphics;
	[SerializeField] private Transform WeaponParent;
	
	private InputSystem inputs;
	private ICharacter player { get; set; }
	private IAttackable attacker { get; set; }
	private Animator animator { get; set; }
	public Transform Target { get; set; }
	
	private Transform weaponTransform { get; set; }

	private bool lookLeft;
	private bool weaponLeft;
	private readonly int IsMoving = Animator.StringToHash("isMoving");

	private void Awake() {
		player = GetComponent<ICharacter>();
		attacker = GetComponent<IAttackable>();
		animator = GetComponent<Animator>();
	}

	private void OnEnable() {
		GameLoopEvents.OnWeaponChosen += SetupWeapon;
	}

	private void Start() {
		inputs = InputSystem.Instance;
	}

	private void OnDisable() {
		GameLoopEvents.OnWeaponChosen -= SetupWeapon;
	}
	
	public void Acting() {
		
	}

	private void FixedUpdate() {
		player.Velocity = inputs.movingVector;
		animator.SetBool(IsMoving , player.Velocity != Vector2.zero);
		lookLeft = inputs.attackingVector.x < 0;
		
		if (weaponTransform == null) return;
		if (!attacker.IsAttacking) {
			playerGraphics.transform.right = new Vector2(lookLeft ? -1 : 1, 0);
			WeaponParent.right = inputs.attackingVector;
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