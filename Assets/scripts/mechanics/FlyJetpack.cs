using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyJetpack : MonoBehaviour {

	public float velocity = 1;
	public float jumpPower = 1;
	public float sideDivider = 1;
	public int startFuel = 25;
	public int maxFuel = 40;
	public bool unlimitedFuel = false;
	public bool oneTap;
	public bool isDead = false;
	private Rigidbody2D rb;
	private int myFuel;

	private bool toggleLeft = false;
	
	private UiManager ui;

	// Use this for initialization
	void Start () {
		myFuel = startFuel;

		rb = GetComponent<Rigidbody2D>();
		
		ui = UiManager.instance;
		ui.RefreshFuel(myFuel);
	}
	
	// Update is called once per frame
	void Update () {
		if(myFuel>0 && !isDead){
			if(!oneTap){
				if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
					ui.HideWelcome();
					rb.velocity = ((Vector2.up * jumpPower) + (Vector2.left / sideDivider)) * velocity;
					consumeFuel();
				}else if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
					ui.HideWelcome();
					rb.velocity = ((Vector2.up * jumpPower) + (Vector2.right/ sideDivider)) * velocity;
					consumeFuel();
				}
			}else{
				if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
					ui.HideWelcome();
					
					if(toggleLeft){
						rb.velocity = ((Vector2.up * jumpPower) + (Vector2.left / sideDivider)) * velocity;
						consumeFuel();
					}else{
						rb.velocity = ((Vector2.up * jumpPower) + (Vector2.right / sideDivider)) * velocity;
						consumeFuel();
					}
					
					toggleLeft = !toggleLeft;
				}
			}
		}
	}

	private void consumeFuel(){		
		if(!unlimitedFuel){ 
			myFuel--;
			ui.RefreshFuel(myFuel);
		}
	}

	public int GetFuel(){
		return myFuel;
	}

	public void addFuel(int amount){
		if(myFuel + amount <= maxFuel){
			myFuel += amount;
		}else{
			myFuel = maxFuel;
		}

		ui.RefreshFuel(myFuel);
	}

	public void resetFuel(){
		myFuel = startFuel;

		ui.RefreshFuel(myFuel);
	}

	public void KillPlayer(){
		isDead = true;
	}
}
