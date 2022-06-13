using UnityEngine;

public class MaxHpPerk : Perk {

	private float addition;
	
	public MaxHpPerk() : base("Max Hp Up", 10, -1, new Color(0.2f, 0.5f, 0.2f), $"Added 10% to your max hp from start.") {
		addition = 0;
	}

	public override void Apply() {
		if (addition == 0) {
			addition = Player.Instance.BaseHP * 0.1f;
		};
		Player.Instance.BaseHP += addition;
	}
}