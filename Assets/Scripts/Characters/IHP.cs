using UnityEngine.Events;

public interface IHP {

	float HP { get; set; }
	void GetDamage(float damage);
	UnityEvent OnGetDamage { get; set; }
	void Death();
	UnityEvent OnDeath { get; set; }

}