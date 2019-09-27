using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static bool AllowMovement = false;
    public GameObject FlashButton;
    public GameObject CameraButton;
    public GameObject PlayerScoreOnScreen;
    public GameObject EnemyScoreOnScreen;
    public GameObject BackButton;
    public GameObject ForwardButton;
    public GameObject PunchButtor;
    public GameObject KickButton;
    private bool Played321 = false;


    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Played321 == false) {
            if (DefaultTrackableEventHandler.TrueFals == true) {
                FlashButton.SetActive(false);
                CameraButton.SetActive(false);
                PlayerScoreOnScreen.SetActive(true);
                EnemyScoreOnScreen.SetActive(true);
                BackButton.SetActive(true);
                ForwardButton.SetActive(true);
                PunchButtor.SetActive(true);
                KickButton.SetActive(true);
            }




        }


        
    }
}
