/*
 ����ڰ� �Է��� ��� �÷��̾ �¿�� �����̰ų� �پ������ ���
Ű���忡 �ִ� �¿� ȭ��ǥŰ �� ������ �̵��ϰ� �����̽��ٸ� ������ �����ϴ� ��Ʈ�ѷ� ��ũ��Ʈ�� �ۼ�
1 �����̽��ٸ� ������ ����
2 �÷��̾ �¿�� �����̱�
 */


using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Cat ������Ʈ�� Rigidbody2D ������Ʈ�� ���� �������(_m)
    Rigidbody2D m_rigidbody = null;

    Animator m_animatorCat = null;
     
    // �÷��̾ ���� �� ���� ������ ����
    float fJumpForce = 680.0f;

    //�÷��̾� �¿�� �����̴� ���ӵ�
    float fWalkForce = 25.0f;

    //�÷��̾��� �̵��ӵ��� ������ �ְ� �ӵ�
    float fmaxWalkSpeed = 2.0f;

    // �÷��̾� �¿� ������ Ű �� : ���� ȭ��ǥ Ű -> 1 ���� ȭ��ǥŰ -> -1 �������� ���� �� -> 0
    int nLeftRightKeyValue = 0;

    // �÷��̾� �¿� �����̴� �ӵ�
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
         ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
        � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
        ����Ʈ���� 60 pc�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ �� ����
        �����ӷ���Ʈ�� 60���� ����
         
         */
        Application.targetFrameRate = 60;

        /*
          Ư�� ������Ʈ�� ������Ʈ�� �����ϱ� ���ؼ��� GetComponent �� ���
            Rigidbody2D ������Ʈ�� ���� �ż��带 ����ϱ� ������ Start �ż��忡�� GetComponent �ż��带 ����ؼ� 
            Rigidbody2D ���۳�Ʈ�� ���� ��������� ����
            
         */
        m_rigidbody = GetComponent<Rigidbody2D>();

        // GetComponent �޼��带 ����� animator ���۳�Ʈ�� ����
        m_animatorCat = GetComponent<Animator>();

        n_gPlayer = GameObject.Find("cat");
        UpdateLife();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        /*
            AddForce �ż���  ������Ʈ�� ������ ���� �־� �̵���Ű�� ��
            SpaceBArkey �� ������ AddForce �޼��带 ����� ���� �������� ������ �÷��̾��� ���� ���Ѵ�
            �� �÷��̾ ���� ���Ϸ��� Rigidbody2D������Ʈ �� ���� AddForce �޼��带 ����Ѵ�
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
        
        // �÷��̾� �� �� �̵�
        // �÷��̾� �¿� ������ Ű ��: ���� ȭ��ǥ Ű-> 1 ���� ȭ��ǥŰ -> -1

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
        �÷��̾��� ���ǵ� ���� 
        �����Ӹ��� AddForce �޼��带 ����� ���� ���ϸ� �÷��̾ ��� ������ �Ǵ� ������ �߻� 
        �׷��� �÷��̾��� �̵� �ӵ��� ������ �ӵ�(MaxWalkSpeed) ���� ������ ���� ���ϴ� ���� ���߰� 
        ����ȭ��ǥ, ������ȭ��ǥ Key�� ������ AddForce �޼��带 ����� ��, �� �������� ������ �÷��̾ ���� ���Ѵ�
        ��, �÷��̾ ���� ���Ϸ��� Rigidbody20 ������Ʈ�� ���� Addforce �޼��带 ����Ѵ�.
        - Velocity ���� ���� ���ص� ������ �ӵ��� �޸� �� �ֵ��� ���������� �ڵ����� ��� 
        AddForce�� ��� ���������� Ƣ�� ������ ���� �ӵ��� �پ��鼭 �������� ������ ����
        linearvelocity�� ������ �ӵ��� �޸��� ���ʰ��� ĳ���� �̿� ����
         */
        //m_rigidbody.AddForce(transform.right * fWalkForce *nLeftRightKeyValue );

        fPlayerMoveSpeed = Mathf.Abs(m_rigidbody.linearVelocity.x);

        if(fPlayerMoveSpeed < fmaxWalkSpeed)
        {
            m_rigidbody.AddForce(transform.right * fWalkForce * nLeftRightKeyValue);
        }

        /*
         �����̴� ���⿡ ���� �÷��̾� �̹����� ����
        �÷��̾ ��� �����̸� ��Ʈ����Ʈ�� ��� ���ϰ�
        �·ο����̸� �·� �����̵��� �̹����� ���� ��Ű����
        ��������Ʈ�� x�� ���� ������ -1����
        ��������Ʈ�� ������ �ٲٷ��� transform ���۳�Ʈ�� localscale ���� ���� ����
        ���� ȭ��ǥ�� 1�� ���� ȭ��ǥ�� -1��
         */
        if(nLeftRightKeyValue != 0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1, 1);
        }

        /*
          �ִϸ��̼� ��� �ӵ��� �÷��̾� �̵� �ӵ��� ����ϵ��� ����
        �÷��̾� �̵� �ӵ��� 0�̸� �ִϸ��̼� �̵��ӵ��� 0���� �����ϰ� 
        �÷��̾��̵��ӵ��� ���������� �ִϸ��̼� �ӵ��� ������
        �ִϸ��̼� ��� �ӵ��� �ٲٷ��� ���۳�Ʈ�� speed ���������� ����
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

    //�÷��̾ ��߿� ������ ������ �����
    // �� ������ ������ Ŭ���� ������ ��ȯ�Ǿ�� ��
    // �÷��̾ ��߿� ��Ҵ����� OnTriggerEnter2D �޼���� ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flag"))
        {
            Debug.Log("��");

            // �ε� ��
            SceneManager.LoadScene("ClearScene");
        }

        if (other.CompareTag("Circle"))
        {
            Destroy(other.gameObject); // Circle ������Ʈ ����
            nScore += 1; // ���� 1�� �߰�
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
