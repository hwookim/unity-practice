/*
  학과: 멀티미디어공학과
  학번: 2016112661
  이름: 김현우
  제출일자: 2021.03.29 21:40
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpwan;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpwan = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpwan += Time.deltaTime;

        if (timeAfterSpwan >= spawnRate) {
            timeAfterSpwan = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null) {
                gameObject.SetActive(false);

                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.DestroyBulletSpawner();
            }
        }
    }
}
