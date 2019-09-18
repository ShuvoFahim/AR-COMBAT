using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform enemyTarget;
    Animator anim;

    public static bool mvBack = false;
    public static bool mvFwrd = false;
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
        if (mvBack == true)
        {
            anim.SetTrigger("wkBACK");
        }
        else if (mvFwrd == false) {
            anim.SetTrigger("Idle");
            anim.ResetTrigger("wkBACK");

        }

        if (mvFwrd == true)
        {
            anim.SetTrigger("wkFWRD");
        }
        else if (mvBack == false )
        {
            anim.SetTrigger("Idle");
            anim.ResetTrigger("wkFWRD");

        }


    }
}
