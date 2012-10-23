using UnityEngine;
using System.Collections;

public class CoinBoxTrigger : MonoBehaviour {

	void Start () {
		Destroy(this.gameObject,0.5f);
	}

	void OnTriggerEnter(Collider c){
		Kill.process(c.gameObject, Kill.Method.COINBOX);
	}
	
}
