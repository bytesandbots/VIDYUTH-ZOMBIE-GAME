using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //camera 
    Camera cam;
    Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float stamina;
    [SerializeField]
    private float jump;
    [SerializeField]
    private float cursorSensitivity;
    [SerializeField]
    private float xAxis, yAxis;
    [SerializeField]
    private float health;
    private bool splat;
    void Start()
    {
        //cam is main camera
        cam = Camera.main;

        //rb is rigidbody
        rb = GetComponent<Rigidbody>();

    
    }

    void FixedUpdate()
    {
        if (health > 0) 
        {
            WalkingMovement();
            if (transform.position.y <=1.5) 
            {
                JumpHeight();
            }
        }
        
        MouseMovement();

        
    }

    void MouseMovement()
    {
        //
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * cursorSensitivity;

        float mouseY = Input.GetAxis("Mouse Y") * cursorSensitivity;

        xAxis -= mouseY;

        yAxis += mouseX;


        xAxis = Mathf.Clamp(xAxis, -50, 50);

        cam.transform.localRotation = Quaternion.Euler(xAxis, 0, 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, yAxis, 0);
    }
    
    void WalkingMovement()
    {
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) ) 
        { 
             Vector3 pos = (transform.right * hori + transform.forward * vert) * Time.deltaTime * sprintSpeed;
            rb.MovePosition(rb.position + pos);
            stamina -= Time.deltaTime * 10f;
        }
        else
        {
            Vector3 pos = (transform.right * hori + transform.forward * vert) * Time.deltaTime * speed;
            rb.MovePosition(rb.position + pos);
            stamina += Time.deltaTime * 10f;
        }
        
    }
    void JumpHeight() 
    {
        Vector3 vector_from_Despicable_Me = new Vector3(0,1,0);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(vector_from_Despicable_Me * jump );
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parasite"))
        {
            
            health -= Random.Range(1,5);
        }
        }
    }
   




