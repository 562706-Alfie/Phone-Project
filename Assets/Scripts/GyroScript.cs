using System;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.EnhancedTouch;

public class GyroScript : MonoBehaviour
{
    private void Start()
    {
        //initialise the actions
        Input.gyro.enabled = true; //Enables the gyro functionality within unity
    }

    private void Update()
    {
        Vector3 previousEulerAngles = transform.eulerAngles;
        Vector3 gyroInput = -Input.gyro.rotationRateUnbiased; // Unity uses left hand??(Inverses movement)

        Vector3 targetEulerAngles = previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
        targetEulerAngles.z = 0.0f; //Locks the Z rotation

        transform.eulerAngles = targetEulerAngles;

        //Trying to use new input system for touch input didn't work, so have to use the old input system below.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            print("Vibrating");
            Handheld.Vibrate();
        }
    }
}