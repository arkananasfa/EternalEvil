using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class StandardCharacter : MonoBehaviour, ICharacter
{
	
	[SerializeField] private float baseHp;
	[SerializeField] private float speed;
	[SerializeField] private float power;
	
	public float BaseHP {
		get => baseHp;
		set => baseHp = value;
	}
	public float Speed {
		get => speed;
		set => speed = value;
	}
	public float Power {
		get => power;
		set => power = value;
	}
	
	public float HP { get; set; }
	public IAttackable Attacker { get; set; }
	public IController Controller { get; set; }

	private Transform target;
	public Transform Target {
		get => target;
		set {
			target = value;
			Controller.Target = value;
			Attacker.Target = value;
		}
	}

	public Vector2 Velocity {
		get => rb.velocity;
		set => rb.velocity = value.normalized*Speed;
	}

	public event Action OnDeath;
	public event Action<float> OnGetDamage;

	protected Rigidbody2D rb;

	protected virtual void Awake() {
		rb = GetComponent<Rigidbody2D>();
		Attacker = GetComponent<IAttackable>();
		Controller = GetComponent<IController>();
	}

	protected virtual void Start() {
		HP = BaseHP;
		Target = Player.Instance.transform;
		Controller.Acting();
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
