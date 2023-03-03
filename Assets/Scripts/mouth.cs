using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouth : MonoBehaviour
{
	private PlayerController playerController;
	private void Start()
	{
		playerController = FindObjectOfType<PlayerController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Fish")
		{
			GetComponent<AudioSource>().Play();
			other.gameObject.SetActive(false);
			float stamina = playerController.stamina;
			playerController.stamina += 25f;
		}
	}
}
