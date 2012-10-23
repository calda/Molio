using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public Transform button;
	
	void OnMouseUpAsButton(){
		Application.Quit();
	}
	
	void OnMouseEnter(){
		button.renderer.material.mainTextureOffset = new Vector2(0, 0f);
	}
	
	void OnMouseExit(){
		button.renderer.material.mainTextureOffset = new Vector2(0, 0.25f);
	}
}