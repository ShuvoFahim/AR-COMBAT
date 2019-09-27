using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform enemy;
    private Vector3 direction1;
    public static Animator anim1;
    public static EnemyController instance;

    public Slider EnemyHB;

    public BoxCollider[] C;

    public int EnemyHealth = 100;

    private void SetterFOrBoxCollider(bool State)
    {
        C[0].enabled = State;
        C[1].enabled = State;

    }



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        anim1 = GetComponent<Animator>();
        SetterFOrBoxCollider(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (anim1.GetCurrentAnimatorStateInfo(0).IsName("fight_idleCopy"))
        {
            direction1 = enemy.position - this.transform.position;

            direction1.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction1), .3f);

            
        }

       Debug.Log(direction1.magnitude);

        if (direction1.magnitude > 13f && GameController.AllowMovement == true)
        {
            anim1.SetTrigger("WalkFRWD");
            SetterFOrBoxCollider(false);
        }
        else {
             anim1.ResetTrigger("WalkFRWD");
             }

        if (direction1.magnitude < 13f && direction1.magnitude > 9f && GameController.AllowMovement == true)
        {

            anim1.SetTrigger("KickEnemy");
            SetterFOrBoxCollider(true);
        }
        else {

            anim1.ResetTrigger("KickEnemy");
        }
        if (direction1.magnitude < 7f && direction1.magnitude > 4f && GameController.AllowMovement == true)
        {

            anim1.SetTrigger("Punch");
            SetterFOrBoxCollider(true);
        }
        else
        {

            anim1.ResetTrigger("Punch");
        }
        if (direction1.magnitude > 0f && direction1.magnitude < 4f && GameController.AllowMovement == true)
        {

            anim1.SetTrigger("WalkBACK");
            SetterFOrBoxCollider(true);
        }
        else
        {

            anim1.ResetTrigger("WalkBACK");
        }



    }

    public void EnemyReact() {

        SetterFOrBoxCollider(false);
        EnemyHealth = EnemyHealth - 10;

        EnemyHB.value = EnemyHealth;

        if (EnemyHealth < 10)
        {
            
            EnemyKnockOut();
        }
        else
        {
            anim1.SetTrigger("React");
        }
    }

    public void EnemyKnockOut() {

        anim1.SetTrigger("KnockOut");
        SetterFOrBoxCollider(false);

    }


}
