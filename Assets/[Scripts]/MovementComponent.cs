using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Animator playerAnimator;

    private Vector2 inputVector;

    private bool isRunning;
    public bool canMove;
    public float moveSpeed;
    public float rotateSpeed;

    private Rigidbody playerBody;

    //[SerializeField]
    //GameObject stepRayLower, stepRayUpper;
    //
    //float stepHeight = 0.3f;
    //float stepSmooth = 0.1f;

    public readonly int isMovingHash = Animator.StringToHash("isMoving");
    // Start is called before the first frame update

    private void Awake()
    {
        canMove = true;
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            var movementVector = MoveTowardTarget(new Vector3(inputVector.x, 0, inputVector.y));
            if (inputVector.magnitude > 0)
            {
                Rotate(movementVector);
            }
            OnRun();
        }

        if (inputVector.x > 0f ||
           inputVector.y > 0f ||
           inputVector.x < 0 ||
           inputVector.y < 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        //climbStep();
    }
    private void FixedUpdate()
    {
        
    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
    private void OnRun()
    {
        playerAnimator.SetBool(isMovingHash, isRunning);
    }
    private void Rotate(Vector3 movementVector)
    {
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }
    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, Camera.main.gameObject.transform.eulerAngles.y, 0) * targetVector;

        var targetPosition = transform.position + targetVector * speed;

        transform.position = targetPosition;

        return targetVector;
    }

    //void climbStep()
    //{
    //    RaycastHit hitLower;
    //    if(Physics.Raycast(stepRayLower.transform.position, stepRayLower.transform.forward, out hitLower, 0.1f))
    //    {
    //        RaycastHit hitUpper;
    //        if(!Physics.Raycast(stepRayUpper.transform.position, stepRayUpper.transform.forward, out hitUpper, 0.2f))
    //        {
    //            playerBody.position -= new Vector3(0f, -stepSmooth, 0f);
    //        }
    //    }
    //}

}
