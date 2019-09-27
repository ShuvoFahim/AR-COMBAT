using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class FixPanel : MonoBehaviour {

	public GameObject CameraButton;
    public GameObject Title;
    public GameObject QualityMeter;

    public GameObject PlayerHB;
    public GameObject EnemyHB;

    

	private string CurrentScene;


	void Start() {
		CurrentScene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		if (DefaultTrackableEventHandler.TrueFals == true) {
			CameraButton.SetActive (false);
            Title.SetActive(false);
            QualityMeter.SetActive(false);
            PlayerHB.SetActive(true);
            EnemyHB.SetActive(true);

            
            
            
		}
	}

	public void Refresh() {
		SceneManager.LoadScene (CurrentScene);
		
	}



}
