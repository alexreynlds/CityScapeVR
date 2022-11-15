using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    public List<GameObject> trafficLights;
    public List<GameObject> greenLights;
    public List<GameObject> redLights;

    public float stateTimer;
    public int state;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            string tl = ("TL" + (i + 1).ToString());
            trafficLights.Add(GameObject.Find(tl));
            greenLights.Add(GameObject.Find(tl).transform.Find("Green light").gameObject);
            redLights.Add(GameObject.Find(tl).transform.Find("Red light").gameObject);
        }
        stateTimer = 10.0f;
        SetState(1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stateTimer > 0.0f)
        {
            stateTimer -= Time.deltaTime;
        }
        else if (stateTimer <= 0.0f)
        {
            if (state == 1)
            {
                SetState(0);
            }
            else
            {
                SetState(0);
            }
            stateTimer = 10.0f;
        }
    }

    void SetState(int c)
    {
        state = c;
        if (c == 1)
        {
            //The Initial Positions
            greenLights[0].SetActive(true);
            greenLights[1].SetActive(false);
            greenLights[2].SetActive(false);
            redLights[0].SetActive(false);
            redLights[1].SetActive(true);
            redLights[2].SetActive(true);
        }
        else
        {
            // Toggles the state of the lights.
            for (int i = 0; i < 3; i++)
            {
                greenLights[i].SetActive(!greenLights[i].activeInHierarchy);
                redLights[i].SetActive(!redLights[i].activeInHierarchy);
            }
        }
    }
}
