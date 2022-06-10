using System;
using UnityEngine;

public class HPBar : MonoBehaviour {

	private Transform HPBarContent;
	private IHP owner;
	private SpriteRenderer contentRenderer;
	private SpriteRenderer backRenderer;
	
	private void Awake() {
		HPBarContent = transform.GetChild(0);
		owner = transform.parent.GetComponent<IHP>();
		contentRenderer = HPBarContent.GetComponent<SpriteRenderer>();
		backRenderer = GetComponent<SpriteRenderer>();
		contentRenderer.enabled = false;
		backRenderer.enabled = false;
	}

	private void OnEnable() {
		owner.OnGetDamage += UpdateHP;
	}

	public void UpdateHP(float lostHP) {
		float dif = lostHP / owner.BaseHP;
		contentRenderer.enabled = true;
		backRenderer.enabled = true;
		HPBarContent.localScale -= new Vector3(dif, 0, 0);
		HPBarContent.localPosition -= new Vector3(dif / 2, 0, 0);
		if (HPBarContent.localScale.x < 0) {
			HPBarContent.localScale = Vector3.zero;
		}
	}

	private void OnDisable() {
		owner.OnGetDamage -= UpdateHP;
	}

}