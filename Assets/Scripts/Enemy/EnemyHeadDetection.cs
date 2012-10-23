using UnityEngine;
using System.Collections;

public class EnemyHeadDetection : MonoBehaviour {
	
	void OnTriggerEnter(Collider c){
		
		if(c.tag == "Player"){
			if(MarioMotion.crouching){
				Kill.process(transform.parent.gameObject, Kill.Method.SQUISH);
			}else{
				if(!transform.parent.gameObject.GetComponent<EnemyMotion>().dying) c.gameObject.rigidbody.velocity = Vector3.up * 15;
			}
		}
		
	}
}
