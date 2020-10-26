using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTile : MonoBehaviour
{
    GameObject player;
    // RaycastHit Hit;             // 충돌 감지 레이캐스트
    // float HitRange = 0.5f;      // 충돌 감지 거리

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Wall Trigger Detected");

            // 이건 이론상 가능할 것 같아서...
            // 소수점을 무시하고 공과 벽의 좌표를 대조한다면, 가로로 벽에 부딪혔는지, 세로로 벽에 부딪혔는지
            // 어느정도 감지가 가능하지 않을까요?

            // X축 충돌
            if (Mathf.Round(player.transform.position.z) == Mathf.Round(gameObject.transform.position.z))
            {
                if (player.transform.position.x < gameObject.transform.position.x)
                {
                    Vector3 pos = new Vector3();
                    pos = gameObject.transform.position;
                    pos.x = gameObject.transform.position.x - 1.0f;
                    player.transform.position = pos;
                }
                else if(player.transform.position.x > gameObject.transform.position.x)
                {
                    Vector3 pos = new Vector3();
                    pos = gameObject.transform.position;
                    pos.x = gameObject.transform.position.x + 1.0f;
                    player.transform.position = pos;
                }
            }

            // Z축 충돌
            if (Mathf.Round(player.transform.position.x) == Mathf.Round(gameObject.transform.position.x))
            {
                if (player.transform.position.z < gameObject.transform.position.z)
                {
                    Vector3 pos = new Vector3();
                    pos = gameObject.transform.position;
                    pos.z = gameObject.transform.position.z - 1.0f;
                    player.transform.position = pos;
                }
                else if (player.transform.position.z > gameObject.transform.position.z)
                {
                    Vector3 pos = new Vector3();
                    pos = gameObject.transform.position;
                    pos.z = gameObject.transform.position.z + 1.0f;
                    player.transform.position = pos;
                }
            }
        }
    }
}
