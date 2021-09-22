using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float maxX;
	public float minX;
	public float smoothSpeed = 0.125f;
	public Vector2 offset;
	public float tolerance = 2;

	private FlyJetpack player;

	private void Start() {
		player = target.GetComponent<FlyJetpack>();
	}
	
	void FixedUpdate () {
		if(!player.isDead && player.GetFuel() > 0){
			Vector2 desiredPosition = new Vector2(target.position.x, target.position.y) + offset;
			Vector2 smootedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
			// if(smootedPosition.y > (transform.position.y)){
				transform.position = new Vector3(
										Mathf.Clamp(smootedPosition.x, minX, maxX), 
										smootedPosition.y, -10);
			// }else{
			// 	transform.position = new Vector3(
			// 							Mathf.Clamp(smootedPosition.x, minX, maxX), 
			// 							transform.position.y, -10);
			// }
		}
	}
}
