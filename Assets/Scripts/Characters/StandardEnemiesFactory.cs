using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;

public class StandardEnemiesFactory : MonoBehaviour, IEnemiesFactory {

	[SerializeField] private RoundConfig round;
	[SerializeField] private EnemiesGroup enemies;
	private List<EnemiesType> Types { get; set; }

	protected virtual void Awake() {
		string enemiesTypesConfig = Resources.Load<TextAsset>("Configs\\EnemiesTypes").text;
		Types = JSONArraysUtility.FromJson<EnemiesType>(enemiesTypesConfig).ToList();
	}
	
	public virtual StandardCharacter GetCharacter(string name) {
		StandardCharacter enemy = ((GameObject)Resources.Load("Enemies\\" + name)).GetComponent<StandardCharacter>();
		enemy = Instantiate(enemy).GetComponent<StandardCharacter>();
		round.UpgradeEnemy(enemy);
		enemies.AddCharacter(enemy);
		enemy.OnDeath += () => {
			enemies.RemoveCharacter(enemy);
		};
		return enemy;
	}
	
	public virtual (StandardCharacter, int) GetRandomCharacter(int powerLast) { ;
		List<EnemiesType> available = Types.Where(i => i.Power <= powerLast).ToList();
		int rand = Random.Range(0, available.Count);
		return (GetCharacter(available[rand].Name), powerLast - available[rand].Power);
	}
	
}