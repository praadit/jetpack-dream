using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
	public bool activeMoving = true;
	public float movingSpeed = 1;
	public float maxX = 1;
	public float minX = -1;
	public bool moveRight = false;
	public GameObject movingTarget;
	private ObstacleSpawner obstacleMother;
	public bool addingScore = true;
	
	void Start () {
		obstacleMother = ObstacleSpawner.instance;
	}
	
	void FixedUpdate() {
		if(activeMoving){
			if(moveRight){
				Vector2 desiredPosition = new Vector2(movingTarget.transform.position.x, movingTarget.transform.position.y) + new Vector2(movingSpeed/100, 0);
				movingTarget.transform.position = new Vector2(desiredPosition.x, desiredPosition.y);
			}else{
				Vector2 desiredPosition = new Vector2(movingTarget.transform.position.x, movingTarget.transform.position.y) - new Vector2(movingSpeed/100, 0);
				movingTarget.transform.position = new Vector2(desiredPosition.x, desiredPosition.y);
			}

			if(movingTarget.transform.position.x <= minX){
				moveRight = true;
			}

			if(movingTarget.transform.position.x >= maxX){
				moveRight = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		// if(other.transform.tag == "Player"){
		// 	obstacleMother.SpawnObstacle();
		// 	//Tambah score
		// }
	}
}
