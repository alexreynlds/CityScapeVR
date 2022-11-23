using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : MonoBehaviour
{
    public GameObject pedPrefab;
    public int pedAmount;
    public int numSpawned;
    // Start is called before the first frame update
    void Start()
    {
        pedAmount = 6;

        for (int i = 0; i < pedAmount; i++)
        {
            Instantiate(pedPrefab, new Vector3(0, -5, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
