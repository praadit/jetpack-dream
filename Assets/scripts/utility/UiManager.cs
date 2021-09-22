using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
	#region Singleton
	public static UiManager instance;
	private void Awake() {
		if(instance==null){
			instance = this;
		}else{
			Destroy(this.gameObject);
		}
	}
	#endregion
	public Text scoreText;
	public Text fuelText;
	public int _uiFuel;
	public int _uiScore;
	public GameObject titleScreen;

	// Use this for initialization
	void Start () {
		initUI();
	}

	private void initUI(){
		_uiScore = 0;
		_uiFuel = 0;

		fuelText.text = _uiFuel.ToString();
		scoreText.text = _uiScore.ToString();
	}

	public void RefreshFuel(int fuel){
		_uiFuel = fuel;
		
		fuelText.text = _uiFuel.ToString();
	}
	public void RefreshScore(int score){
		_uiScore = score;
		
		scoreText.text = _uiScore.ToString();
	}

	public void HideWelcome(){
		if(titleScreen.activeInHierarchy){
			titleScreen.SetActive(false);
		}
	}

	public void ShowWelcome(){
		titleScreen.SetActive(true);
	}
}
