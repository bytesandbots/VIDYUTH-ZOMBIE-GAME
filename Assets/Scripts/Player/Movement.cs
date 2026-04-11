using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float walkSpeed = 1f;
    public float runSpeed = 5f;
    public float staminaMeter = 100f;

    public float jumpHeight = 3f;

    public int health = 100;

    public bool isSplatered;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Move() 
    {
    
    }
}

