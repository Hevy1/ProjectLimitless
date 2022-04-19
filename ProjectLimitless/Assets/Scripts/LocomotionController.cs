using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController LRay;
    public XRController RRay;
    public InputHelpers.Button tpact;
    private XRRayInteractor rightRayInteractor;
    private XRRayInteractor leftRayInteractor;
    public float threshold = 0.4f;

    public bool ELT { get; set; } = true;
    public bool ERT { get; set; } = true;

    private void Start()
    {
        if (RRay) 
             rightRayInteractor = RRay.gameObject.GetComponent<XRRayInteractor>(); 
        if (LRay) 
             leftRayInteractor = LRay.gameObject.GetComponent<XRRayInteractor>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (LRay)
        {
            leftRayInteractor.allowSelect = check(LRay);
            LRay.gameObject.SetActive(ELT && check(LRay));
        }

        if (RRay)
        {
            leftRayInteractor.allowSelect = check(RRay);
            RRay.gameObject.SetActive(ERT && check(RRay));
        }
    }

    public bool check(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, tpact, out bool isActivated, threshold);
        return isActivated;
    }
}
