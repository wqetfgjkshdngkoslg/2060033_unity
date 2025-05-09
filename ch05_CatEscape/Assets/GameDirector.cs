using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    GameObject gHpGuage = null;         // HP Gauge Image Object를 저장할 변수
    GameObject gGameOver = null;        //  게임오버 변수
    GameObject gGameReset = null;       //  게임 재시작 변수
    GameObject gMenu = null;
    

    void Start()
    {
        gHpGuage = GameObject.Find("hpGauge");
        gGameOver = GameObject.Find("GameOver");
        gGameReset = GameObject.Find("GameReset");
        gMenu = GameObject.Find("Menu");
        
    }

 
    // Update is called once per frame
    void Update()
    {
        if (gHpGuage.GetComponent<Image>().fillAmount > 0.0f)   // hp게이지가 0보다 클때
        {
            gGameOver.SetActive(false);             // 게임오버 텍스트 비활성화
            gGameReset.SetActive(false);            // 리셋 버튼 비활성화
            gMenu.SetActive(false);                 // 메뉴버튼 숨기기
            
        }
        else 
        {
            gMenu.SetActive(true);                 // 메뉴 버튼 활성화
            gGameOver.SetActive(true);              // 게임오버 텍스트 활성화
            gGameReset.SetActive(true);             // 리셋 버튼 활성화
        }


    }

    public void f_DeceaseHp()
    {
        /*
         유니티 오브젝트는 GameObject라는 빈 상자에 설정 자료(컴퍼넌트)를 추가해서 기능을 확장함 
        (예) 오브젝트를 물리적으로 움직이게 하려면 Rigidbody 컴퍼넌트 추가 
        (예) 소리를 내게 하려면 AudioSource 컴퍼넌트 추가 
        (예) 자체 기능을 늘리고 싶다면 스크립트 컴퍼넌트를 추가함 
        컴퍼넌트 접근 방법: GetComponent>() 
        GetComponent는 게임 오브젝트에 대해 'oo 컴포넌트를 주세요'라고 부탁하면 
        해당되는 컴퍼넌트(기능)을 돌려주는 메서드 
        (예) AudioSource 컴퍼넌트를 원하면 GetComponent <AudioSour ce>() 
        (예) Text 컴퍼넌트를 원하면 GetComponent<Text() 
        (예) 직접 만든 스크립트도 컨퍼넌트의 일종이므로 GetComponent 메서드를 사용해서 구할 수 있음
         */

        // 화살과 플레이어가 충돌했을 때 image 오브젝트의 fillAmount를 줄여
        //hp 게이지를 표시하는 비율을 10%씩 낮춤

        gHpGuage.GetComponent<Image>().fillAmount -= 0.3f;

        
        
    }

    public void GameResetButtonDown()           //게임 재시작 버튼
    {
        gHpGuage.GetComponent<Image>().fillAmount = 1.0f;       // 체력게이지를 1로 만듬
    }

    public void GameMenuButtonDown()                 //게임 메뉴 버튼
    {
        SceneManager.LoadScene("StartScene");       //메인메뉴로 이동
    }

}
