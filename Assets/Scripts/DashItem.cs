using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashItem: MonoBehaviour
{
    GameObject player;
    float Push = 0.25f;          // 공이 바닥에 닿을 때 밀어올리는 힘
    //RaycastHit Hit;             // 충돌 감지 레이캐스트
    //float HitRange = 0.5f;      // 충돌 감지 거리

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // 레이캐스트로 구현한 것
    /*
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.up, out Hit, HitRange))
        {
            Debug.Log("Raycast Detected");

            Ball ballscript = GameObject.Find("Ball").GetComponent<Ball>();
            Vector3 pos = new Vector3();
            pos = gameObject.transform.position;
            pos.y = gameObject.transform.position.y + 1.0f;
            player.transform.position = pos;
            ballscript.Velocity = -Push;
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Trigger Detected");

            // Ball에서 변수를 가져오기 위해 호출해 왔습니다
            Ball ballscript = GameObject.Find("Ball").GetComponent<Ball>();

            //Vector3 pos = new Vector3();
            //pos = player.transform.position;

            // 플레이어가 아래로 빠져버리지 않게 y축 위치를 재조정합니다
            //pos.y = gameObject.transform.position.y + 1.0f;
            //player.transform.position = pos;

            //대쉬 활성화 여부를 true로 설정합니다.
            ballscript.DashActivate = true;
            //아이템은 파괴됩니다.
            Destroy(gameObject);
        }
    }
}
