using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class FensterHandler : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform FensterGrabPoint = null;
    private float weight = 0.0f;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    
    // Use this for initialization
    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");
        // 4 = obj
        if(currentLookInt == 9) {

            // move
            if(FensterGrabPoint != null)
            {
                weight = Mathf.Lerp(0.0F, 1.0F, t);
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
                robotAnimator.SetIKPosition(AvatarIKGoal.RightHand, FensterGrabPoint.position);
                robotAnimator.SetIKRotation(AvatarIKGoal.RightHand, FensterGrabPoint.rotation);
                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 0.4F, t));
                robotAnimator.SetLookAtPosition(FensterGrabPoint.position);
                t += 0.5f * Time.deltaTime;
            }

        }
        
        if (weight == 1.0F)
        {
            /*
            Vector3 destination = FensterGrabPoint.position;
            destination.z = destination.z - 0.238F;

            robotAnimator.SetIKPosition(AvatarIKGoal.RightHand, FensterGrabPoint.position);
            robotAnimator.SetIKRotation(AvatarIKGoal.RightHand, FensterGrabPoint.rotation);
            t += 0.5f * Time.deltaTime;
            */
        }

        //if IK is not active
        else if (currentLookInt == 10)
        {
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(1.0F, 0.0F, t));
            robotAnimator.SetLookAtWeight(Mathf.Lerp(0.4F, 0.0F, t));
            t += 0.5f * Time.deltaTime;
        }
    }  


    // Update is called once per frame
    void Update()
    {
    }
}