using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void Start(){
		Destroy(gameObject,3f);
	}
	
	void Update () {
	
		transform.Translate(Vector3.left * Time.deltaTime * 11);
		
	}
	
	void OnTriggerEnter(Collider c){
		
		Kill.process(c.gameObject, Kill.Method.SHOOT, gameObject);
		
	}
}
