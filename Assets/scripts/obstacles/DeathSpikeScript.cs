using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpikeScript : MonoBehaviour {
	private ObstacleSpawner obstacleMother;
	private void Start() {
		obstacleMother = ObstacleSpawner.instance;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.transform.tag == "Player"){
			other.transform.GetComponent<FlyJetpack>().isDead = true;
		}
	}
}
