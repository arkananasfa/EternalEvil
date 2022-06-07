using UnityEngine;

public class InputSystem : MonoBehaviour {

	public bool isAndroid;
	
	public Vector2 movingVector;
	public Vector2 attackingVector;

	private Camera mainCamera;
	private Transform player;
	private UIManager UI;
	
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
		} else {
			// Take movement from joysticks
		}
	}

}