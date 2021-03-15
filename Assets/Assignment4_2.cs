// 멀티미디어공학과 2016112661 김현우 2021/03/15

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Solution1();
        Solution2();
    }

    // Update is called once per frame
    void Update() {
        
    }

    // 1번 문제
    void Solution1() {
        Debug.Log("1번 문제");

        float difference = GetDifferenceOfDistance(2, 2, 3, 3, 4, 4, 10, 10);
        Debug.Log(difference);
    }

    // 주어진 좌표 4개에서 두 좌표쌍의 거리 차이를 계산
    float GetDifferenceOfDistance(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4) {
        float distance1 = GetDistance(x1, y1, x2, y2);
        float distance2 = GetDistance(x3, y3, x4, y4);
        return Mathf.Abs(distance1 - distance2); // 절댓값을 반환
    }

    // 하나의 좌표 쌍의 거리를 계산
    float GetDistance(float x1, float y1, float x2, float y2) {
        float width = x2 - x1;
        float height = y2 - y1;

        return Mathf.Sqrt(width * width + height * height);
    }
}
