using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemyTarget;
    static Animator anim;

    public static bool mvBack = false;
    public static bool mvFwrd = false;
    public static bool IsAttack = false;
    public static FighterController instance;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }    
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()

    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("fight_idle")) {

            IsAttack = false;
        }

        if (IsAttack == false)
        {

            if (mvBack == true)
            {
                anim.SetTrigger("wkBACK");
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("wkFWRD");

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
    }

    public void Punch() {

        IsAttack = true;

        anim.ResetTrigger("Idle");
        anim.SetTrigger("Punch");


    }

    public void Kick()
    {

        IsAttack = true;

        anim.ResetTrigger("Idle");
        anim.SetTrigger("Kick");


    }

    public void React()
    {

        IsAttack = true;

        anim.ResetTrigger("Idle");
        anim.SetTrigger("React");


    }

}
