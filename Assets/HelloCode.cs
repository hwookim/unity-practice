using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name = "리라";
        char bloodType = 'A';
        int age = 17;
        float height = 168.3f;
        bool isFemale = true;

        Debug.Log("캐릭터 이름 : " + name);
        Debug.Log("혈액형 : " + bloodType);
        Debug.Log("나이 : " + age);
        Debug.Log("키 : " + height);
        Debug.Log("여성인가? : " + isFemale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
