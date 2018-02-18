using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity;

	// Use this for initialization
	void Start () {
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
	}
}
