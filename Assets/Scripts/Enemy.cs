using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosionPrefab;
	public GameObject projectilePrefab;
	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		var projectile = collider.gameObject.GetComponent<Projectile>();
		if (projectile) {
			Hit (projectile.Damage);
			Destroy(collider.gameObject);
		}
	}

	public void Hit(int damage) {
		health -= damage;
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	private void Fire () {
		if (EnemyFormation.TimeFromLastShoot > 1f && Random.value > 0.9f) {
			var startPosition = transform.position + new Vector3(0, -1);
			var projectile = Instantiate(projectilePrefab, startPosition, Quaternion.FromToRotation(Vector3.up, Vector3.down)) as GameObject;
			projectile.GetComponent<Projectile>().SetDirection(-Vector2.up);
			EnemyFormation.Fire();
		}
	}
}
