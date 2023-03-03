using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Climber : MonoBehaviour
{
    public InputActionProperty velocityPropertyRight;
    public InputActionProperty velocityPropertyLeft;
    public static bool isExited = false;
    public float bounce;
    public Vector3 Velocity { get; private set; } = Vector3.zero;
    public static CharacterController character;
    private Rigidbody rb;
    public static ActionBasedController climbingHand;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
		if (climbingHand)
        {
			Climb();
			if (climbingHand.name == "RightHand Controller")
            {
                Velocity = velocityPropertyRight.action.ReadValue<Vector3>();
            }
            if (climbingHand.name == "LeftHand Controller")
            {
                Velocity = velocityPropertyLeft.action.ReadValue<Vector3>();
			}
        }
    }
    void Climb()
    {
        //rb.MovePosition(Vector3.up);
        character.transform.Translate(Vector3.up * Time.fixedDeltaTime * 2);
		//character.transform.Translate(transform.forward * Time.fixedDeltaTime);
	}
}
