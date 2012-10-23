using UnityEngine;
using System.Collections;

public class EnemyPlayerDetection : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player" && !transform.parent.gameObject.GetComponent<EnemyMotion>().dying){
			MarioMotion.numberOfLives--;
		}
	}
}
