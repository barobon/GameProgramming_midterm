using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    // �� ��ƾ� �ϴ� ���� ����
    public int MaxStar = 3;
    // �÷��̾ ������ ���� ���� (�̰� ������ ������ �ǵ帮�� ������)
    public int CollectedStar;
    // �÷��̾ ������ ���� ������ ����� �ؽ�Ʈ, �ؽ�Ʈ ������Ʈ�� �Ҵ�
    public Text StarCountTxt;
    // Start is called before the first frame update
    void Start()
    {
        //���� ���۽� ����� �ؽ�Ʈ
        StarCountTxt.text = "Star: 0 /" + MaxStar;
        CollectedStar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StarCountTxt.text = "Star:" + CollectedStar + "/" + MaxStar;
        if (CollectedStar >= MaxStar)
        {
            // �¸�ó���� �ϰ� �¸� �˾��� ����Ѵ�.
            Debug.Log("All Star has been Collected!");

            // ������Ʈ�� �����Ͽ� ��� ������Ʈ�� ����Ǵ� ���� �����Ѵ�
            Destroy(gameObject);
        }
    }
}