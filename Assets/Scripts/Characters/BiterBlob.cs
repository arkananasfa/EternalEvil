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
		OnDeath += BLIAAAAAAAAA;
	}

	private void uSuka(float f) {
		Debug.Log($"u suka, {f} urona, {HP} hp");
	}

	private void BLIAAAAAAAAA() {
		Debug.Log("Blyaaaaaaaa");
	}

	private void OnDisable() {
		OnGetDamage -= uSuka;
		OnDeath -= BLIAAAAAAAAA;
	}

}