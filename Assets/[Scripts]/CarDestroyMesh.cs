using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }
    }
}
