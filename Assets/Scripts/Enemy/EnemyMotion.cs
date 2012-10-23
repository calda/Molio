using UnityEngine;
using System.Collections;

public class EnemyMotion : MonoBehaviour {

	public bool goLeft = false;
	public bool leftColliding = false;
	public bool rightColliding = false;
	public int speed;
	public Transform coin;
	public Animation die;
	public Transform texture;
	public bool dying = false;
	private AnimationManager ani;
	
	void Start(){
		if(Random.Range(0,2) == 1) goLeft = true;
		if(gameObject.tag == "Enemy") Physics.IgnoreCollision(collider, GameObject.Find("Character").collider);
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy")){
			Physics.IgnoreCollision(collider, go.collider);
		}foreach(GameObject go in GameObject.FindGameObjectsWithTag("Mole")){
			Physics.IgnoreCollision(collider, go.collider);
		}
		ani = texture.gameObject.GetComponent<AnimationManager>();
	}
	
	void Update () {
	
		if(!dying){
			if(goLeft) transform.Translate(Vector3.left * Time.deltaTime * speed);
			else transform.Translate(Vector3.right * Time.deltaTime * speed);
		
			if(goLeft && !leftColliding){
				goLeft = false;
			}
			else if(!goLeft && !rightColliding){
				goLeft = true;
			}
			
			if(!ani.animating){
				if(Random.Range(0,100) == 4) ani.StartAnimation();
			}
			
		}
		
	}
	
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Player" && !dying && gameObject.tag != "Mole") MarioMotion.numberOfLives--;
	}

	public void kill(bool dropCoin){
		if(dropCoin) Instantiate(coin, transform.position, Quaternion.identity);
		die.Play();
		dying = true;
	}
	
}
