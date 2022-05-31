using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider2D))]
public class PlayerController : MovingCharacter {

	[SerializeField] private GameObject weaponRotator;
	private GameObject weaponGameObject;
	private SpriteRenderer weaponSprite;
	//private IWeapon weapon;
	private Animator playerAnimator;

	private static readonly int IsMoving = Animator.StringToHash("isMoving");
	private Camera mainCamera;
	
	protected override void Awake() {
		base.Awake();
		playerAnimator = GetComponent<Animator>();
	}

	protected override void Start() {
		base.Start();
		mainCamera = Camera.main;
		weaponGameObject = weaponRotator.transform.GetChild(0).gameObject;
		//weapon = weaponGameObject.GetComponent<IWeapon>();
		weaponSprite = weaponGameObject.GetComponent<SpriteRenderer>();
		Debug.Log(Application.platform.ToString());
	}

	private void Update() {
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");
		Velocity = new Vector2(hor, ver)*Speed*Time.fixedDeltaTime;
		playerAnimator.SetBool(IsMoving, Velocity!=Vector2.zero);
		Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

		bool isRight = mousePosition.x > transform.position.x;
		Body.rotation = Quaternion.Euler(0, isRight?0:180, 0);
		weaponSprite.flipY = !isRight;
		weaponRotator.transform.right = mousePosition-(Vector2)weaponRotator.transform.position;

		if (Input.GetMouseButton(0)) {
			//weapon.OnAttack?.Invoke();
		}
		
	}
	
}