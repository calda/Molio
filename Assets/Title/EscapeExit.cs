using UnityEngine;
using System.Collections;

public class EscapeExit : MonoBehaviour {

	public void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			Application.LoadLevel("Title");
		}
	}
	
}
