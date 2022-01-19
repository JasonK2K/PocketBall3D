using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    RaycastHit hit; //�������� ��� ��ü
    public GameObject whiteBall;

    // Start is called before the first frame update
    void Start()
    {
       whiteBall = GameObject.Find("Ball_0");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(whiteBall.transform); //ť�밡 �� ���� �ٶ󺸰� �Ѵ�

        Vector3 raycastDir = whiteBall.transform.position - transform.position; //������ ���� ����
        Debug.DrawRay(this.transform.position, raycastDir * 15f, Color.blue, 0.3f);
        if (Physics.Raycast(this.transform.position, raycastDir, out hit, 15f)) //�������� ��� ��ü�� �ִٸ�
        {
            //var localHit = transform.InverseTransformPoint(hit.point);            
            //Debug.Log(localHit);
            hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; //��ü�� �� ����
        }
        else
        {
            
        }
    }
}
