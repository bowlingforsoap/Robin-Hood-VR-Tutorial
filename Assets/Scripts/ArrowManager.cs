using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance { get; private set;}

    public GameObject arrowPrefab;
    private GameObject currentArrow;
    public GameObject stringAttachPoint;
    public GameObject arrowReference;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        AttachArrowToShootingHand();
    }

    private void AttachArrowToShootingHand()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = transform;
            currentArrow.transform.localPosition += new Vector3(0f, 0f, 0.39f);
        }
    }

    public void AttachArrowToBow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.rotation = arrowReference.transform.rotation;
        currentArrow.transform.localPosition = arrowReference.transform.localPosition;
        //currentArrow.transform.position += new Vector3(3.211f, 0f, 0f);

    }
}
