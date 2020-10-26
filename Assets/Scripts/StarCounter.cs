using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    // 총 모아야 하는 별의 개수
    public int MaxStar = 3;
    // 플레이어가 습득한 별의 개수 (이건 에디터 내에서 건드리지 마세요)
    public int CollectedStar;
    // 플레이어가 습득한 별의 개수를 출력할 텍스트, 텍스트 오브젝트를 할당
    public Text StarCountTxt;
    // Start is called before the first frame update
    void Start()
    {
        //게임 시작시 출력할 텍스트
        StarCountTxt.text = "Star: 0 /" + MaxStar;
        CollectedStar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StarCountTxt.text = "Star:" + CollectedStar + "/" + MaxStar;
        if (CollectedStar >= MaxStar)
        {
            // 승리처리를 하고 승리 팝업을 출력한다.
            Debug.Log("All Star has been Collected!");

            // 오브젝트를 제거하여 계속 업데이트가 실행되는 것을 방지한다
            Destroy(gameObject);
        }
    }
}
