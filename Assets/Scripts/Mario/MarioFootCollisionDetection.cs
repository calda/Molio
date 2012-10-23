using UnityEngine;
using System.Collections;

public class MarioFootCollisionDetection : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.gameObject.layer == 8) MarioMotion.onGround = true;
		if(c.tag == "CoinBox" && MarioMotion.crouching){
			c.gameObject.GetComponent<CoinBlock>().pop();
		}
	}void OnTriggerStay(Collider c){
		if(c.gameObject.layer == 8) MarioMotion.onGround = true;
	}void OnTriggerExit(Collider c){
		if(c.gameObject.layer == 8) MarioMotion.onGround = false;
	}
}
