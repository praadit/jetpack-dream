using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLimitScript : MonoBehaviour {
	public Vector2 offset;
	public Transform target;
	private float maxPosY = 0.0f;
	private float last = 0.0f;

	private SideLimitManager sm;

	private void Start() {
		sm = SideLimitManager.instance;
		InitiatePos();
	}

	private void InitiatePos(){
		transform.position = new Vector2(target.position.x, target.position.y + offset.y);
		maxPosY = transform.position.y;	
		last = maxPosY;
	}

	public void ResetPos(){
		InitiatePos();
	}

	private void FixedUpdate() {
		last = target.position.y + offset.y;
		if(last > maxPosY){
			maxPosY = last;
			transform.position = new Vector2(transform.position.x, maxPosY);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Player"){
			other.transform.GetComponent<FlyJetpack>().KillPlayer();
		}

		if(other.transform.tag == "SideLimit"){
			sm.SpawnNewSide(other.transform);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.transform.tag == "Obstacles"){
			Destroy(other.transform.parent.parent.gameObject);
		}
	}
	
}
