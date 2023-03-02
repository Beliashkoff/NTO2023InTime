using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouth : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Fish")
		{
			GetComponent<AudioSource>().Play();
			other.gameObject.SetActive(false);
		}
	}
}
