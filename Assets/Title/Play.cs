using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	
	bool over = false;
	public Transform button;
	
	void OnMouseUpAsButton(){
		Application.LoadLevel("Mario");
	}
	
	void OnMouseEnter(){
		button.renderer.material.mainTextureOffset = new Vector2(0, 0.5f);
	}
	
	void OnMouseExit(){
		button.renderer.material.mainTextureOffset = new Vector2(0, 0.75f);
	}
}
