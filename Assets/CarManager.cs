using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public List<GameObject> cars;
    public int carAmount;
    public int numSpawned;
    // Start is called before the first frame update
    void Start()
    {
        carAmount = 0;

        for (int i = 0; i < carAmount; i++)
        {
            int carType = Random.Range(0, cars.Count);
            Instantiate(cars[carType], new Vector3(0, -5, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
