using System;

public interface IWeaponFactory {

	AbstractWeapon GetWeapon(string name);
	AbstractWeapon GetRandomWeapon(int currentLevel);

}

[Serializable]
public class WeaponType {
	public string Name;
	public int Level;
}