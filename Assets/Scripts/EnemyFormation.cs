using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public static float TimeFromLastShoot {
		get;
		private set;
	}

	// Use this for initialization
	void Start () {
		TimeFromLastShoot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		TimeFromLastShoot += Time.deltaTime;
	}

	public static void Fire () {
		TimeFromLastShoot = 0f;
	}
}
