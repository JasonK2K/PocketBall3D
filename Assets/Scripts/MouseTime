using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTime : MonoBehaviour
{    
    [Serializefield] private BallMovement ball;
    private float holdDownStartTime;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Mouse Down, start holding
            Debug.Log("ButtonDown!");
            holdDownStartTime = Time.time;
        }

        if(Input.GetMouseButton(0))
        {
            //Mouse still Down, show force
            Debug.Log("ButtonUp!");
            float holdDownTime = holdDownTime.time -holdDownStartTime;
            ball.Launch(CalculateHoldDownForce(holdDownTime));
            
        }
        if(Input.GetMouseButtonUp(0)){
            //Mouse Up, Launch
            float holdDownTime = holdDownTime.time -holdDownStartTime;
            ball.Launch(CalculateHoldDownForce(holdDownTime));

        }
    }

    private float CalculateHoldDownForce(float holdTime){
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized = Ball.BallForce;
        return force;
    }
}

