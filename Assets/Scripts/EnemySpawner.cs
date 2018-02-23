using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 12f;
	public float height = 5.5f;
	// Use this for initialization
	void Start () {
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
	
	}
}
