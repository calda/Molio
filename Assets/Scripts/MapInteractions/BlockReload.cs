using UnityEngine;
using System.Collections;

public class BlockReload : MonoBehaviour {

	public int numberOfTicks = 0;
	private Vector3 location;
	private Quaternion rotation;
	
	// Update is called once per frame
	void Update () {
		numberOfTicks++;
		if(numberOfTicks >= 500){
			Transform t = Instantiate(CoinBlock.coinBox, location, rotation) as Transform;
			if(Random.Range(0,4) == 3){
				CoinBlock c = t.GetComponent<CoinBlock>();
				c.dropMushroom = true;
			}Destroy(gameObject);
		}
	}
	
	public void setVector(Vector3 loc, Quaternion rot){
		location = loc;
		rotation = rot;
	}
}
