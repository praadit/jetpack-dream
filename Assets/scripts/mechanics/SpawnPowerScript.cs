using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerScript : MonoBehaviour {
	public float probabilityInPercent = 50;
	public void SpawnPower(int fuel = 15){
		if(Random.value <= (probabilityInPercent/100)){
			transform.GetChild(0).GetComponent<FuelScript>().fuelAdd = fuel;
			transform.GetChild(0).gameObject.SetActive(true);
		}else{
			transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
