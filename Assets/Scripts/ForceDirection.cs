using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    //GameManager 오브젝트에 스크립트가 포함되어 있습니다.
    public class ForceDirection : MonoBehaviour
    {

        
        public Transform Cam;
        public Transform Whiteball;

        public Vector3 Wheel_Init_Posit;
        public Vector3 Wheel_Fin_Posit;

        float horizontal = 0;
        float vertical = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            MousePosit();
            // 픽셀 화면에서의 vertical과 horizontal 픽셀화면에 대한 비율 맞춰서 줄이기
            // Screen.width = 884, Screen.height = 515
            Vector3 Fordir = Wheel_Fin_Posit - Wheel_Init_Posit;
            vertical = Fordir.y * 69.999f / Screen.width ;
            horizontal = Fordir.x * 69.999f / Screen.height;
            

        }

        // 구의 중심 - 카메라의 위치 를 통해서 x,z 좌표계 위의 공의 방향을 나타내는 법선 벡터 구하기
        public float CalculateAngle(Vector3 from, Vector3 to)
        {
            from.y = to.y = 0;
            Vector3 v = to - from;
            return Mathf.Atan2(v.z, v.x);

        }

        // 힘이 가해질 점의 위치 구하기, World 좌표 , h는 픽셀 화면에서 horizontal 방향, v는 픽셀 화면에서 vertical 방향
        public Vector3 ForcedPoint()
        {
            // 별 다른 위치의 이동이 없을 시에 법선 벡터 방향에서 힘 가하기
            if (horizontal == 0 && vertical == 0)
            {
                Vector3 normal = -(Whiteball.position - Cam.position).normalized * 69.999f;
                normal.y = 0;
                return Whiteball.position + normal;
            }               

            Vector3 Point;
            float theta = CalculateAngle(Cam.position, Whiteball.position); // 법선벡터가 World 원점과 이루는 각
            Point.y = vertical;
            Point.x = horizontal * Mathf.Sin(theta) - Mathf.Sqrt(69.999f * 69.999f - horizontal * horizontal - vertical * vertical) * Mathf.Cos(theta);
            Point.z = -horizontal * Mathf.Cos(theta) - Mathf.Sqrt(69.999f * 69.999f - horizontal * horizontal - vertical * vertical) * Mathf.Sin(theta);

            return Point + Whiteball.position;
        }

        void MousePosit()
        {
            if (Input.GetMouseButtonDown(2))
            {
                Wheel_Init_Posit = Input.mousePosition;
            }

            if(Input.GetMouseButtonUp(2))
            {
                Wheel_Fin_Posit = Input.mousePosition;
            }
        }

    }
}