using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    //GameManager ������Ʈ�� ��ũ��Ʈ�� ���ԵǾ� �ֽ��ϴ�.
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
            // �ȼ� ȭ�鿡���� vertical�� horizontal �ȼ�ȭ�鿡 ���� ���� ���缭 ���̱�
            // Screen.width = 884, Screen.height = 515
            Vector3 Fordir = Wheel_Fin_Posit - Wheel_Init_Posit;
            vertical = Fordir.y * 69.999f / Screen.width ;
            horizontal = Fordir.x * 69.999f / Screen.height;
            

        }

        // ���� �߽� - ī�޶��� ��ġ �� ���ؼ� x,z ��ǥ�� ���� ���� ������ ��Ÿ���� ���� ���� ���ϱ�
        public float CalculateAngle(Vector3 from, Vector3 to)
        {
            from.y = to.y = 0;
            Vector3 v = to - from;
            return Mathf.Atan2(v.z, v.x);

        }

        // ���� ������ ���� ��ġ ���ϱ�, World ��ǥ , h�� �ȼ� ȭ�鿡�� horizontal ����, v�� �ȼ� ȭ�鿡�� vertical ����
        public Vector3 ForcedPoint()
        {
            // �� �ٸ� ��ġ�� �̵��� ���� �ÿ� ���� ���� ���⿡�� �� ���ϱ�
            if (horizontal == 0 && vertical == 0)
            {
                Vector3 normal = -(Whiteball.position - Cam.position).normalized * 69.999f;
                normal.y = 0;
                return Whiteball.position + normal;
            }               

            Vector3 Point;
            float theta = CalculateAngle(Cam.position, Whiteball.position); // �������Ͱ� World ������ �̷�� ��
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