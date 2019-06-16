using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;

public class Arrow : MonoBehaviour
{
    public SteamVR_Action_Single arrowAttachingAction;

    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }

    private void AttachArrow()
    {
        float shouldAttach = arrowAttachingAction.GetAxis(SteamVR_Input_Sources.RightHand);
        if (shouldAttach > 0f)
        {
            ArrowManager.Instance.AttachArrowToBow();
        }
    }
}
