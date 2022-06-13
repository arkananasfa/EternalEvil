using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StandardPerkChooseMenu : MonoBehaviour {

	[SerializeField] private ChooseWindow ChooseWindowPrefab;
	private List<GameObject> windows = new List<GameObject>();

	private List<Perk> perksList;

	private void Awake() {
		perksList = new List<Perk>() {
			new DamagePerk(), new AdditionWeaponPerk(),
			new AttackRangePerk(), new MaxHpPerk(),
			new PlayerSpeedPerk(), new ReloadTimePerk()
		};
	}

	public void CreateMenu() {
		List<Perk> availablePerks = perksList.ToList();
		for (int i = 0; i < 3; i++) {
			Perk chosenPerk = availablePerks[0];
			float maxNumber = -1;
			foreach (Perk perk in availablePerks) {
				float number = perk.Frequency * Random.Range(0f, 1f);
				if (number > maxNumber) {
					maxNumber = number;
					chosenPerk = perk;
				}
			}
			ChooseWindow window = Instantiate(ChooseWindowPrefab, Vector3.zero, Quaternion.identity, transform);
			windows.Add(window.gameObject);
			window.Init(chosenPerk);
			window.GetComponent<Image>().color = chosenPerk.Color;
			window.OnClick += () => { ApplyPerk(chosenPerk); };
			availablePerks.Remove(chosenPerk);
		}
	}

	private void ApplyPerk(Perk perk) {
		perk.Apply();
		perk.CurrentUses++;
		if (perk.CurrentUses == perk.MaxUses)
			perksList.Remove(perk);
		foreach (var window in windows) {
			Destroy(window);
		}
		windows.Clear();
		GameLoopEvents.ChoosePerk();
	}
	
}