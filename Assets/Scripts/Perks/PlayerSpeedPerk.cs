using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedPerk : Perk {

    private float addition;
	
    public PlayerSpeedPerk() : base("Speed Up", 10, -1, new Color(0.2f, 0.9f, 1f), $"Added 5% to your based speed from start.") {
        addition = 0;
    }

    public override void Apply() {
        if (addition == 0) {
            addition = Player.Instance.BaseSpeed * 0.05f;
        };
        Player.Instance.BaseSpeed += addition;
    }
}