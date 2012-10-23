using UnityEngine;
using System.Collections;

public class EnemyLeftDetection : MonoBehaviour {

	EnemyMotion e;
	public int numberOfCollisions = 0;
	
	void Start(){
		e = transform.parent.GetComponent<EnemyMotion>();
	}
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.layer == 8){
			e.leftColliding = true;
			numberOfCollisions++;
		}
	}void OnTriggerExit(Collider c){
		if(c.gameObject.layer == 8) numberOfCollisions--;
		if(numberOfCollisions == 0) e.leftColliding = false;
	}
	
	
}
