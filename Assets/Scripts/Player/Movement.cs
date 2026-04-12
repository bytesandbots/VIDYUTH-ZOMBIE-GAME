using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Camera cam;
    Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float cursorSensitivity;
    [SerializeField]
    private float xRot, yRot;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
      //  WalkingMovement();
        MouseMovement();

    }

    void MouseMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * cursorSensitivity;

        float mouseY = Input.GetAxis("Mouse Y") * cursorSensitivity;

        xRot -= mouseY;

        yRot += mouseX;


        xRot = Mathf.Clamp(xRot, -50, 50);
        cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    void WalkingMovement()
    {
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        Vector3 pos = (transform.right * hori + transform.forward * vert) * Time.deltaTime * speed;
        rb.MovePosition(rb.position + pos);
    }
}



