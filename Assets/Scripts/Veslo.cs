using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Veslo : MonoBehaviour
{
	public InputActionProperty velocityPropertyRight;
	public InputActionProperty velocityPropertyLeft;
	private Vector3 velocityR;
	private Vector3 velocityL;
	private float velocity;
	public float speed = 1f;
	private bool isInWater = false;
    public bool isGrabing = false;
	public GameObject raft;
	void Start()
    {
		raft.transform.rotation = Quaternion.Slerp(raft.transform.rotation, Quaternion.Euler(0, -10, 0), Time.deltaTime * speed);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (isGrabing && isInWater)
		{
			velocityL =  velocityPropertyLeft.action.ReadValue<Vector3>();
			velocityR = velocityPropertyRight.action.ReadValue<Vector3>();
			velocity = Mathf.Max(velocityL.magnitude, velocityR.magnitude);
		}
        else
            velocity = 0;
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Water Trigger Left")
		{
			raft.transform.rotation = Quaternion.Slerp(raft.transform.rotation, Quaternion.Euler(0, 30, 0), Time.deltaTime * speed);
		}
		else if (other.name == "Water Trigger Right")
		{
			raft.transform.rotation = Quaternion.Slerp(raft.transform.rotation, Quaternion.Euler(0, -30, 0), Time.deltaTime * speed);
		}
		if (other.tag == "Water")
        {
            isInWater = true;
        }
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Water")
		{
			isInWater = false;
		}
	}
	public void OnGrabStart()
	{
		isGrabing = true;
	}
	public void OnGrabEnd()
	{
		isGrabing = false;
	}
}
