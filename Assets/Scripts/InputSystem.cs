using System;
using UnityEngine;

public class InputSystem : MonoBehaviour {

	public Vector2 movingVector { get; set; }
	public Vector2 attackingVector { get; set; }
	public bool IsAttacking { get; set; }

	private Camera mainCamera;
	private Transform player;
	private UIManager UI;

	public static InputSystem Instance;

	private void Awake() {
		Instance = this;
	}

	private void Start() {
		mainCamera = Camera.main;
		player = Player.Instance.transform;
		UI = UIManager.Instance;
	}

	private void Update() {
		if (UI.DebugMode) {
			movingVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			attackingVector = mousePosition - (Vector2)player.position;
			IsAttacking = Input.GetMouseButton(0);
		} else {
			// Take control from joysticks
		}
	}

}