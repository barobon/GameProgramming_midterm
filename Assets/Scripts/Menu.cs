using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToStage1()  //stage1 scene으로 이동하는 함수
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ToStage2()  //stage2 scene으로 이동하는 함수
    {
        //stage2 구현시 추가
        //SceneManager.LoadScene();
    }
    public void ToStage3()  //stage3 scene으로 이동하는 함수
    {
        //stage3 구현시 추가
        //SceneManager.LoadScene();
    }
}
