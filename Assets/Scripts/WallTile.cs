using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTile : MonoBehaviour
{
    GameObject player;
    // RaycastHit Hit;             // �浹 ���� ����ĳ��Ʈ
    // float HitRange = 0.5f;      // �浹 ���� �Ÿ�

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

            // �̰� �̷л� ������ �� ���Ƽ�...
            // �Ҽ����� �����ϰ� ���� ���� ��ǥ�� �����Ѵٸ�, ���η� ���� �ε�������, ���η� ���� �ε�������
            // ������� ������ �������� �������?

            // X�� �浹
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

            // Z�� �浹
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