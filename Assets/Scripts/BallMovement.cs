using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    public class BallMovement : MonoBehaviour
    {
        Rigidbody rb;
        public Vector3 ballVelocity;
        int BallNum;
        //private bool trigger = true;

        // 추가 
        public Transform Cam;
        public ForceDirection hr;

        // Start is called before the first frame update
        void Start()
        {
            rb=GetComponent<Rigidbody>();
            BallNum=int.Parse(gameObject.name.Substring(5));
        }

        // Update is called once per frame
        void Update()
        {
            ballVelocity=rb.velocity;
            if(ballVelocity == Vector3.zero && GameManager.Arraytrigger[BallNum]) // 공이 완전히 멈췄을 때
            {
                //Debug.Log("Hi"+BallNum.ToString());
                GameManager.isBallStop[BallNum]=1;
                GameManager.Arraytrigger[BallNum]=false;
            }
        }

        void OnMouseDown() //이거 흰공에만 적용해야함
        {

            //Debug.Log(ballVelocity.x.ToString());
            if(GameManager.isBallStop.Sum()==16) // 모든 공이 완전히 멈췄을 때
            {
                if(BallNum==0)
                {
                    //힘 가함
                    //rb.AddForce(1500,0,0);

                    Vector3 direction = (rb.position - Cam.position).normalized;
                    direction.y = 0;
                    //rb.AddForce(direction * 1000f);
                    // 타격 위치 확인 위한 debug.log
                    Debug.Log(hr.ForcedPoint());
                    Debug.Log(hr.BallPosit());

                    rb.AddForceAtPosition(direction*10f, hr.ForcedPoint(), ForceMode.Force);
                    

                    //초기화
                    for(int i=0; i<16; i++)
                    {
                        GameManager.isBallStop[i]=0;
                    }
                    
                    foreach (var human in GameManager.isBallStop)
                    {
                        Debug.Log(human);
                    }
                    //boolean 모두 true로 바꾸자
                    for(int j=0; j<16; j++)
                    {
                        GameManager.Arraytrigger[j]=true;
                    }
                }
            }
        }



    }
}