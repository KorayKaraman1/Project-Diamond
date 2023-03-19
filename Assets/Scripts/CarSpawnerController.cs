using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerController : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject[] cars1;
    public PlayerController playerController;
    private float time;
    public float rangeLeft, rangeRight, rangeLeft2, rangeRight2, rangeLeft3, rangeRight3, rangeRight4, rangeLeft4;

    void Start()
    {
        
    }


    void Update()
    {
        

    }

    public IEnumerator SpawnCars(float time)
    {
        while (playerController.canMove)
        {
            time = Random.Range(0.5f, 4);
            int randomIndex = Random.Range(0, cars.Length);
            Instantiate(cars[randomIndex], new Vector3(Random.Range(rangeLeft, rangeRight),0,35), Quaternion.Euler(0,180,0), transform);
            yield return new WaitForSeconds(time);
           
        }
    }
    public IEnumerator SpawnCars2(float time)
    {
        while (playerController.canMove)
        {
            time = Random.Range(1f, 5);
            int randomIndex = Random.Range(0, cars1.Length);
            Instantiate(cars1[randomIndex], new Vector3(Random.Range(rangeLeft2, rangeRight2), 0, 35), Quaternion.identity, transform);
            yield return new WaitForSeconds(time);

        }
    }
    public IEnumerator SpawnCars1(float time)
    {
        while (playerController.canMove)
        {
            time = Random.Range(1f, 5);
            int randomIndex = Random.Range(0, cars1.Length);
            Instantiate(cars1[randomIndex], new Vector3(Random.Range(rangeLeft3, rangeRight3), 0, 35), Quaternion.identity, transform);
            yield return new WaitForSeconds(time);

        }
    }
    public IEnumerator SpawnCars3(float time)
    {
        while (playerController.canMove)
        {
            time = Random.Range(0.5f, 4);
            int randomIndex = Random.Range(0, cars.Length);
            Instantiate(cars[randomIndex], new Vector3(Random.Range(rangeLeft4, rangeRight4), 0, 35), Quaternion.Euler(0, 180, 0), transform);
            yield return new WaitForSeconds(time);

        }
    }
    public void CarSpawner()
    {
        StartCoroutine(SpawnCars(time));
        StartCoroutine(SpawnCars2(time));
        StartCoroutine(SpawnCars1(time));
        StartCoroutine(SpawnCars3(time));
    }
    
}
