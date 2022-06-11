using System.Collections;
using UnityEngine;

[RequireComponent(typeof(StandardCharacter), typeof(IAttackable))]
public class StandardEnemyController : MonoBehaviour, IController {
	
	public Transform Target { get; set; }

	[SerializeField] private float distanceToAttack;
	[SerializeField] private float desiredDistance;

	protected float DistanceToAttack {
		get => distanceToAttack;
		set => distanceToAttack = value;
	}
	protected float DesiredDistance {
		get => desiredDistance;
		set => desiredDistance = value;
	}
	protected float timeDelay { get; set; }
	protected virtual float Distance { get => (transform.position - Target.position).magnitude; }

	private IAttackable attacker;
	private StandardCharacter character;
	
	protected virtual void Awake() {
		attacker = GetComponent<IAttackable>();
		character = GetComponent<StandardCharacter>();
		timeDelay = 0.1f;
	}

	public void Acting() {
		StartCoroutine(Control());
	}

	protected virtual IEnumerator Control() {
		while (true) {
			if (!attacker.IsAttacking) {
				float distance = Distance;
				if (distance <= DistanceToAttack && attacker.IsReloaded)
					attacker.Attack();
				if (distance >= DesiredDistance)
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