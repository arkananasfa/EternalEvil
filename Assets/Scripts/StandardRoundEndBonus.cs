using UnityEngine;

public class StandardRoundEndBonus : MonoBehaviour {

    #region EnemiesBonuses

    [Header("Enemies' end round bonuses")]
    public int enemiesSumPowerBonus;
    public float enemiesDamageBonus;
    public float enemiesSpeedBonus;
    public float enemiesReloadTimeBonus;
    public float enemiesAttackRangeBonus;

    #endregion
    #region PlayersBonuses

    [Header("Player's end round bonuses")]
    public float playersCoinsBonus;
    public float weaponDamageBonus;

    #endregion

}