using System;
using System.Collections;
using UnityEngine;

public class AbstractLazerWeapon : AbstractWeapon {

	[SerializeField] protected Transform LazerStart;
	protected LineRenderer line;

	protected LayerMask mask;
	protected bool isON;

	protected override void Awake() {
		base.Awake();
		mask = LayerMask.GetMask(new string[]{"Enemies", "Obstacles"});
		line = GetComponent<LineRenderer>();
		line.startColor = Color.red;
		line.startWidth = 0.02f;
		line.endWidth = 0.02f;
		line.positionCount = 0;
	}

	protected virtual void Start() {
		StartCoroutine(Lazer());
	}

	public override void Attack() {
		isON = true;
	}

	protected virtual IEnumerator Lazer() {
		while (true) {
			if (isON) {
				Vector2 startPos = LazerStart.position;
				var hit2D = Physics2D.Raycast(startPos, transform.right, AttackRange, mask);
				line.positionCount = 2;
				line.SetPosition(0, startPos);
				if (hit2D.collider != null) {
					line.SetPosition(1, hit2D.point);
					hit2D.transform.gameObject.GetComponent<IHP>()?.GetDamage(Damage * realReloadTime);
				} else {
					line.SetPosition(1, startPos + (Vector2)transform.right * AttackRange);
				}
				isON = false;
			} else {
				line.positionCount = 0;
			}
			yield return new WaitForSeconds(realReloadTime);
		}
	}
	
}