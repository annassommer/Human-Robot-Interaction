using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class MedicationsHandler : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform medications = null;
    public GameObject medicationsOb = null;
    
    // Use this for initialization
    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");
        // 4 = obj
        if(currentLookInt == 13) {

            if(medications != null) {
                robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(0.0F, 1.0F, t));
                robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, -Mathf.Lerp(0.0F, 0.65F, t));
                robotAnimator.SetIKPosition(AvatarIKGoal.LeftHand, medications.position);
                robotAnimator.SetIKRotation(AvatarIKGoal.LeftHand, medications.rotation);
                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 0.53F, t));
                robotAnimator.SetLookAtPosition(medications.position);
                t += 0.5f * Time.deltaTime;
            }

        }

        else if (currentLookInt == 14)
        {
            if (robotAnimator.GetBool("MedsVisible") == false)
            {
                robotAnimator.SetBool("MedsVisible", true);
                medicationsOb.GetComponent<MeshRenderer>().enabled = true;
            }
            
            robotAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Mathf.Lerp(1.0F, 0.0F, t));
            robotAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, -Mathf.Lerp(0.65F, 0.0F, t));
            robotAnimator.SetLookAtWeight(Mathf.Lerp(0.53F, 0.0F, t));
            t += 0.76f * Time.deltaTime;
        }
    }  


    // Update is called once per frame
    void Update()
    {
        
    }
}