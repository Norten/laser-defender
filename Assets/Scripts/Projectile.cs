using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
