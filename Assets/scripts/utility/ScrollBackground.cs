using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
	public float speed = 0.5f;
	public Transform target;
	private Vector2 offset;
	private Renderer render;
	

	private void Start() {
		render = GetComponent<Renderer>();
	}
		
	void Update () {
		offset = new Vector2(0, target.position.y);
		render.material.SetTextureOffset("_MainTex", offset);
	}
	void FixedUpdate () {
		transform.position = new Vector2(transform.position.x, target.position.y);
	}
}
