using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class movementStick : MonoBehaviour
{
    public Transform xrHeadPosition;

    public UnityEngine.XR.InputDevice leftController;
    public UnityEngine.XR.InputDevice rightController;
    public float updateControllerTimer = 0f;
    public bool leftTrigger = false;
    public bool rightTrigger = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Terrain") Physics.IgnoreCollision(gameObject.GetComponent<CapsuleCollider>(), collision.collider, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftController.IsPressed(InputHelpers.Button.Trigger, out leftTrigger);
        rightController.IsPressed(InputHelpers.Button.Trigger, out rightTrigger);
        bool goUp = false;
        leftController.IsPressed(InputHelpers.Button.PrimaryAxis2DUp, out goUp);
        bool goDown = false;
        leftController.IsPressed(InputHelpers.Button.PrimaryAxis2DDown, out goDown);
        bool goLeft = false;
        leftController.IsPressed(InputHelpers.Button.PrimaryAxis2DLeft, out goLeft);
        bool goRight = false;
        leftController.IsPressed(InputHelpers.Button.PrimaryAxis2DRight, out goRight);
        if ( goUp)
        {
            transform.position = Vector3.MoveTowards(transform.position,transform.position+(xrHeadPosition.forward*1f),0.1f);
        }
        if (goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (xrHeadPosition.forward*-1f), 0.1f);
        }
        if (goLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (xrHeadPosition.right * -1f), 0.1f);
        }
        if (goRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + xrHeadPosition.right, 0.1f);
        }
        updateControllerTimer -= Time.deltaTime;
        if (!(updateControllerTimer < 0f)) return;
        updateController();
        updateControllerTimer = 2f;
    }
}
