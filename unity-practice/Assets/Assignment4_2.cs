// 멀티미디어공학과 2016112661 김현우 2021/03/15

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4_2 : MonoBehaviour
{
    private int[,] points;

    // keycode 미리 선언해두기
     private KeyCode[] numberKeyCodes = {
         KeyCode.Alpha0,
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Solutions());
    }

    // Update is called once per frame
    void Update() {

    }

    // 최초 실행 시 바로 문제를 실행하지 않고 1이나 2의 입력을 기다린 뒤 다음 코드 실행
    IEnumerator Solutions() {
        Debug.Log("1번 혹은 2번을 입력해 주세요.");
        bool done = false;

        // 반복문을 돌면서 Input.GetKeyDown을 통해 원하는 키 입력이 들어올 때까지 다음 프레임(함수)의 실행을 멈춤
        // yield return null; 시 다음 프레임이 실행되지 않고 반복문 안을 계속적으로 순회함
        while(!done) {
            if (Input.GetKeyDown(numberKeyCodes[1])) {
                done = true;
                yield return Solution1();
            }
            else if (Input.GetKeyDown(numberKeyCodes[2])) {
                done = true;
                yield return Solution2();
            }
            yield return null;
        }
        Debug.Log("끝!");

        yield break;
    }

    // 1번 문제
    IEnumerator Solution1() {
        Debug.Log("1번 문제");

        // 바로 1번 좌표의 x값이 입력되어 잠시 대기할 수 있도록 하는 코드
        yield return new WaitForSeconds(0.1f);

        yield return InputPoints(4);
        int[] point1 = GetPoint(points, 0);
        int[] point2 = GetPoint(points, 1);
        int[] point3 = GetPoint(points, 2);
        int[] point4 = GetPoint(points, 3);

        Debug.Log("(" + string.Join(",", point1) + "),(" + string.Join(",", point2) + ")와 (" 
            + string.Join(",", point3) + "),(" + string.Join(",", point4) + ")의 거리 차이");

        float difference = GetDifferenceOfDistance(point1, point2, point3, point4);
        Debug.Log(difference);

        yield break;
    }

    // 매개변수로 받는 갯수 만큼의 좌표 배열을 생성
    IEnumerator InputPoints(int count) {
        points = new int[count, 2];
        for (int i = 0; i < count; i++) {
            Debug.Log((i + 1)  + "번째 x좌표를 키보드로 입력하시오.");
            yield return InputPoint(i, 0);

            Debug.Log((i + 1) + "번째 y좌표를 키보드로 입력하시오.");
            yield return InputPoint(i, 1);

            yield return null;
        }

        yield break;
    }

    // 하나의 좌표값을 입력받음
    IEnumerator InputPoint(int no, int value) {
        bool done = false;

        while(!done) {
            for (int i = 0; i < numberKeyCodes.Length; i++) {
                if (Input.GetKeyDown(numberKeyCodes[i])) {
                    points[no, value] = i;
                    done = true;
                    Debug.Log(i + "입력하셨습니다");
                }
            }
            yield return null;
        }

        yield break;
    }

    // 2차원 배열의 points에서 한 행만 1차원 배열로 반환함.
    int[] GetPoint(int[,] points, int row) {
        return new int[] { points[row, 0], points[row, 1] };
    }

    // 주어진 좌표 4개에서 두 좌표쌍의 거리 차이를 계산
    float GetDifferenceOfDistance(int[] point1, int[] point2, int[] point3, int[] point4) {
        float distance1 = GetDistance(point1, point2);
        float distance2 = GetDistance(point3, point4);
        return Mathf.Abs(distance1 - distance2); // 절댓값을 반환
    }

    // 하나의 좌표 쌍의 거리를 계산
    float GetDistance(int[] point1, int[] point2) {
        int x1 = point1[0];
        int y1 = point1[0];

        int x2 = point2[1];
        int y2 = point2[1];

        int width = x2 - x1;
        int height = y2 - y1;

        return Mathf.Sqrt(width * width + height * height);
    }

    // 2번 문제
    IEnumerator Solution2() {
        Debug.Log("2번 문제");

        int[] scores = GenerateRandomArray(20, 50, 101);

        foreach (int score in scores) {
            string grade = GetGrade(score);
            Debug.Log(score + " : " + grade);
        }

        yield break;
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