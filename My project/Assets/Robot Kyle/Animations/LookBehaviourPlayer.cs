using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class LookBehaviourPlayer : MonoBehaviour
{
    static float t = 0.0f;
    Animator robotAnimator;
    public Transform playerLookObj = null;
    
    // Use this for initialization
    void Start () {
        robotAnimator = GetComponent<Animator>();
    }

    public void countLTP()
    {
        int newValue = robotAnimator.GetInteger("LookTowardsPlayer") + 1;
        robotAnimator.SetInteger("LookTowardsPlayer",newValue);
        t = 0.0f;
    }

    void OnAnimatorIK()
    {
        int currentLookInt = robotAnimator.GetInteger("LookTowardsPlayer");

            if(currentLookInt == 2 || currentLookInt == 6 || currentLookInt == 8 || currentLookInt == 16 ) {
                
                if(playerLookObj != null) {
                    robotAnimator.SetLookAtWeight(Mathf.Lerp(0.0F, 1.0F, t));
                    robotAnimator.SetLookAtPosition(playerLookObj.position);
                    t += 0.5f * Time.deltaTime;
                }

            }
            
            else if (currentLookInt == 3 || currentLookInt == 7 || currentLookInt == 9 || currentLookInt == 17)
            {
                robotAnimator.SetLookAtWeight(Mathf.Lerp(1.0F, 0.0F, t));
                t += 0.5f * Time.deltaTime;
            }
            //TODO unclear section - does this help?
            else if (currentLookInt == 9)
            {
                robotAnimator.SetLookAtWeight(Mathf.Lerp(0.6F, 0.0F, t));
                t += 0.5f * Time.deltaTime;
            }
            
    }  
    
}
