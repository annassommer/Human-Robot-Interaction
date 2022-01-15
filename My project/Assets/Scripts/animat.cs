using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.AnimatedValues;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.AI;
using UnityEngine.XR;

public class animat : MonoBehaviour
{

    public bools gB;
    public GameObject target;
    public GameObject handBone;
    public bool useHandIk;
    public Bone bone;
    public Vector3 handPos;
    public Vector3 positionObject;
    public GameObject handOb;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    
    void OnAnimatorIK()
    {
        if (useHandIk)
        {
            setHandsPos();
        }
    }
    
    void setHangOn()
    {
        gB.attachPillsHandle = true;
    }
    
    void setIKOff()
    {
        gB.doPickupHandle = false;
    }
    
    void setIKOn()
    {
        gB.doPickupHandle = true;
    }


    void FixedUpdate()
    {
        positionObject = target.transform.position;
        positionObject.x = positionObject.x - 0.1f;
    }

    void setHandsPos()
    {
        
        if (gB.doPickupHandle)
        {
            anim.SetLookAtWeight(0.3f);
            anim.SetLookAtPosition(positionObject);
            anim.SetFloat("HandWeight", 89, 0.8f, Time.deltaTime * 0.3f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, anim.GetFloat("HandWeight"));
            anim.SetIKPosition(AvatarIKGoal.RightHand, positionObject);
            //anim.SetIKRotation(AvatarIKGoal.RightHand, );
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            
        }
    }


    void DrawCircle(Vector3 center, float radius, Color color)
    {
        Vector3 prevPos = center + new Vector3(radius, 0, 0);
        for (int i = 0; i < 30; i++)
        {
            float angle = (float)(i + 1) / 30.0f * Mathf.PI * 2.0f;
            Vector3 newPos = center + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            Debug.DrawLine(prevPos, newPos, color);
            prevPos = newPos;
        }
    }
}