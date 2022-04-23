using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCarMesh : MonoBehaviour
{
    public MeshFilter[] carMeshArray;

    public MeshFilter carMesh;

    private void Awake()
    {
        carMesh = GetComponent<MeshFilter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var randomMesh = Random.Range(0, carMeshArray.Length);
        carMesh.sharedMesh = carMeshArray[randomMesh].sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
