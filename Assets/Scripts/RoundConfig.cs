using System;
using UnityEngine;

public class RoundConfig : MonoBehaviour {

	private StandardRoundEndBonus endBonus;

	public int RoundsNumber;
    public int SumEnemiesPower => endBonus.enemiesSumPowerBonus * RoundsNumber;
	private float weaponsDamageBonus => 1+endBonus.weaponDamageBonus*(RoundsNumber-1);
	private float enemiesDamageBonus => 1+endBonus.enemiesDamageBonus*(RoundsNumber-1);

	private void Awake() {
		endBonus = GetComponent<StandardRoundEndBonus>();
		RoundsNumber = 1;
	}

	private void OnEnable() {
		GameLoopEvents.OnRoundEnded += NextRound;
	}

	private void OnDisable() {
		GameLoopEvents.OnRoundEnded -= NextRound;
	}

	private void NextRound() {
		RoundsNumber++;
	}

	public void UpgradeWeapon(AbstractWeapon weapon) {
		weapon.Damage *= weaponsDamageBonus;
	}

	public void UpgradeEnemy(StandardCharacter enemy) {
		enemy.GetComponent<IAttackable>().Damage *= enemiesDamageBonus;
	}

}