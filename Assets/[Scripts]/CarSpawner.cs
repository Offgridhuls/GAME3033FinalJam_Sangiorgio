using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    public SpawnLocation[] carSpawnLocations;

    public Car carObject;
    public float spawnInterval;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval < 0)
        {
            int randomLocation = Random.Range(0, carSpawnLocations.Length);
            var car = Instantiate(carObject, carSpawnLocations[randomLocation].gameObject.transform.position, Quaternion.identity);
            car.endLocation = carSpawnLocations[randomLocation].otherLocation;
            car.startLocation = carSpawnLocations[randomLocation].transform;
            car.speed = Random.Range(.4f, .5f);
            spawnInterval = spawnTime;
        }
    }

}
