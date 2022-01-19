using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    public class CueScript : MonoBehaviour
    {
        Vector3 offsetPos = new Vector3(0.03f, -0.5f, -0.1f); //ť�� �ʱ� ��ġ ������
        public GameObject whiteBall;

        // Start is called before the first frame update
        void Start()
        {
            whiteBall = GameObject.Find("Ball_0");
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.isBallStop.Sum() == 16) // ��� ���� ������ ���� ���
            {
                //ť�� ��ġ �ʱ�ȭ
                transform.position = Camera.main.transform.position + offsetPos; //ȭ�鿡 ������ ���̵��� ��ġ
                //transform.rotation = Camera.main.transform.localRotation;
                transform.LookAt(whiteBall.transform); //�� ���� �ٶ󺸰� �Ѵ�
                transform.rotation = Quaternion.LookRotation(transform.position - whiteBall.transform.position); //ť�� ������ �ݴ뿩�� ����

            }

        }
    }
}
