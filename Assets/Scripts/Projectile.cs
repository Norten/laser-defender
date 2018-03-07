using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject explosionPrefab;
	public float speed = 10f;
	public int Damage { 
		get;
		private set;
	}
	

	// Use this for initialization
	void Start () {
		Damage = 100;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetDirection(Vector2 direction) {
		rigidbody2D.velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<Projectile> ()) {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
