using System;
using UnityEngine;

public class BiterBlob : AbstractCharacter {

	private void Start() {
		BaseHP = 100;
		HP = 100;
		Power = 2;
		Speed = 2f;
		Target = Player.Instance.transform;
		Controller.Acting();
	}

}