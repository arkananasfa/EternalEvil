using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AbstractCharacter), typeof(IAttackable))]
public class AbstractEnemyController : MonoBehaviour, IController {
	
	public Transform Target { get; set; }
	
	protected float distanceToAttack { get; set; }
	protected float desiredDistance { get; set; }
	protected float timeDelay { get; set; }
	protected virtual float Distance { get => (transform.position - Target.position).magnitude; }

	private IAttackable attacker;
	private AbstractCharacter character;
	
	protected virtual void Awake() {
		attacker = GetComponent<IAttackable>();
		character = GetComponent<AbstractCharacter>();
		timeDelay = 0.1f;
	}

	public void Acting() {
		StartCoroutine(Control());
	}

	protected virtual IEnumerator Control() {
		while (true) {
			if (!attacker.IsAttacking) {
				float distance = Distance;
				if (distance <= distanceToAttack && attacker.IsReloaded)
					attacker.Attack();
				if (distance >= desiredDistance)
					character.Velocity = Target.position - transform.position;
				yield return SpecialBehaviour();
			} else character.Velocity = Vector2.zero;
			yield return new WaitForSeconds(timeDelay);
		}
	}

	protected virtual IEnumerator SpecialBehaviour() {
		yield break;
	}

}