/*
 화살 오브젝트를 1초에 한 개씩 생성하는 알고리즘
Update 메서드는 프레임마다 실행되고 앞프레임과 현재 플레임 사이의 시간 차는 Time.deltaTime에 대입
프레임과 프레임 사이의 시간 차이를 대나무 통(delta)에 모으고 1초이상이되면 대나무 통을 비움
대나무 통을 비우는 시점인 1초에 한 번씩 화살 생성
iunstantiate 메서드
    게임을 실행하는 도중에 게임오브젝트를 생성할 수 있음
    화살 프레임을 이용하여 화살 인스턴스를 생성하는 메서드
Random Ranges 메서드 : 랜덤 값을 쉽게 생성할 수 있는 방법
    Random 클래스는 흔히 요구되는 다양한 타입의 랜덤값을 쉽게 생성할 수 있는 방법을 제공
    사용자가 제공한 최솟값과 최댓값 사이의 임의 숫자 제공
        첫 번째 매개변수보다 크거나 같고 두번째 매개변수보다 작은 버위에서 무작위 수를 랜덤하게 반환

 */

using UnityEngine;
using UnityEngine.UI;

public class ArrowGenerator : MonoBehaviour
{
    /*
     제너레이터 스크립트에 프리팹 전달방법
        arrowprefab 변수에 프리팹 실체를 대입하기 위해서 public 접근 수식자
        멤버 변수 선언시 public 으로 선언하면 inspector 창에서 prefab 설계도를 대입할 수 잇도록 보임
        화살 대량 생산을 위해서 양산기계에 넘겨 줄 prefab 설계도를 넘겨 주어야 함
     */
    public GameObject gArrowfrepab = null;  // 화살 prefab 넣을 빈오브젝트 상자 선언

    GameObject gArrowinstance = null;       // 화살 인스턴스 저장 변수
    GameObject gHpGauge = null;             // HP Gauge Image Object를 저장할 변수

    float fArrowCreateSpan = 0.3f;          // 화살 생성 변수 화살을 1초마다 생성 변수

    float fDeltaTime = 0.0f;                //앞프레임과 현재 프레임 사이의 시간 차이를 저장하는 변수

    int nArrowPositionRange = 0;            // 화살의 x좌표 Range 저장 변수 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gHpGauge = GameObject.Find("hpGauge"); // 게임 오브젝트 중에 hp게이지를 찾는 Find 함수 이용
    }

    // Update is called once per frame
    void Update()
    {   /*
          Update 메서드는 프레임마다 실행되고 앞프레임과 현재 프레임 사이의 시간 차이는 Time.deltatime에 대입됨
          Time.deltaTime 은 한 프레임당 실행하는 시간을 뜻하는데 값을 float 형태로 변환하고 단위는 초를 사용
          즉 프레임과 프레임 사이의 시간차이를 fDeltaTime에 누적
         */
        fDeltaTime += Time.deltaTime;

        // 화살을 1초마다 한개씩 생성
        // 프레임당 누적시간에 1초가넘으면 화살 생산
        if(fDeltaTime > fArrowCreateSpan)
        {
            fDeltaTime = 0.0f;  // 프레임과 프레임 사이의  시간 차이 누적 변수 초기화


            /*
             instantiate 메서드 : 화살 프리팹을 이용하여 화살 인스턴스를 생성하는 매서드 
                매개변수로 프리팹을 전달하면 반환값으로 프리팹 인스턴스를 돌려준다
                instantiate 메서드를 사용하면 게임을 실행하는 도중에 게임오브젝트를 생성할수있음
                RPG 게임이라면 수많은 아이템 캐릭터 배경 들  모든것들을 어떻게 미리 만들어 놓을 수 잇을까
                그러므로 게임 오브젝트의 복제본을 생성
                Instantiate (Game0bject original, Vector3 position. Quaternion rotation) 
                 GameObject original 생성하고자 하는 게임오브젝트명
                Vector3 position Vector3으로 생성될 위치를 설정함
                 Quaternion rotation : 생성될 게임오브젝트의 회전값을 지정
             */
            if (gHpGauge.GetComponent<Image>().fillAmount > 0)
            {
                gArrowinstance = Instantiate(gArrowfrepab);
            }
                
            /*
             Random 클래스는 흔히 요구되는 다양한 타입의 랜덤 값을 쉽게 생성할 수 있는 방법을 제공
             Ranks Rance 메서드 사용자가 제공한 뱃값과 댓값 사이의 임의의 숫자를 제공함 
             제공된 최솟값과 최대값이 정수인지 실수인지에 따라 정수 또는 실수를 반환
               첫 번째 매개변수보다 크거나 같고, 두 번째 매개변수보다 작은 범위에서 무작위 수를 정수로 반환 
             화살의 X 화표는 -6 ~ 6 사이에 불규칙하게 위치
             */
            nArrowPositionRange = Random.Range(-7, 7);

            gArrowinstance.transform.position = new Vector3(nArrowPositionRange, 7, 0);
        }

    }
}
