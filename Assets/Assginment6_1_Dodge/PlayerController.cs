/*
  학과: 멀티미디어공학과
  학번: 2016112661
  이름: 김현우
  제출일자: 2021.03.22 22:30
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true) {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) == true) {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) == true) {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) == true) {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }
}
