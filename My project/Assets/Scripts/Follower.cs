using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    private float distanceTravelled;

    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
