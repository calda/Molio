using UnityEngine;
using System.Collections;

public class MarioMotion : MonoBehaviour {
	
	public Transform ButtonTexture;
	private Vector3 checkpoint;
	public GUIText coins;
	public GUIText molesActive;
	public GUIText molesSaved;
	public GUIText textLives;
	public Animation death;
	public Transform bullet;
	public GUIText death1;
	public GUIText death2;
	
	public static Transform ButtonTextureStatic;
	public static int numberOfLives = 1;
	private static int numberOfCoins = 0;
	private static bool updateGUI = false;
	private bool lastDirectionWasLeft = false;
	public static bool onGround = false;
	public static bool crouching = false;
	public static ButtonColor button = ButtonColor.BLUE;
	public static int numberOfMolesActive = 0;
	public static int numberOfMolesSaved = 0;
	public static int lives = 3;
	
	
	public enum ButtonColor{
		BLUE,RED,GOLD
	}
	
	
	void Start(){
		death1.enabled = false;
		death2.enabled = false;
		checkpoint = transform.position;
		ButtonTextureStatic = ButtonTexture;
		numberOfMolesActive = 0;
		numberOfMolesSaved = 0;
		button = ButtonColor.BLUE;
		updateGUI = false;
		numberOfCoins = 0;
		numberOfLives = 1;
		MoleSpawns.count = 0;
		lives = 4;
	}
	
	void Update () {
		
		if(numberOfLives <= 0){
			Debug.Log(lives);
			die();
			Debug.Log(lives);
			if(lives == 0){
				death1.enabled = true;
				death2.enabled = true;
				Destroy(gameObject);
			}
		}
		
		if(!crouching && !death.isPlaying){
			if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -10.8){
				transform.Translate(Vector3.left * Time.deltaTime * 10);
				if(!lastDirectionWasLeft){
					ButtonTexture.renderer.material.mainTextureOffset = new Vector2(0.125f, ButtonTexture.renderer.material.mainTextureOffset.y);
					lastDirectionWasLeft = true;
				}
			}if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < 23.4){
				transform.Translate(Vector3.right * Time.deltaTime * 10);
				if(lastDirectionWasLeft){
					ButtonTexture.renderer.material.mainTextureOffset = new Vector2(0f, ButtonTexture.renderer.material.mainTextureOffset.y);
					lastDirectionWasLeft = false;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
				if(onGround){
					rigidbody.velocity = Vector3.up * 15;
					onGround = false;
				}
			}if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
				if(!onGround) rigidbody.velocity = Vector3.down * 15;
			}
			
			if(Input.GetKeyDown(KeyCode.Space) && button == ButtonColor.RED){
				if(!lastDirectionWasLeft) Instantiate(bullet, transform.position, new Quaternion(0,0,-180,0));
				else Instantiate(bullet, transform.position, Quaternion.identity);
			}
		}
		
		if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !death.isPlaying){
			if(!crouching){
				transform.localScale = new Vector3(0.72f,0.5f,1f);
				transform.Translate(0f,-0.25f,0f);
			}crouching = true;
		}else{
			if(crouching){
				transform.localScale = new Vector3(0.72f,1f,1f);
				transform.Translate(0f,0.25f,0f);
			}crouching = false;
		}
		
		//Camera.mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.mainCamera.transform.position.z);
		if(updateGUI) doUpdateGUI();
	}
	
	public void die(){
		if(!death.isPlaying){
			lives--;
			updateGUI = true;
			death.Play();
		}
	}
	
	public void respawn(){
		numberOfMolesActive = 0;
		transform.position = checkpoint;
		rigidbody.velocity = Vector3.zero;
		numberOfLives = 1;
		setButtonColor(ButtonColor.BLUE);
	}
	
	private void doUpdateGUI(){
		string numberOfCoinsOutput = "";
		if(numberOfCoins < 10) numberOfCoinsOutput = "00" + numberOfCoins;
		else if(numberOfCoins < 100) numberOfCoinsOutput = "0" + numberOfCoins;
		else numberOfCoinsOutput = "" + numberOfCoins;
		coins.text = numberOfCoinsOutput;
		molesSaved.text = "Saved: " + MarioMotion.numberOfMolesSaved;
		molesActive.text = "Carrying " + MarioMotion.numberOfMolesActive + " Moles";
		textLives.text = lives + "";
		updateGUI = false;
	}
	
	public static void giveCoin(int amount){
		numberOfCoins+= amount;
		updateGUI = true;
	}
	
	public static void giveMole(){
		numberOfMolesActive++;
		updateGUI = true;
	}
	
	public static void molesInHuts(){
		numberOfMolesSaved += numberOfMolesActive;
		numberOfMolesActive = 0;
		updateGUI = true;
	}
	
	public static void giveLife(int amount){
		numberOfLives++;
		updateGUI = true;
	}
	
	public static void setButtonColor(ButtonColor color){
		button = color;
		if(color == ButtonColor.BLUE) ButtonTextureStatic.renderer.material.mainTextureOffset = new Vector2(ButtonTextureStatic.renderer.material.mainTextureOffset.x, 0.875f);
		else if(color == ButtonColor.RED) ButtonTextureStatic.renderer.material.mainTextureOffset = new Vector2(ButtonTextureStatic.renderer.material.mainTextureOffset.x, 0.75f);
		else if(color == ButtonColor.GOLD) ButtonTextureStatic.renderer.material.mainTextureOffset = new Vector2(ButtonTextureStatic.renderer.material.mainTextureOffset.x, 0.625f);
	}
	
}
