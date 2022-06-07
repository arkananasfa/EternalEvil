using System;

public class GameLoopEvents {

	/// <summary>
	/// Create weapon choose menu
	/// </summary>
	public static event Action OnGameStarted;

	/// <summary>
	/// Start the round and give new weapon
	/// </summary>
	public static event Action<AbstractWeapon> OnWeaponChosen;

	/// <summary>
	/// Spawn Enemies
	/// </summary>
	public static event Action OnRoundStarted;

	/// <summary>
	/// Create Perk choose menu
	/// </summary>
	public static event Action OnRoundEnded;

	/// <summary>
	/// Crete weapon choose menu
	/// </summary>
	public static event Action OnPerkChosen;

	/// <summary>
	/// Pause the game completely and show the result screen
	/// </summary>
	public static event Action OnGameLost;

	public static void GameStart() { OnGameStarted?.Invoke(); }
	public static void WeaponChosen(AbstractWeapon choosenWeapon) { OnWeaponChosen?.Invoke(choosenWeapon); }
	public static void StartRound() { OnRoundStarted?.Invoke(); }
	public static void EndRound() { OnRoundEnded?.Invoke(); }
	public static void ChoosePerk() { OnPerkChosen?.Invoke(); }
	public static void LoseGame() { OnGameLost?.Invoke(); }

}