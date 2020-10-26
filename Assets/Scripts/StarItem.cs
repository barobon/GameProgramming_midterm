using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Star Collected");

            // �� ī������ ������ �ø���, �÷��̾ �������� ������ 1 �����Ѵ�.
            StarCounter starCounterScript = GameObject.Find("StarCounter").GetComponent<StarCounter>();
            starCounterScript.CollectedStar += 1;

            Debug.Log("Collected Star: " + starCounterScript.CollectedStar);
            
            // ������Ʈ ����
            Destroy(gameObject);
        }
    }
}