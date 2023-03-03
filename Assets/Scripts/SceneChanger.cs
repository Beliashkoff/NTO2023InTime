using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Toggle toggle;
	public void Load()
	{
		if (toggle.isOn)
		{
			SceneManager.LoadScene(2);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}
}
