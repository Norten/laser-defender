using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity;

	// Defines bottom left and top right positions of movable zone of player's ship
	private Vector3 bottomLeft;
	private Vector3 topRight;

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
		Move ();
	}

	void Move () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			HandleMove(Vector3.left);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			HandleMove(Vector3.right);
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			HandleMove(Vector3.up);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			HandleMove(Vector3.down);
		}
	}

	void HandleMove (Vector3 moveDirection) {
		var moveVector = moveDirection * velocity * Time.deltaTime;
		transform.position += moveVector;
		var pos = transform.position;
		var clampedX = Mathf.Clamp(pos.x, bottomLeft.x, topRight.x);
		var clampedY = Mathf.Clamp(pos.y, bottomLeft.y, topRight.y);
		transform.position = new Vector3(clampedX, clampedY, pos.z);
	}
}
