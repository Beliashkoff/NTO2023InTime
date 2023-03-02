using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System;
using UnityEngine.InputSystem;


public class InteractorModeSwitcher : MonoBehaviour
{
    public GameObject rayInteractor;
    public GameObject directInteractor;
    public InputActionReference rayAction;
    bool isRayEnable = false;

    void Start()
    {
        rayAction.action.performed += HandRayController;
    }
    private void OnDestroy()
    {
        rayAction.action.performed -= HandRayController;
    }
    private void HandRayController(InputAction.CallbackContext context)
    {
        isRayEnable = !isRayEnable;
        if (isRayEnable)
        {
            rayInteractor.SetActive(true);
            directInteractor.SetActive(false);
        }
        else
        {
            rayInteractor.SetActive(false); 
            directInteractor.SetActive(true);
        }
        Debug.Log($"{transform.name} ray enabled = {isRayEnable}");
    }

}
