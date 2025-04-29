/*
 사용자가 입력한 대로 플레이어가 좌우로 움직이거나 뛰어오르는 기능
키보드에 있는 좌우 화살표키 를 누르면 이동하고 스페이스바를 누르면 점프하는 컨트롤러 스크립트를 작성
1 스페이스바를 누르면 점프
2 플레이어를 좌우로 움직이기
 */


using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Cat 오브젝트의 Rigidbody2D 컴포넌트를 갖는 멤버변수(_m)
    Rigidbody2D m_rigidbody = null;

    Animator m_animatorCat = null;
     
    // 플레이어에 가할 힘 값을 저장할 변수
    float fJumpForce = 680.0f;

    //플레이어 좌우로 움직이는 가속도
    float fWalkForce = 25.0f;

    //플레이어의 이동속도가 지정한 최고 속도
    float fmaxWalkSpeed = 2.0f;

    // 플레이어 좌우 움직임 키 값 : 우측 화살표 키 -> 1 좌측 화살표키 -> -1 움직이지 않을 때 -> 0
    int nLeftRightKeyValue = 0;

    // 플레이어 좌우 움직이는 속도
    float fPlayerMoveSpeed = 0;

    float fMinPositionX = -2.5f;

    float fMaxPositionX = 2.5f;

    float fPositionX = 0.0f;

    int nLife = 3;

    public static int nScore = 0;

    public TMP_Text textLife;

    public TMP_Text textScore;



    GameObject n_gPlayer = null;

    void Start()
    {
        /*
         디바이스 성능에 따른 실행 결과의 차이 없애기
        어떤 성능의 컴퓨터에서 동작해도 같은 속도로 움직이도록 하는 처리
        스마트폰은 60 pc는 300이 될 수 있는 디바이스 성능에 따라 게임 동작에 영향을 미칠 수 있음
        프레임레이트를 60으로 고정
         
         */
        Application.targetFrameRate = 60;

        /*
          특정 오브젝트의 컴포넌트에 접근하기 위해서는 GetComponent 를 사용
            Rigidbody2D 컴포넌트를 갖는 매서드를 사용하기 때문에 Start 매서드에서 GetComponent 매서드를 사용해서 
            Rigidbody2D 컴퍼넌트를 구해 멤버변수에 저장
            
         */
        m_rigidbody = GetComponent<Rigidbody2D>();

        // GetComponent 메서드를 사용해 animator 컴퍼넌트를 구함
        m_animatorCat = GetComponent<Animator>();

        n_gPlayer = GameObject.Find("cat");
        UpdateLife();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        /*
            AddForce 매서드  오브젝트에 일정한 힘을 주어 이동시키는 것
            SpaceBArkey 가 눌리면 AddForce 메서드를 사용해 위쪽 방향으로 가도록 플레이어의 힘을 가한다
            즉 플레이어에 힘을 가하려면 Rigidbody2D컴포넌트 가 가진 AddForce 메서드를 사용한다
         */
        //if (m_rigidbody.linearVelocity.y == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        this.m_rigidbody.AddForce(transform.up * this.fJumpForce);
        //    }
        //}

        
        if (Input.GetKeyDown(KeyCode.Space) && m_rigidbody.linearVelocity.y == 0)
        {
            m_animatorCat.SetTrigger("JumpTrigger");

            this.m_rigidbody.AddForce(transform.up * this.fJumpForce);
            
        }
        
        // 플레이어 좌 우 이동
        // 플레이어 좌우 움직임 키 값: 우측 화살표 키-> 1 좌측 화살표키 -> -1

        if (Input.GetKey(KeyCode.RightArrow))
        {
            nLeftRightKeyValue = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nLeftRightKeyValue = -1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            nLeftRightKeyValue = 0;
        }

        /* 
        플레이어의 스피드 제한 
        프레임마다 AddForce 메서드를 사용해 힘을 가하면 플레이어가 계속 가속이 되는 문제점 발생 
        그래서 플레이어의 이동 속도가 지정한 속도(MaxWalkSpeed) 보다 빠르면 힘을 가하는 것을 멈추고 
        왼쪽화살표, 오른쪽화살표 Key가 눌리면 AddForce 메서드를 사용해 좌, 우 방향으로 가도록 플레이어에 힘을 가한다
        즉, 플레이어에 힘을 가하려면 Rigidbody20 컴포넌트가 가진 Addforce 메서드를 사용한다.
        - Velocity 같은 힘을 가해도 동일한 속도로 달릴 수 있도록 물리엔진이 자동으로 계산 
        AddForce의 경우 순간적으로 튀어 오르고 점차 속도가 줄어들면서 떨어지는 점프에 적합
        linearvelocity는 동일한 속도를 달리는 러너게임 캐릭터 이에 적합
         */
        //m_rigidbody.AddForce(transform.right * fWalkForce *nLeftRightKeyValue );

        fPlayerMoveSpeed = Mathf.Abs(m_rigidbody.linearVelocity.x);

        if(fPlayerMoveSpeed < fmaxWalkSpeed)
        {
            m_rigidbody.AddForce(transform.right * fWalkForce * nLeftRightKeyValue);
        }

        /*
         움직이는 방향에 따라 플레이어 이미지를 반전
        플레이어가 우로 움직이면 스트라이트도 우로 향하고
        좌로움직이면 좌로 움직이도록 이미지를 반전 시키려면
        스프라이트의 x축 방향 배율을 -1배함
        스프라이트의 배율을 바꾸려면 transform 컴퍼넌트의 localscale 변수 값을 변경
        우측 화살표는 1배 좌측 화살표는 -1배
         */
        if(nLeftRightKeyValue != 0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1, 1);
        }

        /*
          애니메이션 재생 속도가 플레이어 이동 속도에 비례하도록 수정
        플레이어 이동 속도가 0이면 애니메이션 이동속도도 0으로 정지하고 
        플레이어이동속도가 빨라질수록 애니메이션 속도가 빨라짐
        애니메이션 재생 속도를 바꾸려면 컴퍼넌트의 speed 변수값으로 조정
         */

        if (m_rigidbody.linearVelocity.y == 0)
        {
            m_animatorCat.speed = fPlayerMoveSpeed / 2.0f;
        }
        else
        {
            m_animatorCat.speed = 1.0f;
        }

        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);


        if(transform.position.y < -7.0f)
        {
            transform.position = new Vector3(-1.5f, -0.8f, 0);
            nLife--;
            UpdateLife();
        }
        
        if(nLife == 0)
        {
            SceneManager.LoadScene("OverScene");
        }
        

    }

    //플레이어가 깃발에 닿으면 게임이 종료됨
    // 이 경우게임 씬에서 클리어 씬으로 전환되어야 함
    // 플레이어가 깃발에 닿았는지는 OnTriggerEnter2D 메서드로 감지함
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flag"))
        {
            Debug.Log("골");

            // 로드 씬
            SceneManager.LoadScene("ClearScene");
        }

        if (other.CompareTag("Circle"))
        {
            Destroy(other.gameObject); // Circle 오브젝트 삭제
            nScore += 1; // 점수 1점 추가
            UpdateScore();
        }


    }

    private void UpdateLife()
    {
        textLife.text = "Life: " + nLife.ToString();
    }

    private void UpdateScore()
    {
        textScore.text = "Score: " + nScore.ToString();
    }

    
}
