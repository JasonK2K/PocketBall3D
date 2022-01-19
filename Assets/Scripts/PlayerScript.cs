using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JK
{
    public class PlayerScript : MonoBehaviour
    {

        public GameObject whiteBall;

        // Start is called before the first frame update
        void Start()
        {
            whiteBall = GameObject.Find("Ball_0");
        }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);
            
            //A(왼쪽) 눌렀을 때
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }

            //D(오른쪽) 눌렀을 때
            if(Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
            
        }
    }
}