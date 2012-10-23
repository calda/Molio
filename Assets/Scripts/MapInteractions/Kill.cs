using UnityEngine;
using System.Collections;

public class Kill:MonoBehaviour{
	
	public enum Method{
		SQUISH,
		SHOOT,
		COINBOX
	}
	
	public static bool process(GameObject go, Method m){
		
		if(go.tag == "Enemy"){
			EnemyMotion em = go.GetComponent<EnemyMotion>();
			if(em != null){
				if(m == Method.COINBOX) em.kill(true);
				else if(m == Method.SQUISH) em.kill(true);
				else if(m == Method.SHOOT) em.kill(false);
				return true;
			}
		}return false;
	}
	
	public static void process(GameObject go, Method m, GameObject d){
		if(process(go,m)) Destroy(d);
	}
	
	public static void process(GameObject go, Method m, GameObject d, float time){
		if(process(go,m)) Destroy(d);
	}
	
}
