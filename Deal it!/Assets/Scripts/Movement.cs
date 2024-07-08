using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    #region variables

    [SerializeField] private Transform cam;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 5;

    private Rigidbody rb;
    private float horizontalMovement;
    private float verticalMovement;
    private float horizontalRotation;
    private float verticalRotation;

    #endregion

    #region start and update

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotate();
        RotateCam();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #endregion

    #region input

    public void HorizontalMovement(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
    }

    public void VerticalMovement(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<float>();
    }

    public void HorizontalRotation(InputAction.CallbackContext context)
    {
        horizontalRotation = context.ReadValue<float>();
    }

    public void VerticalRotation(InputAction.CallbackContext context)
    {
        verticalRotation = context.ReadValue<float>();
    }

    #endregion

    #region Movement

    private void Move()
    {
        Vector3 input = new Vector3(horizontalMovement, 0, verticalMovement);
        rb.AddRelativeForce(input * moveSpeed);
    }

    #endregion

    #region Rotations

    private void Rotate()
    {
        Vector3 characterRotations = new Vector3(0, horizontalRotation, 0);
        transform.Rotate(characterRotations * rotateSpeed * Time.deltaTime);
    }

    private void RotateCam()
    {
        Vector3 characterRotations = new Vector3(verticalRotation, 0, 0);
        cam.Rotate(characterRotations * rotateSpeed * Time.deltaTime);
    }

    #endregion
}
