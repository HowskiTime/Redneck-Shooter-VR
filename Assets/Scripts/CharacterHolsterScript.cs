using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class CharacterHolsterScript : MonoBehaviour
{
    public UnityEngine.XR.InputDevice leftController;
    public UnityEngine.XR.InputDevice rightController;
    public float updateControllerTimer = 0f;
    public bool leftGrip = false;
    public bool rightGrip = false;

    public bool hasGun = false;
    public Transform rightHandPos;
    public GameObject heldGun;

    public List<Holster> RightHandHolsters;

    private void updateController()
    {
        if (Application.isEditor) return;
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        leftController = leftHandDevices[0];
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        rightController = rightHandDevices[0];
    }

    private Holster getClosestHolster(List<Holster> theList, Transform hand)
    {
        Holster closest = null;
        float distance = 100f;
        foreach ( Holster holster in theList )
        {
           if ( Vector3.Distance(holster.transform.position,hand.position) < distance)
            {
                distance = Vector3.Distance(holster.transform.position, hand.position);
                closest = holster;
            }
        }
        return closest;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftController.IsPressed(InputHelpers.Button.GripButton, out leftGrip);
        rightController.IsPressed(InputHelpers.Button.GripButton, out rightGrip);
        if ( rightGrip && !hasGun )
        {
            Holster closest = getClosestHolster(RightHandHolsters, rightHandPos);
            heldGun = Instantiate(closest.GunPrefab);
            heldGun.transform.SetParent(rightHandPos);
            heldGun.transform.localPosition = Vector3.zero;
            heldGun.transform.localRotation = Quaternion.identity;
            heldGun.GetComponent<GunGeneric>().beingHeld = true;
            hasGun = true;
        }
        if ( !rightGrip && hasGun )
        {
            heldGun.transform.SetParent(null);
            heldGun.AddComponent<Rigidbody>();
            //heldGun.AddComponent<BoxCollider>();
            heldGun.GetComponent<GunGeneric>().beingHeld = false;
            Destroy(heldGun, 5f);
            hasGun = false;
        }
        updateControllerTimer -= Time.deltaTime;
        if (!(updateControllerTimer < 0f)) return;
        updateController();
        updateControllerTimer = 2f;
    }
}
