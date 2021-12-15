using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    public bools gB;
    public GameObject handOb;
    public Vector3 newPos;
    public GameObject gameBools;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gB.attachPillsHandle)
        {
            newPos = handOb.transform.position;
            newPos.z += 0.3f - 0.2572f;
            newPos.y -= 0.027961f;
            newPos.x -= 0.1f - 0.095844f;
            transform.position = newPos;
        }
    }
}

