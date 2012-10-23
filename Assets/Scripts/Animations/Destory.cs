using UnityEngine;
using System.Collections;
public class Destory : MonoBehaviour {
	
	
    public void DESTROY()
    {
		if(gameObject.tag == "Coin"){
			MarioMotion.giveCoin(1);
			Destroy(this.gameObject.transform.parent.gameObject);
		}else{
			Destroy(this.gameObject);
			MoleSpawns.count--;
		}
		
    }
	
	void Update(){
		if(transform.position.y < -10){
			MarioMotion mm = gameObject.GetComponent<MarioMotion>();
			if(mm == null) Destroy(gameObject);
			else mm.die();
		}
	}
	
}
