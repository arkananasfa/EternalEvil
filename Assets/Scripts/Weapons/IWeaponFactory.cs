using System;
using System.Collections.Generic;

public interface IWeaponFactory {

	AbstractWeapon GetWeapon(string name);
	AbstractWeapon GetRandomWeapon(int currentLevel);
	AbstractWeapon GetRandomWeapon(int currentLevel, List<AbstractWeapon> alreadyChoosen);

}

[Serializable]
public class WeaponType {
	public string Name;
	public int Level;
}