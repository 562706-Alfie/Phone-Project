using System;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.EnhancedTouch;

public class GyroScript : MonoBehaviour
{
    InputAction vibrateAction;

    private void Start()
    {
        //initialise the actions
        vibrateAction = InputSystem.actions.FindAction("Vibrate");
        Input.gyro.enabled = true; //Enables the gyro functionality within unity
    }

    private void Update()
    {
        Vector3 previousEulerAngles = transform.eulerAngles;
        Vector3 gyroInput = -Input.gyro.rotationRateUnbiased; // Unity uses left hand??(Inverses movement)

        Vector3 targetEulerAngles = previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
        targetEulerAngles.z = 0.0f; //Locks the Z rotation

        transform.eulerAngles = targetEulerAngles;

        // This uses the new input system to detect 'k'. Trying to use it for touch input didn't work, so have to use the old input system below.
        if (vibrateAction.triggered)
        {
            print("Test");
            Handheld.Vibrate();
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            print("Test");
            Handheld.Vibrate();
        }
    }
}