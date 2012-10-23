using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Player"){
			MarioMotion.giveLife(1);
			Destroy(gameObject);
		}
	}
	
}
