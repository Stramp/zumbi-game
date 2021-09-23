using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour{
    public Transform target;
    public float distance;
    public float sensibility;
    public float limitRotation;

    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.localRotation.x;
        rotY = transform.localRotation.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Mouse_X = Input.GetAxis("Mouse X");
        float Mouse_Y = Input.GetAxis("Mouse Y");

        rotX -= Mouse_Y * sensibility * Time.deltaTime;
        rotY += Mouse_X * sensibility * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -limitRotation, limitRotation);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }
    private void LateUpdate()
    {
        transform.position = target.position + target.up * distance;
    }
}
