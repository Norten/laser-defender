using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		var enemy = Instantiate(enemyPrefab, new Vector3(8, 10, 0), Quaternion.FromToRotation(new Vector3(0, 1, 0), new Vector3(0, -1, 0))) as GameObject;
		enemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
