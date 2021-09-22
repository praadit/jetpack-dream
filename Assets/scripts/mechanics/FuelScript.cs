using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour {
	public int fuelAdd = 5;
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Player"){
			other.transform.GetComponent<FlyJetpack>().addFuel(fuelAdd);
			gameObject.SetActive(false);
		}
	}
}
