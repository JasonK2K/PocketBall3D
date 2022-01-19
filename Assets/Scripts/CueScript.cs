using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    public class CueScript : MonoBehaviour
    {
        Vector3 offsetPos = new Vector3(0.03f, -0.5f, -0.1f); //큐대 초기 위치 조정값
        public GameObject whiteBall;

        // Start is called before the first frame update
        void Start()
        {
            whiteBall = GameObject.Find("Ball_0");
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.isBallStop.Sum() == 16) // 모든 공이 완전히 멈춘 경우
            {
                //큐대 위치 초기화
                transform.position = Camera.main.transform.position + offsetPos; //화면에 적절히 보이도록 배치
                //transform.rotation = Camera.main.transform.localRotation;
                transform.LookAt(whiteBall.transform); //흰 공을 바라보게 한다
                transform.rotation = Quaternion.LookRotation(transform.position - whiteBall.transform.position); //큐대 방향이 반대여서 조정

            }

        }
    }
}
