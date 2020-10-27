using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    float G;            // 중력 가속도
    public float Velocity;    // 떨어지는 속도(중력가속도에 의한 속도)
    float TimeScale;    // 타임 스케일 조정
    public float BounceSpeed;        // 움직이는 속도
    public float MoveSpeed;      // 방향키 움직이는 속도
    public int MaxX = 3;    // X축 한계값 설정
    public int MaxZ = 1;    // Z축 한계값 설정
    public Vector3 StartPos;// 떨어졌을 시 새로 시작하는 좌표값
    public bool DashActivate = false;    // 대쉬 활성화 여부
    public uint WCountValue = 0;        //대쉬 카운트 변수
    public uint SCountValue = 0;
    public uint ACountValue = 0;
    public uint DCountValue = 0;

    Vector3 BallPos;

    void Start()
    {
        TimeScale = 10000.0f;
        G = (9.8f / TimeScale) * BounceSpeed;
        Velocity = 0;
        //BallPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BallPos = gameObject.transform.position;

        // 교수님이 주신 코드로 공이 일정하게 튀어오르도록 한 부분
        // 사용하지 않는 변수들을 제거하면서 변수명을 변경하였습니다.
        // Velocityg -> Velocity
        Velocity += G;
        BallPos.y -= Velocity;
        /*
        // 땅에 닿았을 경우
        if (BallPos.y <= 0.0f)
        {
            BallPos.y = 0.0f;

            // 변경 코드 (일정한 힘을 위로 밀어줌)
            Velocity = -Push;

            // 기존 코드 개선안 (바닥에 닿는 힘만큼 위로 튕겨냄)
            //Velocity = Mathf.Round(-Velocity * 10) * 0.1f;

            // 속도를 확인하기 위한 로그 출력
            Debug.Log(Velocity);
        }
        */

        // 너무 낮게 떨어졌을 경우 초기 위치로 되돌린다
        // 이후 게임오버로 수정해야 함
        if (BallPos.y <= -20.0f)
        {
            BallPos = StartPos;
        }

        gameObject.transform.position = BallPos;

        //공이 WASD키로 움직이게 한 부분
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(BallPos.x - (0.01f * MoveSpeed), BallPos.y, BallPos.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(BallPos.x + (0.01f * MoveSpeed), BallPos.y, BallPos.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(BallPos.x, BallPos.y, BallPos.z - (0.01f * MoveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(BallPos.x, BallPos.y, BallPos.z + (0.01f * MoveSpeed));
        }

        //키 더블클릭 입력을 구현한 부분입니다.
        if (DashActivate == true)//dashItem을 먹었을 때
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                WCountValue++;
                if (!IsInvoking("disable_DoubleClick"))
                    Invoke("disable_DoubleClick", 0.5f);
            }
            if (WCountValue == 2)
            {
                CancelInvoke("disable_DoubleClick");
                gameObject.transform.position = new Vector3(BallPos.x - 3f, BallPos.y, BallPos.z);
                DashActivate = false;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                SCountValue++;
                if (!IsInvoking("disable_DoubleClick"))
                    Invoke("disable_DoubleClick", 0.5f);
            }
            if (SCountValue == 2)
            {
                CancelInvoke("disable_DoubleClick");
                gameObject.transform.position = new Vector3(BallPos.x + 3f, BallPos.y, BallPos.z);
                DashActivate = false;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ACountValue++;
                if (!IsInvoking("disable_DoubleClick"))
                    Invoke("disable_DoubleClick", 0.5f);
            }
            if (ACountValue == 2)
            {
                CancelInvoke("disable_DoubleClick");
                gameObject.transform.position = new Vector3(BallPos.x, BallPos.y, BallPos.z - 3f);
                DashActivate = false;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                DCountValue++;
                if (!IsInvoking("disable_DoubleClick"))
                    Invoke("disable_DoubleClick", 0.5f);
            }
            if (DCountValue == 2)
            {
                CancelInvoke("disable_DoubleClick");
                gameObject.transform.position = new Vector3(BallPos.x, BallPos.y, BallPos.z + 3f);
                DashActivate = false;
            }
        }
    }

    //키 더블클릭의 CountValue를 0으로 만드는 함수입니다.
    void disable_DoubleClick()
    {
        WCountValue = 0;
        SCountValue = 0;
        ACountValue = 0;
        DCountValue = 0;
    }

}