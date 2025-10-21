using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class KardController : MonoBehaviour
{

    public InputActionAsset myInputs;
    InputAction moveActions;
    private Rigidbody rb;
    

    public float maxSpeed = 20f;
    public float turnSpeed = 100f;
    public float accel = 1f;
    public float decel = 1f;
    public float drift;
    float currentSpeed;
    Vector3 currentVelocity;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        var gameplay = myInputs.FindActionMap("Gameplay");
        moveActions = gameplay.FindAction("Move");
       


    
    }
    private void OnEnable()
    {
        moveActions.Enable();
    }
        

    private void OnDisable()
    {
        moveActions.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 input = moveActions.ReadValue<Vector2>();
        RLMovement();
        UDMovement(input.y);
    }

    void RLMovement()
    {
        Vector2 input = moveActions.ReadValue<Vector2>(); 

        float turn = input.x * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

    }
    void UDMovement(float y)
    {
        float targetSpeed = y * maxSpeed;
        float rate = (Mathf.Abs(y) > 0.01f) ? accel : decel;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + transform.forward * currentSpeed * Time.fixedDeltaTime);
    }
    


}

