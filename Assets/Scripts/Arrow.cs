using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;

public class Arrow : MonoBehaviour
{
    public SteamVR_Action_Boolean attachArrowToBowAction;

    public bool IsFired { set; private get; } = false;
    /// <summary>
    /// Rigidbody of this Arrow.
    /// </summary>
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }

    private void Update()
    {
        CorrectTrajectory();
    }

    /// <summary>
    /// Makes a fired arrow follow an arched path, just like a real arrow.
    /// </summary>
    private void CorrectTrajectory()
    {
        if (IsFired)
        {
            transform.LookAt(transform.position + rigidbody.velocity);
        }
    }

    private void AttachArrow()
    {
        bool shouldAttach = attachArrowToBowAction.GetStateDown(SteamVR_Input_Sources.RightHand);
        if (shouldAttach)
        {
            ArrowManager.Instance.AttachArrowToBow();
        }
    }
}
