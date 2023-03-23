using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Calculating : MonoBehaviour

{
    //Enabling AttitudeSensor using Input System. 
    void Start()
    {
        InputSystem.EnableDevice(AttitudeSensor.current);
        Debug.Log(Accelerometer().ToString());
    }

    //Returns the orientation of the android device as a Quaternion using accelerometer sensor
    public Quaternion Accelerometer() {
        return AttitudeSensor.current.attitude.ReadValue();
    }
}
