using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform startLocation;
    public Transform endLocation;

    public float speed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        var directionToGoal = endLocation.position - startLocation.position;
        
        transform.forward = directionToGoal;
        rb.AddForce(directionToGoal * speed, ForceMode.Acceleration);
        
        if(transform.position == endLocation.position)
        {
            Destroy(gameObject);
        }
    }
}
