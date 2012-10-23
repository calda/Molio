using UnityEngine;
using System.Collections;

public class EnemyRightDetection : MonoBehaviour {

	EnemyMotion e;
	public int numberOfCollisions = 0;
	
	void Start(){
		e = transform.parent.GetComponent<EnemyMotion>();
	}
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.layer == 8){
			e.rightColliding = true;
			numberOfCollisions++;
		}
	}void OnTriggerExit(Collider c){
		if(c.gameObject.layer == 8) numberOfCollisions--;
		if(numberOfCollisions == 0) e.rightColliding = false;
	}
	
	
}
