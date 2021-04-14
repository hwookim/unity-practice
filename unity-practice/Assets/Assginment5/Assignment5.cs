/*
  학과: 멀티미디어공학과
  학번: 2016112661
  이름: 김현우
  제출일자: 2021.03.16 10:25
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Assignment5 : MonoBehaviour
{
    // 스크립트가 적용된 object를 매칭함
    public GameObject gameObject;
    // 물리제어를 위한 객체
    public Rigidbody rigidbody;

    // 객체의 순서에 따라 가해질 힘의 크기
    int[] jumperForce = {500, 1000};

    // Start is called before the first frame update
    void Start()
    {
        // 1번인지 2번인지 알기 위해 이름을 받아와서 뒤의 숫자만 추출함
        string name = gameObject.name;
        int number = int.Parse(Regex.Replace(name, "[^0-9]", "")) - 1;

        Debug.Log(jumperForce[number] + " force is applied to " + name);

        rigidbody.AddForce(0, jumperForce[number], 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
