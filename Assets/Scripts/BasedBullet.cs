using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BasedBullet : MonoBehaviour, IDamagable {

	public float Damage { get; set; }
	public float Speed { get; set; }
	public float LifeTime { get; set; }
	[SerializeField] protected LayerMask layersToInteract;
	public LayerMask LayersToInteract { get { return layersToInteract;} set { layersToInteract = value; } }
	public UnityEvent OnHit { get; set; }

	protected virtual void Start() {
		Invoke(nameof(DestroyBullet), LifeTime);
	}

	protected virtual void FixedUpdate() {
		transform.localPosition += transform.right * Speed * Time.fixedDeltaTime;
	}

	protected virtual void OnTriggerEnter(Collider other) {
		if ((other.gameObject.layer&LayersToInteract.value)!=0) {
			Hit(other.gameObject);
		}
	}

	protected virtual void Hit(GameObject other) {
		switch ((InGameLayers)other.layer) {
			case InGameLayers.Player:
				other.GetComponent<IHP>().GetDamage(Damage);
				OnHit?.Invoke();
				Destroy(gameObject);
				break;
			case InGameLayers.Enemy:
				other.GetComponent<IHP>().GetDamage(Damage);
				OnHit?.Invoke();
				Destroy(gameObject);
				break;
			case InGameLayers.Obstcle:
				OnHit?.Invoke();
				Destroy(gameObject);
				break;
		}
	}

	protected virtual void DestroyBullet() {
		Destroy(gameObject);
	}

}