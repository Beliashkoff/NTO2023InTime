using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterController : MonoBehaviour
{
	public float powerUp;
	public float powerForward;
	private PlayerController playerController;
	private void Start()
	{
		playerController = FindObjectOfType<PlayerController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
        {
			playerController.staminaChanger = -9f;
        }
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Interact Obj")
		{
			other.GetComponent<Rigidbody>().AddForce(transform.up * powerUp);
			other.GetComponent<Rigidbody>().AddForce(transform.forward * powerForward);
		}
		else if(other.tag == "Raft")
		{
			other.transform.Translate(other.transform.forward * Time.fixedDeltaTime);
		}
		else if (other.tag == "veslo")
		{
			other.GetComponent<Rigidbody>().AddForce(transform.up * powerUp);
			other.GetComponent<Rigidbody>().AddForce(transform.forward * (powerForward+0.06f));
		}
	}
}
