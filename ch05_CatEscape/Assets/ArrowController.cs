//화살이 위에서 아래로 1초에 하나씩 떨어지는 기능 --> transform.Translate
// 화살이 게임화면 밖으로 나오면 화살 오브젝트를 소멸시키는 기능 --> Destroy()

using UnityEngine;
using UnityEngine.UI;
public class ArrowController : MonoBehaviour
{

    // 멤버 변수 선언
    GameObject gPlayer = null;  // Player Object 를 저장한 GameObject 변수 초깃값은 null
    GameObject gHpGauge = null; // HP Gauge Image Object를 저장할 변수

    Vector2 vArrowCirclePoint = Vector2.zero;    //화살을 둘러싼 원의 중심 좌표
    Vector2 vPlayerCirclePoint = Vector2.zero;   // 플레이어를 둘러싼 원의 중심
    Vector2 vArrowPlayerDir = Vector2.zero;      // 화살에서 플레이어까지의 벡터값

    float fArrowRadius = 0.5f;          //화살의 반지름
    float fPlayerRadius = 1.0f;         //플레이어 반지름
    float fArrowPlayerDistance = 0.0f;   // 화살의 중심부터 플레이어를 둘러싼원의 중심까지의 거리                            



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        씬 안에 오브젝트를 찾는 매서드 : Find
        Find 메서드는 오브젝트 이름을 인수로 전달하고 인수 이름이 씬에 존재하면 해당 오브젝트를 반환
        플레이어의 좌표를 구하기 위해서 플레이어를 검색하여 오브젝트 변수에 저장
        각 오브젝트 상자에 대응하는 오브젝트를 씬 안에

         */
        gPlayer = GameObject.Find("player"); 
        gHpGauge = GameObject.Find("hpGauge"); // 게임 오브젝트 중에 hp게이지를 찾는 Find 함수 이용
    }

    // Update is called once per frame
    void Update()
    {
        /*
         화살이위에서아래로 1초에하나씩떨이지는 기능 --> transform.Translate
        Translate 메서드 : 오브젝트를 현재좌표에서 인수 값만큼 이동시키는 메서드
        Y좌표에 -0.1 f를 지정하면 오브젝트를 조금씩위에서 아래로떨어진다
        프레임마다 등속으로 낙하
         */
        if (gHpGauge.GetComponent<Image>().fillAmount > 0)
        {
            transform.Translate(0, -0.1f, 0);
        }
        
        


        /*
         화살이 게임화면 박으로 나오면 화살 오브젝트를 소멸시키는 기능 --> Destroy
         화면밖으로 나온 화살 소멸시키기
        화살을 내버려두면 화면 밖으로 나가고 , 눈에 보이지는 않지만 계속떨어짐
        화살이 계속떨어지면 메모리낭비 
        Destroy메서드 : 매개변수로 전달한 오브젝트 삭제 
        매개변수로 자신을 가르키는 GameObject 변수를 전달하므로 화살이
        화면 밖으로 나갈때 자신을 소멸시킴
         */

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        /*
         충돌 판정 ㅣ 원의 중심 좌표와  반경을 사용한 충돌 판정 알고리즘
        화살의 중심부터 플레이어를 둘러싼 원의 중심 까지 거리를 피타고라스 정리를 이용하여 구한다 
        두원의 중심간의거리 fArrowPlayerDistance > fArrowRadius + fPlayerRadius 충돌하지않움
        두원의 중심간의거리 fArrowPlayerDistance < fArrowRadius + fPlayerRadius 충돌
         */

        vArrowCirclePoint = transform.position;

        vPlayerCirclePoint = gPlayer.transform.position;

        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;

        /*
         두 벡터 간의 길이를 구하는 메서드 magnitude
         메서드 정의 : publicfloat Magnitude(vector3 vector)
         벡터는 크기와 방향을 갖기 때문에 시작점과 종점으로 구성되며 둘 사이의 거리가 곧 벡터의 크기가 된다 
         일반적으로 시작점을 베터의 꼬리 종점을 벡터의 머리라 부름
         벡터의 시작점과 종점의 위치에 관계없이, 두벡터의 크기와 방향이 같다면 서로 같은 벡터로 취급한다
         화살의 중심부터 플레이어를 둘러싼 원의 중심 까지의 거리

         
         */

        fArrowPlayerDistance = vArrowPlayerDir.magnitude;


        /*
         
         플레이어가 화살에 맞았는지 감지 화살과 플레이어의 충돌 판정]
         원의 중심 좌표와 반경을 사용해 충돌판정
         충돌 두원의 중심 간 거리 가 반지름의 합보다 크면 충돌하지 않음
         충돌 두원의 중심 간 거리 가 반지름의 합보다 작으면 충돌
         충돌 하면 화살 오브젝트 소멸
         
         */
        if (fArrowPlayerDistance < fArrowRadius + fPlayerRadius)
        {
            /*
             * 플레이어가 화살에 맞으면 화살 컨트롤로에서 감독 스크립트(GameDirector)의 f_Decreasetp() 메서드를 호출 
             * 즉, ArrowController에서 GameDirector 오브젝트에 있는 Decreaselp() 메서드를 호출하기 때문에
             * Find 메서드를 찾아서 GameDirector 오브젝트를 찾는다
             */
            GameObject director = GameObject.Find("GameDirector");
            // GetComponent 메서드를 사용해 GameDirector 오브젝트의 GameDirector 스크립트를 구하고,
            // f_DeceaseHp 메서드를 구출하여 , 감독 스크립트에 플레이어와 화살이 충돌했다고 전달
            director.GetComponent<GameDirector>().f_DeceaseHp();


            Destroy(gameObject);
        }

        

    }
}
