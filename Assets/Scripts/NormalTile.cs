using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTile : MonoBehaviour
{
    GameObject player;
    float Push = 0.25f;          // ���� �ٴڿ� ���� �� �о�ø��� ��
    //RaycastHit Hit;             // �浹 ���� ����ĳ��Ʈ
    //float HitRange = 0.5f;      // �浹 ���� �Ÿ�

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    // ����ĳ��Ʈ�� ������ ��
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
        if(other.gameObject == player)
        {
            Debug.Log("Trigger Detected");

            // Ball���� ������ �������� ���� ȣ���� �Խ��ϴ�
            Ball ballscript = GameObject.Find("Ball").GetComponent<Ball>();

            Vector3 pos = new Vector3();
            pos = player.transform.position;

            // �÷��̾ �Ʒ��� ���������� �ʰ� y�� ��ġ�� �������մϴ�
            pos.y = gameObject.transform.position.y + 1.0f;
            player.transform.position = pos;

            // ���� ���� �о�ø��ϴ�
            ballscript.Velocity = -Push;
        }
    }
}