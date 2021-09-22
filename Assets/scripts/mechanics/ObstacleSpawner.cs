using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
	#region Singleton
	public static ObstacleSpawner instance;
	private void Awake() {
		if(instance == null){
			instance = this;
		}else{
			Destroy(this.gameObject);
		}
	}
	#endregion
	public Vector3 startPoint;
	public GameObject[] obstacles;
	public float offsetPerObject = 2;
	public int obstaclesStart = 5;
	public int oilPercent = 80;
	public int oilAdd = 5;
	private float lastObsPos;
	private List<GameObject> spawned;
	GameObject obsParent;
	
	void Start () {
		initiateObs();
	}

	private void initiateObs(){
		obsParent = new GameObject();
		obsParent.name = "obsParent";
		obsParent.transform.parent = null;

		lastObsPos = startPoint.y;
		
		for (int i = 0; i < obstaclesStart; i++)
		{
			SpawnObstacle();
		}
	}

	private bool randomBoolean(){
		if(Random.value >= 0.5) return true;
		else return false;
	}

	public void SpawnObstacle(){
		float yPos = lastObsPos + offsetPerObject;
		int obsIndex = Random.Range(0, obstacles.Length);
		GameObject obs = Instantiate(obstacles[obsIndex], new Vector3(0, yPos, 0), Quaternion.identity);

		obs.transform.GetComponent<ObstacleScript>().moveRight = randomBoolean();
		obs.transform.GetComponent<ObstacleScript>().movingSpeed = Random.Range(3, 6);
		if(obs.transform.GetComponent<SpinnerScript>()){
			obs.transform.GetComponent<SpinnerScript>().rotationSpeed = Random.Range(100, 200);
		}
		
		obs.transform.GetChild(0).GetComponent<SpawnPowerScript>().probabilityInPercent = oilPercent;
		obs.transform.GetChild(0).GetComponent<SpawnPowerScript>().SpawnPower(oilAdd);
		lastObsPos = yPos;	
		obs.transform.parent = obsParent.transform;
	}

	public void resetSpawner(){
		Destroy(obsParent);
		initiateObs();
	}

}
