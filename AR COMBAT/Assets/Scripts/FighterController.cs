using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemyTarget;
    static Animator anim;

    public static bool mvBack = false;
    public static bool mvFwrd = false;
    public static bool IsAttack = false;
    public static FighterController instance;

    public Slider PlayerHB;

    public int PLayerHealth=100;

    public BoxCollider[] C; 

    private Vector3 direction;

    public AudioClip[] Clip;
    AudioSource Audio;

    private Vector3 PlayerPosition;


    void Awake()
    {
        if (instance == null) {
            instance = this;
        }    
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        SetterFOrBoxCollider(false);
        Audio = GetComponent<AudioSource>();
        PlayerPosition = transform.position;
    }

    void PlayAudio(int AudioIndex) {

        Audio.clip = Clip[AudioIndex];
        Audio.Play();

    }


    private void SetterFOrBoxCollider(bool State) {
        C[0].enabled = State;
        C[1].enabled = State;

    }

    // Update is called once per frame
    void Update()

    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("fight_idle"))
        {
            direction = enemyTarget.position - this.transform.position;

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), .3f); 

        }

        

      




        if (anim.GetCurrentAnimatorStateInfo(0).IsName("fight_idle")) {

            IsAttack = false;
            SetterFOrBoxCollider(false);
        }

        if (IsAttack == false)
        {


            if (mvBack == true)
            {
                anim.SetTrigger("wkBACK");
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("wkFWRD");
                SetterFOrBoxCollider(false);

            }
            else if (mvFwrd == true)
            {
                anim.SetTrigger("wkFWRD");
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("wkBACK");

            }
            else
            {
                anim.SetTrigger("Idle");
                anim.ResetTrigger("wkFWRD");
                anim.ResetTrigger("wkBACK");


            }
        }

        else if (IsAttack == true)
        {

            SetterFOrBoxCollider(true);

        }



        
       
    }

    public void Punch() {

        IsAttack = true;
        
        anim.ResetTrigger("Idle");
        anim.SetTrigger("Punch");
        PlayAudio(0);


    }

    public void Kick()
    {

        IsAttack = true;
        
        anim.ResetTrigger("Idle");
        anim.SetTrigger("Kick");
        PlayAudio(1);


    }

    public void React()
    {

        
        IsAttack = true;
        SetterFOrBoxCollider(false);

        
        PLayerHealth = PLayerHealth - 10;

        PlayerHB.value = PLayerHealth;

        if (PLayerHealth < 0)
        {
            
            PlayerKnockOut();
            PlayAudio(3);
        }
        else {

            anim.ResetTrigger("Idle");
            anim.SetTrigger("React");
            PlayAudio(2);
        }


    }

    public void PlayerKnockOut() {
        GameController.AllowMovement = false;
        PLayerHealth = 100;
        PlayerHB.value = 100;


        SetterFOrBoxCollider(false);
        anim.SetTrigger("KnockOut");
        GameController.instance.EnemyScoreUpdate();
        GameController.instance.OnScreenPoinPupdate();
        GameController.instance.Rounds();
        if (GameController.EnemyScore == 2)
        {
            GameController.instance.DoReset();
        }
        else
        {
            StartCoroutine(resetCharacters());

        }
    }
    IEnumerator resetCharacters()
    {
        yield return new WaitForSeconds(4);
        GameObject[] TheClone = GameObject.FindGameObjectsWithTag("");
        GameController.AllowMovement = true;
    }


}
