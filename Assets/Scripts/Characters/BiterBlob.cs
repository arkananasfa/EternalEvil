using System;
using UnityEngine;

public class BiterBlob : AbstractCharacter {

	protected override void Awake() {
		base.Awake();
		HP = 100;
		Power = 2;
		Speed = 0;
	}

	private void OnEnable() {
		OnGetDamage += uSuka;
	}

	private void uSuka(float f) {
		Debug.Log($"{f}/{HP}");
	}

	private void OnDisable() {
		OnGetDamage -= uSuka;
	}

}