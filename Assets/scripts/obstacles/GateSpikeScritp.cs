using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpikeScritp : MonoBehaviour {
	public float movingSpeed = 1;
	public GameObject spikeKiri;
	public GameObject spikeKanan;

	public Vector2[] maxTransform;
	public Vector2[] minTransform;
	public bool buka;

	private void FixedUpdate() {
		if(buka){
			if(spikeKanan != null) spikeKiri.transform.position = new Vector2(spikeKiri.transform.position.x, spikeKiri.transform.position.y) - new Vector2(movingSpeed/100, 0);
			if(spikeKanan != null) spikeKanan.transform.position = new Vector2(spikeKanan.transform.position.x, spikeKanan.transform.position.y) + new Vector2(movingSpeed/100, 0);
		}else{
			if(spikeKanan != null) spikeKiri.transform.position = new Vector2(spikeKiri.transform.position.x, spikeKiri.transform.position.y) +  new Vector2(movingSpeed/100, 0);
			if(spikeKanan != null) spikeKanan.transform.position = new Vector2(spikeKanan.transform.position.x, spikeKanan.transform.position.y) -  new Vector2(movingSpeed/100, 0);
		}

		if(spikeKiri.transform.position.x <= minTransform[0].x){
			buka = false;
		}

		if(spikeKiri.transform.position.x >= maxTransform[0].x){
			buka = true;
		}
	}
}
