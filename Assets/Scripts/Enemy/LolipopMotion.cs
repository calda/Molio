using UnityEngine;
using System.Collections;

public class LolipopMotion : MonoBehaviour {

	public bool goLeft = false;
	public int speed;
	public Transform coin;
	public Animation die;
	
	void Start(){
		int goLeftInt = Random.Range(0,2);
		Debug.Log(goLeftInt);
		if(goLeftInt == 1) goLeft = true;
	}
	
	void Update () {
	
		if(goLeft) transform.Translate(Vector3.left * Time.deltaTime * speed);
		else transform.Translate(Vector3.right * Time.deltaTime * speed);
		
	}
	
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Player"){
			MarioMotion.setButtonColor(MarioMotion.ButtonColor.RED);
			Destroy(gameObject);
		}

	}

	
}
