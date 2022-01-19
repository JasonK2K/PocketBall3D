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
            if(ballVelocity == Vector3.zero && GameManager.Arraytrigger[BallNum]) //공이 완전히 멈췄을 때
            {
                //Debug.Log("Hi"+BallNum.ToString());
                GameManager.isBallStop[BallNum]=1; //공이 멈췄음을 표시
                GameManager.Arraytrigger[BallNum]=false;
            }
        }

        void OnMouseDown() //흰 공에만 적용
        {
            //Debug.Log(ballVelocity.x.ToString());
            if(GameManager.isBallStop.Sum()==16) // 모든 공이 완전히 멈춘 경우
            {
                if(BallNum==0) //흰 공을 클릭한 경우
                {
                    //힘 가함
                    //rb.AddForce(1500,0,0);
                    rb.AddForce(Camera.main.transform.forward * 1000);

                    //모든 공을 움직이는 상태로 표시 변경
                    for (int i=0; i<16; i++)
                    {
                        GameManager.isBallStop[i]=0;
                    }
                    // ?
                    foreach (var human in GameManager.isBallStop)
                    {
                        Debug.Log(human);
                    }
                    //Array Trigger 초기화
                    for(int j=0; j<16; j++)
                    {
                        GameManager.Arraytrigger[j]=true;
                    }
                }
            }
        }



    }
}