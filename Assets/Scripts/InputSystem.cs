using System;
using UnityEngine;

public class InputSystem : MonoBehaviour {

	[SerializeField] private Joystick moveJoystick;
	[SerializeField] private Joystick attackJoystick;
	
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

	private void OnEnable() {
		GameLoopEvents.OnGameLost += GameLost;
	}

	private void OnDisable() {
		GameLoopEvents.OnGameLost -= GameLost;
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
			movingVector = moveJoystick.Direction;
			attackingVector = attackJoystick.Direction;
			IsAttacking = attackJoystick.Direction != Vector2.zero;
		}
	}

	private void GameLost() {
		player = transform;
	}

}