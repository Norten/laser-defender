using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 12f;
	public float height = 5.5f;
	public float velocity = 5f;

	private float minX;
	private float maxX;
	// Use this for initialization
	void Start () {
		var camDistance = transform.position.z - Camera.main.transform.position.z;
		minX = Camera.main.ViewportToWorldPoint(new Vector3 (0, 0, camDistance)).x;
		maxX = Camera.main.ViewportToWorldPoint(new Vector3 (1, 0, camDistance)).x;
		minX += width / 2;
		maxX -= width / 2;
		foreach (Transform child in transform) {
			var enemy = Instantiate(enemyPrefab, child.position, Quaternion.FromToRotation(new Vector3(0, 1, 0), new Vector3(0, -1, 0))) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move () {
		var moveDistance = new Vector3 (velocity, 0, 0) * Time.deltaTime;
		var newPos = transform.position + moveDistance;
		newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
		if (newPos.x >= maxX || newPos.x <= minX) {
			velocity = -velocity;
			newPos.y -= Mathf.Abs(velocity) * Time.deltaTime;
		}
		transform.position = newPos;
	}
}
