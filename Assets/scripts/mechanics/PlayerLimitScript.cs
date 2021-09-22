using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitScript : MonoBehaviour {
	public Vector2 offset;

	public Transform target;
	
	void FixedUpdate () {
		transform.position = new Vector2(transform.position.x, target.position.y + offset.y);
	}
}
