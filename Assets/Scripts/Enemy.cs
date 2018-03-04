using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosion;

	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
		Instantiate(explosion, transform.position, Quaternion.identity);
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
