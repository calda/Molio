using UnityEngine;
using System.Collections;

public class MarioHeadDetection : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "CoinBox"){
			c.gameObject.GetComponent<CoinBlock>().pop();
			gameObject.transform.parent.rigidbody.velocity = Vector3.zero;
		}
	}
	
}
