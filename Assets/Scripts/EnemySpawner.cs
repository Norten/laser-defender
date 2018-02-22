using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			var enemy = Instantiate(enemyPrefab, child.position, Quaternion.FromToRotation(new Vector3(0, 1, 0), new Vector3(0, -1, 0))) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
