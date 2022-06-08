using UnityEngine;

public interface IWeapon : IDescribable{

	string Name { get; set; }
	float Mass { get; set; }
	float AttackRange { get; set; }
	float ReloadTime { get; set; }
	float Damage { get; set; }
	Vector2 BasePosition { get; set; }

	void Attack();

}