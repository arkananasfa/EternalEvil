using UnityEngine;

public interface IMovable {
	
	float BaseSpeed { get; set; }
	float Speed { get; set; }
	Vector2 Velocity { get; set; }
	
}