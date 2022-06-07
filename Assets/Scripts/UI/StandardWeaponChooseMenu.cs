using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StandardWeaponChooseMenu : MonoBehaviour, IWeaponChooseMenu {

	[SerializeField] private ChooseWindow ChooseWindowPrefab;
	[SerializeField] private StandardWeaponFactory factory;
	
	private List<GameObject> windows = new List<GameObject>();

	private void OnEnable() {
		GameLoopEvents.OnGameStarted += CreateMenu;
		GameLoopEvents.OnPerkChosen += CreateMenu;
		GameLoopEvents.OnWeaponChosen += DestroyWindows;
	}
	
	private void OnDisable() {
		GameLoopEvents.OnGameStarted -= CreateMenu;
		GameLoopEvents.OnPerkChosen -= CreateMenu;
		GameLoopEvents.OnWeaponChosen -= DestroyWindows;
	}

	private int round = 1;//testing variant
	public void CreateMenu() {
		List<string> addedWeapons = new List<string>();
		for (int i = 0; i < 3; i++) {
			AbstractWeapon weapon = factory.GetRandomWeapon(round, addedWeapons);
			ChooseWindow window = Instantiate(ChooseWindowPrefab, Vector3.zero, Quaternion.identity, transform);
			windows.Add(window.gameObject);
			
			window.Init(weapon);
			window.OnClick += () => { GameLoopEvents.WeaponChosen(weapon); };
			addedWeapons.Add(weapon.Name);
		}
	}

	private void DestroyWindows(AbstractWeapon weapon) {
		foreach (var go in windows) {
			Destroy(go);
		}
		windows.Clear();
	}
	
}