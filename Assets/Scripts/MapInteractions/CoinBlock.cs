using UnityEngine;
using System.Collections;

public class CoinBlock : MonoBehaviour {
	
	public Transform coin;
	public Transform mushroom;
	public Transform waiter;
	public static Transform coinBox = null;
	public bool dropMushroom = false;
	public int numberOfCoins;
	public Transform coinboxtrigger;
	
	public void Start(){
		if(coinBox == null) coinBox = transform;
	}
	
	public void pop(){
		Instantiate(coinboxtrigger, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
		if(dropMushroom){
			Instantiate(mushroom, new Vector3(transform.position.x, transform.position.y + 1,0), Quaternion.identity);
			numberOfCoins--;
		}else{
			Instantiate(coin, transform.position, Quaternion.identity);
			numberOfCoins--;
		}if(numberOfCoins <= 0){ 
			Transform t = Instantiate(waiter, transform.position, Quaternion.identity) as Transform;
			t.GetComponent<BlockReload>().setVector(transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
	
}
