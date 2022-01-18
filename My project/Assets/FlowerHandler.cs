using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class FlowerHandler : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform flowerObj = null;
    
    // Use this for initialization
    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");
        if(currentLookInt == 15 ) {
            
            if(flowerObj != null) {
                
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.0F, 0.84F, t));
                robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, -Mathf.Lerp(0.0F, 0.65F, t));
                robotAnimator.SetIKPosition(AvatarIKGoal.LeftHand, flowerObj.position);

                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 1.0F, t));
                robotAnimator.SetLookAtPosition(flowerObj.position);
                t += 0.5f * Time.deltaTime;
            }

        }
        
        else if (currentLookInt == 16)
        {
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.84F, 0.0F, t));
            robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, -Mathf.Lerp(0.65F, 0.0F, t));
            robotAnimator.SetLookAtWeight(Mathf.Lerp(1.0F, 0.0F, t));
            t += 0.65f * Time.deltaTime;
        }

    }  


    // Update is called once per frame
    void Update()
    {
        
    }
}