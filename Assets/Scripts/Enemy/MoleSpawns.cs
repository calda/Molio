using UnityEngine;
using System.Collections;

public class MoleSpawns : MonoBehaviour {
	
	public Vector2[] spawnLocations;
	public Transform mole;
	public Transform enemy;
	public static int count = 0;
	
	void FixedUpdate () {
		if(count < 30){
		if(Random.Range(0, 300) == 42){
			Vector2 location = spawnLocations[Random.Range(0, spawnLocations.Length)];
			Instantiate(mole, new Vector3(location.x, location.y, 0), Quaternion.identity);
			count++;
		}if(Random.Range(0, 70) == 42){
			Vector2 location = spawnLocations[Random.Range(0, spawnLocations.Length)];
			Instantiate(enemy, new Vector3(location.x, location.y, 0), Quaternion.identity);
			count++;
		}
		}
	}
}
