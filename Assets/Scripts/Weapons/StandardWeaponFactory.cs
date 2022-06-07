using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Helpers;

public class StandardWeaponFactory : MonoBehaviour, IWeaponFactory {

	[SerializeField] private Transform NewWeaponParent;
	private List<WeaponType> Types { get; set; }

	private void Awake() {
		string weaponTypesConfig = Resources.Load<TextAsset>("Configs\\WeaponTypes").text;
		Types = JSONArraysUtility.FromJson<WeaponType>(weaponTypesConfig).ToList();
	}

	public AbstractWeapon GetWeapon(string name) {
		return Instantiate((GameObject)Resources.Load("Weapons\\"+name), NewWeaponParent).GetComponent<AbstractWeapon>();
	}

	public AbstractWeapon GetRandomWeapon(int currentLevel) {
		List<WeaponType> available = Types.Where(t => t.Level <= currentLevel).ToList();
		int rand = Random.Range(0, available.Count());
		return GetWeapon(available[rand].Name);
	}

	public AbstractWeapon GetRandomWeapon(int currentLevel, List<string> alreadyChoosen) {
		List<WeaponType> available = Types.Where(i => i.Level <= currentLevel).Where(i => {
			foreach (var j in alreadyChoosen) 
				if (i.Name == j) return false;
			return true;
		}).ToList();
		int rand = Random.Range(0, available.Count());
		return GetWeapon(available[rand].Name);
	}

	
}
