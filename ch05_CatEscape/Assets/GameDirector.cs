using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    GameObject gHpGuage = null;         // HP Gauge Image Object�� ������ ����
    GameObject gGameOver = null;        //  ���ӿ��� ����
    GameObject gGameReset = null;       //  ���� ����� ����
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
        if (gHpGuage.GetComponent<Image>().fillAmount > 0.0f)   // hp�������� 0���� Ŭ��
        {
            gGameOver.SetActive(false);             // ���ӿ��� �ؽ�Ʈ ��Ȱ��ȭ
            gGameReset.SetActive(false);            // ���� ��ư ��Ȱ��ȭ
            gMenu.SetActive(false);                 // �޴���ư �����
            
        }
        else 
        {
            gMenu.SetActive(true);                 // �޴� ��ư Ȱ��ȭ
            gGameOver.SetActive(true);              // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
            gGameReset.SetActive(true);             // ���� ��ư Ȱ��ȭ
        }


    }

    public void f_DeceaseHp()
    {
        /*
         ����Ƽ ������Ʈ�� GameObject��� �� ���ڿ� ���� �ڷ�(���۳�Ʈ)�� �߰��ؼ� ����� Ȯ���� 
        (��) ������Ʈ�� ���������� �����̰� �Ϸ��� Rigidbody ���۳�Ʈ �߰� 
        (��) �Ҹ��� ���� �Ϸ��� AudioSource ���۳�Ʈ �߰� 
        (��) ��ü ����� �ø��� �ʹٸ� ��ũ��Ʈ ���۳�Ʈ�� �߰��� 
        ���۳�Ʈ ���� ���: GetComponent>() 
        GetComponent�� ���� ������Ʈ�� ���� 'oo ������Ʈ�� �ּ���'��� ��Ź�ϸ� 
        �ش�Ǵ� ���۳�Ʈ(���)�� �����ִ� �޼��� 
        (��) AudioSource ���۳�Ʈ�� ���ϸ� GetComponent <AudioSour ce>() 
        (��) Text ���۳�Ʈ�� ���ϸ� GetComponent<Text() 
        (��) ���� ���� ��ũ��Ʈ�� ���۳�Ʈ�� �����̹Ƿ� GetComponent �޼��带 ����ؼ� ���� �� ����
         */

        // ȭ��� �÷��̾ �浹���� �� image ������Ʈ�� fillAmount�� �ٿ�
        //hp �������� ǥ���ϴ� ������ 10%�� ����

        gHpGuage.GetComponent<Image>().fillAmount -= 0.3f;

        
        
    }

    public void GameResetButtonDown()           //���� ����� ��ư
    {
        gHpGuage.GetComponent<Image>().fillAmount = 1.0f;       // ü�°������� 1�� ����
    }

    public void GameMenuButtonDown()                 //���� �޴� ��ư
    {
        SceneManager.LoadScene("StartScene");       //���θ޴��� �̵�
    }

}
