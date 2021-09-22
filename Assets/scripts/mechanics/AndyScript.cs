using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyScript : MonoBehaviour {
	public Sprite andyIdle;
	public Sprite andyFall;
	public Sprite[] andyFly;
	public float delay;
	private SpriteRenderer mrender;
	private float clickTime = 0;
	private int currentFly = 0;

	private FlyJetpack jetpack;
	private ObstacleSpawner obstacleMother;
	private GameManager gameManager;

	void Start () {
		obstacleMother = ObstacleSpawner.instance;
		gameManager = GameManager.instance;
		jetpack = GetComponent<FlyJetpack>();
		mrender = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(!jetpack.isDead){
			if(jetpack.GetFuel() > 0){
				if(jetpack.oneTap){
					if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
						mrender.sprite = andyFly[currentFly];

						if(currentFly == 0) currentFly = 1;
						else currentFly = 0;

						clickTime = delay;
					}
				}else{
					if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)
						|| Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
						|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
						mrender.sprite = andyFly[currentFly];

						if(currentFly == 0) currentFly = 1;
						else currentFly = 0;

						clickTime = delay;
					}
				}
				
				if(clickTime < 0){
					mrender.sprite = andyIdle;
				}			

				if(clickTime > 0){
					clickTime -= Time.deltaTime;
				}
			}else{
				mrender.sprite = andyFall;
			}
		}else{
			mrender.sprite = andyFall;
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.transform.tag == "Obstacles"){
			jetpack.KillPlayer();
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.transform.tag == "ObsTrigger"){
			if(other.transform.GetComponent<ObstacleScript>().addingScore){
				if(!jetpack.isDead){
					obstacleMother.SpawnObstacle();
					other.transform.GetComponent<ObstacleScript>().addingScore = false;
					gameManager.AddScore();
				}
			}			
		}
	}
}
