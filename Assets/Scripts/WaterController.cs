using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterController : MonoBehaviour
{
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
}
