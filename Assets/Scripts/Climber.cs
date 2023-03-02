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
    public static ActionBasedController climbingHand;

    // Start is called before the first frame update
    void Start()
    {
        
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
		if (climbingHand)
        {
			if (climbingHand.name == "RightHand Controller")
            {
                Velocity = velocityPropertyRight.action.ReadValue<Vector3>();
                Velocity = new Vector3(0, Velocity.y, 0);
            }
            if (climbingHand.name == "LeftHand Controller")
            {
                Velocity = velocityPropertyLeft.action.ReadValue<Vector3>();
                Velocity = new Vector3(0, Velocity.y, 0);
			}
            Climb();
        }
    }
    void Climb()
    {
        character.Move(Velocity * Time.fixedDeltaTime);
        //character.gameObject.GetComponent<Rigidbody>().velocity = Velocity;
    }
}
