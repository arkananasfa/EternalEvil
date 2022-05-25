using UnityEngine;

public interface IMovable {
	
	float Speed { get; set; }
	Vector2 Velocity { get; set; }
	
	void Move();
}