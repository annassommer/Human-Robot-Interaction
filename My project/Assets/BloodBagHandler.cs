using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class BloodBagHandler : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform BloodBagZeig = null;
    private float weight = 0.0f;
    public GameObject ribs;
    private float ribsRotX = 0.0f;

    // Use this for initialization
    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");
        // 4 = obj
        //Debug.Log(currentLookInt);
        if(currentLookInt == 11) {

            // move
            if(BloodBagZeig != null)
            {
                weight = Mathf.Lerp(0.0F, 0.85F, t);
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
                robotAnimator.SetIKPosition(AvatarIKGoal.RightHand, BloodBagZeig.position);
                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 0.4F, t));
                robotAnimator.SetLookAtPosition(BloodBagZeig.position);
                //ribsRotX = Mathf.Lerp(0.0F, 0.4F, t);
                //ribs.transform.rotation.x = ribsRotX;
                Quaternion target = Quaternion.Euler(255, 0, 0);
                ribs.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 0.5F);


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
        else if (currentLookInt == 12)
        {
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(0.85F, 0.0F, t));
            robotAnimator.SetLookAtWeight(Mathf.Lerp(0.4F, 0.0F, t));
            t += 0.5f * Time.deltaTime;
        }
    }  


    // Update is called once per frame
    void Update()
    {
    }
}