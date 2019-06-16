using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{
    //public event EventHandler<EventArgs> OnArrowEnteredTheBow;

    private void OnTriggerEnter(Collider other)
    {
        ArrowManager.Instance.AttachArrowToBow();

        //SafelyInvokeEventHandler(OnArrowEnteredTheBow);
    }

    //private void SafelyInvokeEventHandler(EventHandler<EventArgs> eventHandler)
    //{
    //    var eventHandlerCopy = eventHandler;
    //    if (eventHandlerCopy != null)
    //    {
    //        eventHandlerCopy(this, new EventArgs());
    //    }
    //}
}
