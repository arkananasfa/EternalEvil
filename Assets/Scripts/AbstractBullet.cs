using System.Collections;
using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour, IBullet {
	
	[SerializeField] private float speed;
	public float Speed { get => speed; set => speed = value; }
	
	public float Damage { get; set; }
	public float LifeTime { get; set; }

	public virtual void Init() {
		StartCoroutine(Fly());
		Invoke(nameof(Death), LifeTime);
	}

	protected abstract void OnTriggerEnter2D(Collider2D other);

	protected virtual IEnumerator Fly() {
		float secondsDelay = 0.02f;
		while (true) {
			transform.Translate(transform.right * Speed * secondsDelay, Space.World);
			yield return new WaitForSeconds(secondsDelay);
		}
	}

	protected virtual void Death() {
		Destroy(gameObject);
	}
	
}