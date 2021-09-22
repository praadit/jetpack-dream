using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineScript : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		// if(other.transform.tag == "Player"){
		// 	other.transform.GetComponent<FlyJetpack>().isDead = true;
		// 	//Boleh restart
		// 	//Reset spawner
		// }
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.transform.tag == "Obstacles"){
			Destroy(other.transform.parent.parent.gameObject);
		}
	}
}
