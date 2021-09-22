using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {
	public float rotationSpeed = 100;
	public GameObject[] spinners;
	public bool rotateRight;

	void Start () {
		
	}

	void Update () {
		if(spinners.Length == 1){
			if(rotateRight){
				spinners[0].transform.Rotate(new Vector3(0,0,-1) * (rotationSpeed * Time.deltaTime));
			}else{
				spinners[0].transform.Rotate( new Vector3(0,0,1) * (rotationSpeed * Time.deltaTime));
			}
		}else if(spinners.Length == 2){
			if(rotateRight){
				spinners[0].transform.Rotate(new Vector3(0,0,-1) * (rotationSpeed * Time.deltaTime));
				spinners[1].transform.Rotate(new Vector3(0,0,1) * (rotationSpeed * Time.deltaTime));
			}else{
				spinners[0].transform.Rotate(new Vector3(0,0,1) * (rotationSpeed * Time.deltaTime));
				spinners[1].transform.Rotate(new Vector3(0,0,-1) * (rotationSpeed * Time.deltaTime));
			}
		}
	}
}
