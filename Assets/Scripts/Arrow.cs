using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;

public class Arrow : MonoBehaviour
{
    public SteamVR_Action_Single attachArrowToBowAction;

    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }

    private void AttachArrow()
    {
        float shouldAttach = attachArrowToBowAction.GetAxis(SteamVR_Input_Sources.RightHand);
        if (shouldAttach > .75f)
        {
            ArrowManager.Instance.AttachArrowToBow();
        }
    }
}
