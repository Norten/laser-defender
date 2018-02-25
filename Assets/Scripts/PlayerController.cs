﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity;
	public GameObject projectilePrefab;

	// Defines bottom left and top right positions of movable zone of player's ship
	private Vector3 bottomLeft;
	private Vector3 topRight;
	private float timeToNextFire;

	// Use this for initialization
	void Start () {
		var cameraDistance = transform.position.z - Camera.main.transform.position.z;
		bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraDistance));
		topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.4f, cameraDistance));
		var halfWidth = gameObject.renderer.bounds.size.x / 2;
		var halfHeight = gameObject.renderer.bounds.size.y / 2;
		bottomLeft += new Vector3(halfWidth, halfHeight, 0);
		topRight -= new Vector3(halfWidth, halfHeight, 0);
	}
	
	// Update is called once per frame
	void Update () {
		HandleMove ();
		HandleFire ();

	}

	void HandleMove () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			Move(Vector3.left);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			Move(Vector3.right);
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			Move(Vector3.up);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			Move(Vector3.down);
		}
	}

	void Move (Vector3 moveDirection) {
		var moveVector = moveDirection * velocity * Time.deltaTime;
		transform.position += moveVector;
		var pos = transform.position;
		var clampedX = Mathf.Clamp(pos.x, bottomLeft.x, topRight.x);
		var clampedY = Mathf.Clamp(pos.y, bottomLeft.y, topRight.y);
		transform.position = new Vector3(clampedX, clampedY, pos.z);
	}

	void HandleFire () {
		timeToNextFire = Mathf.Clamp01(timeToNextFire - Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.Space) && timeToNextFire <= 0f) {
			const float repeatInvokingAfter = 1f;
			InvokeRepeating("Fire", timeToNextFire, repeatInvokingAfter);
			timeToNextFire = repeatInvokingAfter;
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke();
		}
	}

	void Fire () {
		var projectilePos = new Vector3 (transform.position.x, transform.position.y + renderer.bounds.size.y / 2);
		Instantiate(projectilePrefab, projectilePos, Quaternion.identity);
	}
}
