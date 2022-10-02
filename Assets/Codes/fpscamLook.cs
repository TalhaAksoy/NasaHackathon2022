using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscamLook : MonoBehaviour
{
    public float mouseSensitivity = 600f;

    public Transform playerBody;

    float xRotation = 0f;

    SkyboxRotate skybox;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        skybox = GetComponent<SkyboxRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        if (skybox.move == true)
        {
            if (mouseX == 0 && mouseY == 0)
                skybox.move = false;
        }
        else if (mouseX != 0 || mouseY != 0)
            skybox.move = true;

    }

}
