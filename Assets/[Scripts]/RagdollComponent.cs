using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody mainBody;
    public Rigidbody[] ragdollBodies;
    private Animator playerAnimator;
    public Collider mainCollision;
    public Collider[] boneCollision;

    private MovementComponent movementComponent;

    private void Awake()
    {
        mainBody = GetComponent<Rigidbody>();
        movementComponent = GetComponent<MovementComponent>();
        mainCollision = GetComponent<Collider>();
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        boneCollision = GetComponentsInChildren<Collider>();
    }

    public void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollBodies)
        {
            rigidbody.isKinematic = false;
        }
        foreach(var collider in boneCollision)
        {
            collider.enabled = true;
        }
        playerAnimator.enabled = false;
        movementComponent.canMove = false;
    }

    public void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollBodies)
        {
            rigidbody.isKinematic = true;
        }
        foreach (var collider in boneCollision)
        {
            collider.enabled = false;
        }
        mainCollision.enabled = true;
        playerAnimator.enabled = true;
        mainBody.isKinematic = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
