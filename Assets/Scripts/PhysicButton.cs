using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicButton : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.02f;

    private bool isPressed = false;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    void Start()
    {
        startPos = transform.position;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetValue());
        if (!isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (isPressed && GetValue() - threshold <= 0)
            Released();
    }
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if (Math.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        isPressed = true;
        Debug.Log("Pressed");
        onPressed.Invoke();
    }
    private void Released()
    {
        isPressed = false;
        Debug.Log("Released");
        onReleased.Invoke();
    }
}
