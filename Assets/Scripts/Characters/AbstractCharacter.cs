using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbstractCharacter : MonoBehaviour, ICharacter
{
	
	public float HP { get; set; }
	public float Speed { get; set; }
	public float Power { get; set; }

	public IAttackable Attacker { get; set; }
	public IController Controller { get; set; }

	public Vector2 Velocity {
		get => rb.velocity;
		set => rb.velocity = value.normalized*Speed;
	}

	public event Action OnDeath;
	public event Action<float> OnGetDamage;

	protected Rigidbody2D rb;

	protected virtual void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	public virtual void GetDamage(float damage) {
		HP -= damage;
		OnGetDamage?.Invoke(damage);
		if (HP <= 0) Death();
	}
	
	public virtual void Death() {
		OnDeath?.Invoke();
		Destroy(gameObject);
	}

	
	
}
