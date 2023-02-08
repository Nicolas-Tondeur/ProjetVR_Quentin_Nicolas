using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class activatePanel : MonoBehaviour
{

    [SerializeField] GameObject menuUI;

    [SerializeField] InputActionReference activeButtonReference;
    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(false);
        activeButtonReference.action.performed += ToggleMenu;
    }

    // Update is called once per frame
    private void ToggleMenu(InputAction.CallbackContext obj)
    {
        menuUI.SetActive(!menuUI.activeInHierarchy);
    }
}
