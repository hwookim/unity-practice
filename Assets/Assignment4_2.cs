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

    // 2번 문제
    void Solution2() {
        Debug.Log("2번 문제");

        int[] scores = GenerateRandomArray(20, 50, 101);

        foreach (int score in scores) {
            string grade = GetGrade(score);
            Debug.Log(score + " : " + grade);
        }
    }

    // 특정 사이즈의 랜덤 배열을 생성, 랜덤 시작값과 끝값을 인자로 받음
    int[] GenerateRandomArray(int size, int start, int end) {
        int[] array = new int[size];
        for(int i = 0; i < size; i++) {
            array[i] = Random.Range(start, end);
        }

        return array;
    }

    // 점수에 따라 학점을 반환
    string GetGrade(int score) {
        if (score > 100 && score < 0) {
            return "ERROR";
        }
        else if (score >= 90) {
            return "A";
        } 
        else if (score >= 80) {
            return "B";
        } 
        else if (score >= 70) {
            return "C";
        } 
        else if (score >= 60) {
            return "D";
        }
        else {
            return "F";
        }
    }
}
