using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRoute : MonoBehaviour
{
    public List<Transform> wps;
    public List<Transform> route;
    public int routeNumber = 0;
    public int targetWP = 0;
    public float moveSpeed = 6.0f;
    public float dist;
    public Rigidbody rb;
    public bool go = false;
    public float initialDelay;
    // Start is called before the first frame update
    void Start()
    {
        wps = new List<Transform>();
        GameObject wp;

        for (int i = 0; i < 9; i++)
        {
            string waypoint = "CWP" + (i + 1).ToString();

            wp = GameObject.Find(waypoint);
            wps.Add(wp.transform);
        }
        rb = GetComponent<Rigidbody>();
        SetRoute();
        initialDelay = Random.Range(2.0f, 20.0f);
        transform.position = new Vector3(0.0f, -5.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!go)
        {
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0.0f)
            {
                go = true;
                SetRoute();
            }
            else return;
        }

        Vector3 displacement = route[targetWP].position - transform.position;
        displacement.y = 0;
        dist = displacement.magnitude;

        if (dist < 0.1f)
        {
            targetWP++;
            if (targetWP >= route.Count)
            {
                Transform oldCWP = route[route.Count - 1];
                SetRoute(oldCWP.name);
                return;
            }
        }

        Vector3 velocity = displacement;
        velocity.Normalize();
        velocity *= moveSpeed;
        // Apply new velocity
        Vector3 newPos = transform.position;
        newPos.y = 0.5f;
        newPos += velocity * Time.deltaTime;

        rb.MovePosition(newPos);

        Vector3 forwardDir = Vector3.RotateTowards(transform.forward, velocity, 10.0f * Time.deltaTime, 0f);
        Quaternion rotation = Quaternion.LookRotation(forwardDir);
        rb.MoveRotation(rotation);
    }

    void SetRoute(string x = "")
    {
        if (x == "")
        {
            //randomise the next route
            routeNumber = Random.Range(0, 5);
            //set the route waypoints
            if (routeNumber == 0) route = new List<Transform> { wps[0], wps[1], wps[2], wps[3], wps[4], wps[5], wps[6] };
            else if (routeNumber == 1) route = new List<Transform> { wps[0], wps[1], wps[2], wps[3], wps[4], wps[7], wps[8] };
            else if (routeNumber == 2) route = new List<Transform> { wps[8], wps[7], wps[4], wps[3], wps[2], wps[1], wps[0] };
            else if (routeNumber == 3) route = new List<Transform> { wps[8], wps[7], wps[4], wps[5], wps[6] };
            else if (routeNumber == 4) route = new List<Transform> { wps[6], wps[5], wps[4], wps[3], wps[2], wps[1], wps[0] };
            else if (routeNumber == 5) route = new List<Transform> { wps[6], wps[5], wps[4], wps[7], wps[8] };

            //initialise position and waypoint counter
            transform.position = new Vector3(route[0].position.x, 0.0f,
            route[0].position.z);
            targetWP = 1;
        }
        else
        {
            bool routeFound = false;
            while (!routeFound)
            {
                routeNumber = Random.Range(0, 5);
                string oldWP = "CWP" + x.ToString();
                if (routeNumber == 0) route = new List<Transform> { wps[0], wps[1], wps[2], wps[3], wps[4], wps[5], wps[6] };
                else if (routeNumber == 1) route = new List<Transform> { wps[0], wps[1], wps[2], wps[3], wps[4], wps[7], wps[8] };
                else if (routeNumber == 2) route = new List<Transform> { wps[8], wps[7], wps[4], wps[3], wps[2], wps[1], wps[0] };
                else if (routeNumber == 3) route = new List<Transform> { wps[8], wps[7], wps[4], wps[5], wps[6] };
                else if (routeNumber == 4) route = new List<Transform> { wps[6], wps[5], wps[4], wps[3], wps[2], wps[1], wps[0] };
                else if (routeNumber == 5) route = new List<Transform> { wps[6], wps[5], wps[4], wps[7], wps[8] };
                // Debug.Log(oldWP);
                // Debug.Log(route[0]);

                if (route[0].name == x)
                {

                    transform.position = new Vector3(route[0].position.x, 0.0f, route[0].position.z);
                    targetWP = 1;
                    routeFound = true;
                }
            }
        }

    }
}