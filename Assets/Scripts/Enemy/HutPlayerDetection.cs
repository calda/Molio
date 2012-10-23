using UnityEngine;
using System.Collections;

public class HutPlayerDetection : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			MarioMotion.molesInHuts();
		}
	}
}
