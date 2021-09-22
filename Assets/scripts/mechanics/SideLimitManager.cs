using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLimitManager : MonoBehaviour {
	#region Singleton
	public static SideLimitManager instance;
	private void Awake() {
		if(instance==null){
			instance = this;
		}else{
			Destroy(this.gameObject);
		}
	}
	#endregion
	public GameObject sidePrefab;
	public Transform sideInitPoint;
	public GameObject holder;
	private GameObject lastSide;


	private void Start() {
		initSideLimit();
	}

	private void initSideLimit(){
		holder = new GameObject();
		holder.name = "SideLimitHolder";
		holder.transform.parent = GameObject.Find("_Limit").transform;
		lastSide = null;
		GameObject newSide = Instantiate(sidePrefab, sideInitPoint.position, Quaternion.identity);
		newSide.transform.parent = holder.transform;
	}

	public void RestartSide(){
		Destroy(holder);
		initSideLimit();
	}
	
	public void SpawnNewSide(Transform lastEntered){
		Vector3 spawnPoin = lastEntered.GetChild(0).transform.position;
		GameObject newSide = Instantiate(sidePrefab, spawnPoin, Quaternion.identity);
		newSide.transform.parent = holder.transform;
		DestroyLastSide(lastEntered);

		lastSide = lastEntered.gameObject;
	}

	public void DestroyLastSide(Transform lastEntered){
		if(lastSide != null){ Destroy(lastSide.gameObject); }
	}
}
