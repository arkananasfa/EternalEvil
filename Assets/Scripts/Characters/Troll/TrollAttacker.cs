using UnityEngine;

public class TrollAttacker : AbstractRangedEnemyAttacker {

	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
	}

	public override void Attack() {
		base.Attack();
		animator.SetBool(attacking, true);
	}

	public override void Throw() {
		base.Throw();
		IsAttacking = false;
		animator.SetBool(attacking, false);
	}

}