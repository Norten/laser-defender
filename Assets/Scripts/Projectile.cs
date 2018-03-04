using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 10f;
	public int Damage { 
		get;
		private set;
	}

	// Use this for initialization
	void Start () {
		Damage = 100;
		rigidbody2D.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
