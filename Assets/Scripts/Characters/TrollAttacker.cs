using UnityEngine;

public class TrollAttacker : AbstractRangedEnemyAttacker {

	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
	}

	private void Start() {
		Damage = 15f;
		AttackRange = 8f;
		ReloadTime = 2f;
		timeToAttack = 0f;
	}

	public override void Attack() {
		base.Attack();
		animator.SetBool(attacking, true);
	}

	public override void Throw() {
		base.Throw();
		animator.SetBool(attacking, false);
	}

}