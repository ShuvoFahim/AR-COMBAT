using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkFwrdController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        FighterController.mvFwrd = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        FighterController.mvFwrd = false;
    }


}
