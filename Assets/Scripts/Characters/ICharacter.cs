using UnityEngine;
using UnityEngine.Events;

public interface ICharacter :  IMovable, IHP {

	IAttackable Attacker { get; set; }
	IController Controller { get; set; }
	/// <summary>
	/// Every new round in game the sum power of all enemies is increasing
	/// </summary>
	float Power { get; set; }

}