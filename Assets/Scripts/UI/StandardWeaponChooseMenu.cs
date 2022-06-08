using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StandardWeaponChooseMenu : MonoBehaviour, IWeaponChooseMenu {

	[SerializeField] private ChooseWindow ChooseWindowPrefab;
	[SerializeField] private StandardWeaponFactory factory;
	
	private List<GameObject> windows = new List<GameObject>();
	private List<AbstractWeapon> weapons = new List<AbstractWeapon>();

	private void OnEnable() {
		GameLoopEvents.OnGameStarted += CreateMenu;
		GameLoopEvents.OnPerkChosen += CreateMenu;
		GameLoopEvents.OnWeaponChosen += Clear;
	}
	
	private void OnDisable() {
		GameLoopEvents.OnGameStarted -= CreateMenu;
		GameLoopEvents.OnPerkChosen -= CreateMenu;
		GameLoopEvents.OnWeaponChosen -= Clear;
	}

	private int round = 3;//testing variant
	public void CreateMenu() {
		
		for (int i = 0; i < 3; i++) {
			AbstractWeapon weapon = factory.GetRandomWeapon(round, weapons);
			ChooseWindow window = Instantiate(ChooseWindowPrefab, Vector3.zero, Quaternion.identity, transform);
			windows.Add(window.gameObject);

			window.Init(weapon);
			window.OnClick += () => { GameLoopEvents.WeaponChosen(weapon); };
			weapons.Add(weapon);
		}
	}

	private void Clear(AbstractWeapon weapon) {
		foreach (var go in windows) {
			Destroy(go);
		}
		foreach (var w in weapons) {
			if (w != weapon)
				Destroy(w.gameObject);
		}
		windows.Clear();
		weapons.Clear();
	}
	
}