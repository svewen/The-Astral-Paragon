using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGunInFront : MonoBehaviour
{
    public GameObject gun; // The object to keep in front of the camera
    public float distance = 3f; // The distance to keep the object from the camera

    public Camera mainCamera; // The main camera in the scene


    void Update()
    {
        // Set the object's position to be the camera's position plus the camera's forward vector times the distance
        gun.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
    }
}
