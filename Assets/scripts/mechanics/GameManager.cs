using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	#region Singleton
	public static GameManager instance;
	private void Awake() {
		if(instance==null){
			instance = this;
		}else{
			Destroy(this.gameObject);
		}
	}
	#endregion
	public bool isGameStart;
	public GameObject andy;
	public Transform spawnPoinAndy;
	public GameObject mainCamera;
	private int score = 0;

	private SideLimitManager _sm;
	private ObstacleSpawner _os;
	private UiManager _ui;

	private void Start() {
		_sm = SideLimitManager.instance;
		_os = ObstacleSpawner.instance;
		_ui = UiManager.instance;
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.R)){
			_ui.ShowWelcome();
			RestartGame();
		}
	}

	public void RestartGame(){
		andy.transform.position = spawnPoinAndy.position;
		andy.transform.GetComponent<FlyJetpack>().isDead = false;
		andy.transform.GetComponent<FlyJetpack>().resetFuel();

		/* RESET POSISI GROUND LIMIT */
		FindObjectOfType<GroundLimitScript>().ResetPos();

		/* RESET KONDISI SIDE LIMIT */
		_sm.RestartSide(); 

		/* RESET OBSTACLES */
		_os.resetSpawner();

		/* RESET SCORE */
		ResetScore();

		/* RESET POSISI KAMERA */
		mainCamera.transform.position = spawnPoinAndy.position;
	}

	public void AddScore(){
		score++;
		_ui.RefreshScore(score);
	}

	public void ResetScore(){
		score = 0;
		_ui.RefreshScore(score);
	}
}
