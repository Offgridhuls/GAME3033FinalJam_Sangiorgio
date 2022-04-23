using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private RagdollComponent ragdollComponent;
    private Rigidbody playerBody;
    private void Awake()
    {
        ragdollComponent = GetComponent<RagdollComponent>();
        playerBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        ragdollComponent.DisableRagdoll();
    }

    //public void OnDebugRagdoll(InputValue value)
    //{
    //    ragdollComponent.DisableRagdoll();
    //
    //}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            ragdollComponent.EnableRagdoll();

        }
    }
}
