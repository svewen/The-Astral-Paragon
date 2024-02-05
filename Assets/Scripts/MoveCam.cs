using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;
    public Camera cam;
    public GameObject playerModel;

    // Update is called once per frame
    private void Update()
    {
        transform.position = cameraPosition.position;

        Quaternion cameraRotation = cam.transform.rotation;

        // Ignore the camera's pitch and roll by creating a new rotation with only the y-axis rotation
        Quaternion playerRotation = Quaternion.Euler(0f, cameraRotation.eulerAngles.y, 0f);

        // Apply the new rotation to the player model
        playerModel.transform.rotation = playerRotation;
    }
}
