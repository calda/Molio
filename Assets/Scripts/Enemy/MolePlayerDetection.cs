using UnityEngine;
using System.Collections;

public class MolePlayerDetection : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player" && !transform.parent.gameObject.GetComponent<EnemyMotion>().dying){
			MarioMotion.giveMole();
			Destroy(transform.parent.gameObject);
			MoleSpawns.count--;
		}
	}
}
