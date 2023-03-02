using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysic : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharecter;
    public Transform target;
    public GameObject nonPhysicHand;
    public float showNonPhysicHandDistance = 0.05f;
    public Material solid_Mat;
    public Material xray_Mat;

    private HandCheker handCheker;
    private ActionBasedContinuousMoveProvider moveProvider;
    private ActionBasedSnapTurnProvider turnProvider;
    private Rigidbody rb;
    private Animator handAnimator;
    private bool isPhysicHandEnable = true;
    private bool isMoving = false;
    private Collider[] colliders;
    private bool isDeviceValid = false;
    void Start()
    {
        handCheker = GetComponent<HandCheker>();
        moveProvider = FindObjectOfType<ActionBasedContinuousMoveProvider>();
        turnProvider = FindObjectOfType<ActionBasedSnapTurnProvider>();
        rb = GetComponent<Rigidbody>();
        handAnimator = nonPhysicHand.GetComponent<Animator>();
        moveProvider.rightHandMoveAction.action.started += OnLocomotionBegin;
        turnProvider.leftHandSnapTurnAction.action.started += OnLocomotionBegin;
        moveProvider.rightHandMoveAction.action.canceled += OnLocomotionEnd;
        turnProvider.leftHandSnapTurnAction.action.canceled += OnLocomotionBegin;
        handCheker.DeviceIsValid += OnDeviseIsValid;
    }
    private void Update()
    {
        if (isDeviceValid)
        {
            if (!isMoving) 
            {
                float dist = Vector3.Distance(target.position, transform.position);
                if (dist > showNonPhysicHandDistance)
                {
                    if (isPhysicHandEnable) 
                    {
                        nonPhysicHand.GetComponentInChildren<Renderer>().material = xray_Mat;
                        nonPhysicHand.SetActive(true);
                        isPhysicHandEnable = false;
                    }
                }
                else
                {
                    if (!isPhysicHandEnable)
                    {
                        nonPhysicHand.SetActive(false);
                        isPhysicHandEnable = true;
                    }
                }
            }
            if (!isPhysicHandEnable)
            {
                handCheker.HandAnimUpdate(handAnimator);
            }
        }
    }
    private void OnDestroy()
    {
        moveProvider.rightHandMoveAction.action.started -= OnLocomotionBegin;
        moveProvider.rightHandMoveAction.action.canceled -= OnLocomotionEnd;
        turnProvider.leftHandSnapTurnAction.action.started -= OnLocomotionBegin;
        turnProvider.leftHandSnapTurnAction.action.canceled -= OnLocomotionBegin;
        handCheker.DeviceIsValid -= OnDeviseIsValid;
    }
    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rot = target.rotation * Quaternion.Inverse(transform.rotation);
        rot.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
    public void OnLocomotionBegin(InputAction.CallbackContext action)
    {
        isMoving = true;
        isPhysicHandEnable = false;
        nonPhysicHand.GetComponentInChildren<Renderer>().material = solid_Mat;
        nonPhysicHand.SetActive(true);
        if (handCheker.spawnedHandModel != null)
            handCheker.spawnedHandModel.SetActive(false);
    }
    private void OnLocomotionEnd(InputAction.CallbackContext action)
    {
        isMoving = false;
        isPhysicHandEnable = true;
        nonPhysicHand.SetActive(false);
        if (handCheker.spawnedHandModel != null)
            handCheker.spawnedHandModel.SetActive(true);
    }
    private void OnDeviseIsValid()
    {
        isDeviceValid = true;
        colliders = handCheker.spawnedHandModel.GetComponentsInChildren<Collider>();
    }
    public void EnableColliders()
    {
        foreach (var item in colliders)
            item.enabled = true;
    }
    public void EnableCollidersDelay(float delay)
    {
        Invoke("EnableColliders", delay);
    }
    public void DisableColliders()
    {
        foreach (var item in colliders)
            item.enabled = false;
    }
}
