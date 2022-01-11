using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    public class CameraScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
            //멈췄을 때
            //A(왼쪽) 눌렀을 때
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left*2*Time.deltaTime);
                Debug.Log("Hi");
            }

            //D(오른쪽) 눌렀을 때
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right*2*Time.deltaTime);
            }
        
        }
    }
}