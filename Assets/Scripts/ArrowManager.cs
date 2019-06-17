using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance { get; private set;}

    public GameObject arrowPrefab;
    private GameObject currentArrow;
    public GameObject stringAttachPoint;
    public GameObject arrowReference;
    public GameObject stringStartPoint;

    private bool isAttachedToBow = false;

    private SteamVR_Action_Boolean shootArrowAction;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        shootArrowAction = SteamVR_Input._default.inActions.GrabPinch;
    }

    // Update is called once per frame
    void Update()
    {
        AttachArrowToShootingHand();

        PullString();
    }

    private void AttachArrowToShootingHand()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, 0.39f);
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    public void AttachArrowToBow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowReference.transform.localPosition;
        currentArrow.transform.rotation = arrowReference.transform.rotation;

        isAttachedToBow = true;
    }

    private void PullString()
    {
        if (isAttachedToBow)
        {
            float stringPullDistance = (stringStartPoint.transform.position - transform.position).magnitude;
            float normalizedStringPullDistance = Mathf.Clamp(stringPullDistance, 0f, 1f);
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5f* normalizedStringPullDistance, 0f, 0f);

            if (shootArrowAction.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                Fire(normalizedStringPullDistance);
            }
        }
    }

    private void Fire(float charge)
    {
        Debug.LogError($"charge is: {charge}");

        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().IsFired = true;

        currentArrow.GetComponent<Collider>().isTrigger = false; // so it can interact with the RigidBodies in the scene

        var rb = currentArrow.GetComponent<Rigidbody>();
        rb.velocity = currentArrow.transform.forward * 30f * charge;
        rb.useGravity = true;

        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        currentArrow = null;
        isAttachedToBow = false;
    }
}
