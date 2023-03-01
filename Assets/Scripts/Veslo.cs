using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Veslo : MonoBehaviour
{
	public InputActionReference velocityRef = null;
    private Vector3 velocity;

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = velocityRef.action.ReadValue<Vector3>();
        Debug.Log(velocity);    
	}
}
