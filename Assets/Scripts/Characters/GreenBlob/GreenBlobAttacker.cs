using UnityEngine;

public class GreenBlobAttacker  : AbstractRangedEnemyAttacker {
    
	
	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
	}

	public override void Attack() {
		base.Attack();
		animator.SetBool(attacking, true);
	}


	public void EndAttack() {
		IsAttacking = false;
		animator.SetBool(attacking, false);
	}
	
}