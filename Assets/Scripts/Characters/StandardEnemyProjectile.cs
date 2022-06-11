using UnityEngine;

public class StandardEnemyProjectile : AbstractBullet {

	protected override void OnTriggerEnter2D(Collider2D other) {
		switch ((ObjectsLayers)other.gameObject.layer) {
			case ObjectsLayers.Player :
				other.GetComponent<IHP>().GetDamage(Damage);
				Destroy(gameObject);
				break;
			case ObjectsLayers.Enemie :
				break;
			default:
				Destroy(gameObject);
				break;
		}
	}


}