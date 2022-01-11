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
        public Vector3 ballDirection;
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
            if(ballVelocity == Vector3.zero && GameManager.Arraytrigger[BallNum]) // 공이 완전히 멈췄을 때
            {
                //Debug.Log("Hi"+BallNum.ToString());
                GameManager.isBallStop[BallNum]=1;
                GameManager.Arraytrigger[BallNum]=false;
            }
        }

        void OnMouseDown() //이거 흰공에만 적용해야함
        {
            
            Debug.Log(GameManager.isBallStop.Sum()); // 공이 없어지면서 뭔가 문제가 생긴듯
            if(GameManager.isBallStop.Sum()==16) // 모든 공이 완전히 멈췄을 때
            {
                if(BallNum==0)
                {
                    //흰공 방향 결정하자.
                    ballDirection=transform.position-PlayerScript.playerPosition;
                    ballDirection.y=0;                
                    Debug.Log(PlayerScript.playerPosition.x.ToString()+','+PlayerScript.playerPosition.z.ToString());
                    //힘 가함 -> 누를 수록 늘어나도록 하자.
                    rb.AddForce(ballDirection*500);

                    //초기화
                    for(int i=0; i<16; i++)
                    {
                        GameManager.isBallStop[i]=0;
                    }
                    
                    foreach (var human in GameManager.isBallStop)
                    {
                        //Debug.Log(human);
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