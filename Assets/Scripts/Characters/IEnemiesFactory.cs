using System;

public interface IEnemiesFactory {

	StandardCharacter GetCharacter(string name);

	(StandardCharacter, int) GetRandomCharacter(int powerLast);

}

[Serializable]
public class EnemiesType {
	public string Name;
	public int Power;
}