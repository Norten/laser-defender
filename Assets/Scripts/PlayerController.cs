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
			HandleMove(new Vector2 (-1.0f, 0.0f));
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			HandleMove(new Vector2 (1.0f, 0.0f));
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			HandleMove(new Vector2 (0.0f, 1.0f));
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			HandleMove(new Vector2 (0.0f, -1.0f));
		}
	}

	void HandleMove (Vector2 moveDirection) {
		var moveVector = new Vector3 (moveDirection.x * velocity, moveDirection.y * velocity, 0.0f) * Time.deltaTime;
		transform.position += moveVector;
	}
}
