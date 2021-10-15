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

    public bool hasGunRight = false;
    public bool hasGunLeft = false;
    public Transform rightHandPos;
    public Transform leftHandPos;
    public GameObject heldGun;

    public List<Holster> RightHandHolsters;
    public List<Holster> LeftHandHolsters;

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
        if ( rightGrip && !hasGunRight && !hasGunLeft)
        {
            Holster closest = getClosestHolster(RightHandHolsters, rightHandPos);
            heldGun = Instantiate(closest.GunPrefab);
            heldGun.transform.SetParent(rightHandPos);
            heldGun.transform.localPosition = Vector3.zero;
            heldGun.transform.localRotation = Quaternion.identity;
            heldGun.GetComponent<GunGeneric>().beingHeld = true;
            hasGunRight = true;
        }
        if ( !rightGrip && hasGunRight)
        {
            heldGun.transform.SetParent(null);
            heldGun.AddComponent<Rigidbody>();
            //heldGun.AddComponent<BoxCollider>();
            heldGun.GetComponent<GunGeneric>().beingHeld = false;
            Destroy(heldGun, 5f);
            hasGunRight = false;
        }
        if (leftGrip && !hasGunRight && !hasGunLeft)
        {
            Holster closest = getClosestHolster(LeftHandHolsters, leftHandPos);
            heldGun = Instantiate(closest.GunPrefab);
            heldGun.transform.SetParent(leftHandPos);
            heldGun.transform.localPosition = Vector3.zero;
            heldGun.transform.localRotation = Quaternion.identity;
            heldGun.GetComponent<BowGeneric>().beingHeld = true;
            hasGunLeft = true;
        }
        if (!leftGrip && hasGunLeft)
        {
            heldGun.transform.SetParent(null);
            heldGun.AddComponent<Rigidbody>();
            //heldGun.AddComponent<BoxCollider>();
            heldGun.GetComponent<BowGeneric>().beingHeld = false;
            Destroy(heldGun, 5f);
            hasGunLeft = false;
        }
        updateControllerTimer -= Time.deltaTime;
        if (!(updateControllerTimer < 0f)) return;
        updateController();
        updateControllerTimer = 2f;
    }
}
