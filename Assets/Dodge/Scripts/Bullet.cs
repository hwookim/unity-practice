/*
  학과: 멀티미디어공학과
  학번: 2016112661
  이름: 김현우
  제출일자: 2021.03.29 21:40
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null) {
                playerController.Die();
            }
        }
    }
}
