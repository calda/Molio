using UnityEngine;
using System.Collections;

public class ACCO : MonoBehaviour {
	
	public Animation a;
	
	void Update () {
	
		if(!a.isPlaying){
			Application.LoadLevel("Title");
		}
		
	}
}
