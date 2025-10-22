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


    public StatKartSO stats;
    public float drift;
    
    float currentSpeed;
    

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
        float turn = input.x * stats.turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

    }
    void UDMovement(float y)
    {
        float targetSpeed = y * stats.maxSpeed;
        float rate = (Mathf.Abs(y) > 0.01f) ? stats.accel : stats.decel;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + transform.forward * currentSpeed * Time.fixedDeltaTime);
    }
    


}

