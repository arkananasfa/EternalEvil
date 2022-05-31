using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingCharacter : MonoBehaviour, IController, IMovable{

	public UnityEvent OnActing { get; set; }
	public float Speed { get { return speed;} set { speed = value; } }
	public Vector2 Velocity { get; set; }

	[SerializeField] protected float speed;
	[SerializeField] protected Transform Body;
	
	protected Rigidbody2D rb;

	protected virtual void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	protected virtual void Start() {
		Velocity = Vector2.zero;
		OnActing = new UnityEvent();
		OnActing.AddListener(Move);
	}

	protected virtual void FixedUpdate() {
		OnActing?.Invoke();
	}

	public virtual void Move() {
		rb.velocity = Velocity;
	}
}