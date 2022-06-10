using System;
using UnityEngine.Events;

public interface IHP {

	float BaseHP { get; set; }
	float HP { get; set; }
	void GetDamage(float damage);
	event Action<float> OnGetDamage;
	void Death();
	event Action OnDeath;

}