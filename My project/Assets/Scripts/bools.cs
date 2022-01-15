using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bools : MonoBehaviour
{
    //public so can change in unity editor
    public bool attachPills;

    public bool doPickup;

    public bool overwriteHandle
    {
        get => overwrite;
        set => overwrite = value;
    }

    private bool overwrite;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public bool attachPillsHandle
    {
        get => attachPills;
        set => attachPills = value;
    }

    public bool doPickupHandle
    {
        get => doPickup;
        set => doPickup = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
