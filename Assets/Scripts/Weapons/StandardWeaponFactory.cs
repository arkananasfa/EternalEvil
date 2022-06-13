using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Helpers;

public class StandardWeaponFactory : MonoBehaviour, IWeaponFactory {

	[SerializeField] private RoundConfig round;
	[SerializeField] private Transform NewWeaponParent;
	private List<WeaponType> Types { get; set; }

	private void Awake() {
		string weaponTypesConfig = Resources.Load<TextAsset>("Configs\\WeaponTypes").text;
		Types = JSONArraysUtility.FromJson<WeaponType>(weaponTypesConfig).ToList();
	}

	public AbstractWeapon GetWeapon(string name) {
		AbstractWeapon weapon = ((GameObject)Resources.Load("Weapons\\" + name)).GetComponent<AbstractWeapon>();
		weapon = Instantiate(weapon, NewWeaponParent).GetComponent<AbstractWeapon>();
		round.UpgradeWeapon(weapon);
		PerksBonuses.UpgradeWeapon(weapon);
		return weapon;
	}

	public AbstractWeapon GetRandomWeapon(int currentLevel) {
		List<WeaponType> available = Types.Where(t => t.Level <= currentLevel).ToList();
		int rand = Random.Range(0, available.Count);
		return GetWeapon(available[rand].Name);
	}

	public AbstractWeapon GetRandomWeapon(int currentLevel, List<AbstractWeapon> alreadyChoosen) {
		List<WeaponType> available = Types.Where(i => i.Level <= currentLevel && alreadyChoosen.All(j => i.Name != j.Name)).ToList();
		int rand = Random.Range(0, available.Count);
		return GetWeapon(available[rand].Name);
	}

	
}
