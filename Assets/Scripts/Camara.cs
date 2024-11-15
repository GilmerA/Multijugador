using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Camara : MonoBehaviourPun
{
    public float mouseSensitivity = 100f; 
    public Transform playerBody; 

    private float xRotation = 0f; 

    void Start()
    {
        
        if (!photonView.IsMine)
        {
            GetComponent<Camera>().enabled = false;
            GetComponent<AudioListener>().enabled = false; 
            return;
        }

        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        if (!photonView.IsMine) return;

        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

