using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class DesinfectionHandler : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform bottleOdesinfect = null;
    

    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");
        // 4 = obj
        if(currentLookInt == 4) {


            if(bottleOdesinfect != null) {
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(0.0F, 1.0F, t));
                robotAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, Mathf.Lerp(0.0F, 0.3F, t));
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.0F, 1.0F, t));
                robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.0F, 0.3F, t));
                robotAnimator.SetIKPosition(AvatarIKGoal.RightHand, bottleOdesinfect.position);
                robotAnimator.SetIKRotation(AvatarIKGoal.RightHand, bottleOdesinfect.rotation);
                robotAnimator.SetIKPosition(AvatarIKGoal.LeftHand, bottleOdesinfect.position);
                robotAnimator.SetIKRotation(AvatarIKGoal.LeftHand, bottleOdesinfect.rotation);
                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 0.4F, t));
                robotAnimator.SetLookAtPosition(bottleOdesinfect.position);
                t += 0.5f * Time.deltaTime;
            }

        }
        
        else if (currentLookInt == 5)
        {
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, Mathf.Lerp(1.0F, 0.0F, t));
            robotAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, Mathf.Lerp(0.3F, 0.0F, t));
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(1.0F, 0.0F, t));
            robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.3F, 0.0F, t));
            robotAnimator.SetLookAtWeight(Mathf.Lerp(0.4F, 0.0F, t));
            t += 0.5f * Time.deltaTime;
        }
    }  
    
}