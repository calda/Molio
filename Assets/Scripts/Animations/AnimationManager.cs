using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public bool pingPong;
	public int numberOfPlays = 1;
	public Vector2[] frames;
	public Vector2[] leftFrames;
	
	private int frameNumber = 0;
	private int numberOfPlaysComplete = 0;
	private bool ponging = false;
	public bool animating = true;
	public EnemyMotion em;
	public bool doWalkingFlip;
	
	void Start(){
		transform.renderer.material.mainTextureOffset = frames[0];
		em = transform.parent.GetComponent<EnemyMotion>();
	}
	
	void FixedUpdate(){
		if(animating) AdvanceFrame();
	}
	
	private void AdvanceFrame(){
		if(!ponging){
			frameNumber++;
			if(frameNumber > frames.Length-1){
				if(pingPong){ 
					ponging = true;
					frameNumber -= 2;
				}else cycleComplete();	
			}
		}else{
			frameNumber--;
			if(frameNumber <= 0) cycleComplete();
		}transform.renderer.material.mainTextureOffset = getFrame(frameNumber);
	}
	
	private void cycleComplete(){
		numberOfPlaysComplete++;
		frameNumber = 0;
		if(ponging) ponging = false;
		if(numberOfPlaysComplete >= numberOfPlays){
			animating = false;
			numberOfPlaysComplete = 0;
		}
	}
	
	public void StartAnimation(){
		animating = true;
	}
	
	private Vector2 getFrame(int i){
		if(!doWalkingFlip) return frames[i];
		else{
			if(em.goLeft) return leftFrames[i];
			else return frames[i];
		}
	}
	
}
