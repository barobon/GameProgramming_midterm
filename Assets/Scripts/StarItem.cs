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

            // 별 카운터의 변수를 올리고, 플레이어가 수집별의 개수를 1 증가한다.
            StarCounter starCounterScript = GameObject.Find("StarCounter").GetComponent<StarCounter>();
            starCounterScript.CollectedStar += 1;

            Debug.Log("Collected Star: " + starCounterScript.CollectedStar);
            
            // 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
