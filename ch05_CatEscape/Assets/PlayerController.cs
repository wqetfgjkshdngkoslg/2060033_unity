using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    // ��� ���� ����
    float fMaxPositionX = 5.0f; // �÷��̾� �� , �� �̵��� ����â�� ����� �ʵ��� Vector  �ִ� ���� ����
    float fMinPositionX = -5.0f; // �÷��̾� ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ּڰ� ���� ����
    float fPositionX = 0.0f;    // �÷��̾ ��, �� �̵��� �� �ִ� X��ǥ ���� ����

    GameObject gLButton = null; // ������ ��ư�� button Object�� ������ ����
    GameObject gRButton = null; // ���� ��ư�� button Object�� ������ ����
    GameObject gHpGauge = null; // HP Gauge Image Object�� ������ ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
     Start �޼���
    �̸� ���ǵ� Ư�� �̺�Ʈ �Լ��ν�, �� Ư�� �Լ����� C#������ �Լ��� �޼ҵ�����
    MonoBehaviour Ŭ������ �ʱ�ȭ �ɋ� ȣ��Ǵ� �Լ�
    �� start()�޼���½�ũ��Ʈ�ν��Ͻ���Ȱ��ȭ�Ȱ�쿡��ù��°�����Ӿ�����Ʈ����ȣ���ϹǷ� �ѹ��� ����
    �����¿����Եȸ�������Ʈ������Update�� ������ȣ��ȸ�罺ũ��Ʈ������start�Լ���ȣ��
    ���󼭰����÷��̵��߿�����Ʈ���ν��Ͻ�ȭ�Ҷ��½����������
     */
    void Start()
    {
        /*
         ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
        � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
        ����Ʈ���� 60, PC�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ�� ����
        �����ӷ���Ʈ 60���� ����
         */
        Application.targetFrameRate = 60;
        gHpGauge = GameObject.Find("hpGauge"); // ���� ������Ʈ �߿� hp�������� ã�� Find �Լ� �̿�
        gLButton = GameObject.Find("LButton"); // ���� ������Ʈ �߿� ���� ��ư�� ã�� Find �Լ� �̿�
        gRButton = GameObject.Find("RButton"); // ���� ������Ʈ �߿� ������ ��ư�� ã�� Find �Լ� �̿�
    }

    // Update is called once per frame
    void Update()
    {
        /*
         Ű�����ȴ��������ϱ����ؼ���InputŬ������GetKeyDown�޼��带 �����
        �̸޼���¸Ű�������������Ű�������¼���true���ѹ�����ȯ
        GetKeyDown�޼�������ݱ�������ϴ�GetMouseButtonDown�޼���ͺ���ϹǷ� ���������Ҽ�������
        Ű�� ������ ���� : GetKeyDown()
        Ű�� ������ �Ҵ� ���� : GetKey()
        Ű�� �� ���� : GetKeyUp()
         */
        if (gHpGauge.GetComponent<Image>().fillAmount > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.5f, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.5f, 0, 0);
            }

            gLButton.GetComponent<Button>().interactable = true; // ���� ��ư�� ������Ʈ���� ��ư����� Ȱ��ȭ
            gRButton.GetComponent<Button>().interactable = true; // ������ ��ư�� ������Ʈ���� ��ư����� Ȱ��ȭ

        }
        else
        {

            gLButton.GetComponent<Button>().interactable = false; // ���� ��ư�� ������Ʈ���� ��ư����� Ȱ��ȭ ����� ���� ���
            gRButton.GetComponent<Button>().interactable = false; // ������ ��ư�� ������Ʈ���� ��ư����� Ȱ��ȭ ����� ���� ���
        }
        /*
        Mathf.Clamp(value, min, max) �޼���
            Ư������ ��� ������ ���ѽ�Ű���� �� �� ����ϴ� �޼���
            value ���� ���� : min < value < max
            �ּ�/ �ִ� ���� �����Ͽ� ������ ���� �̿ܿ� ���� ���� �ʵ��� �� �� ���
            �÷��̾ ������ �� �ִ� �ּ�/ �ִ� �������� �����Ͽ� �� ������ ����� �ʵ��� �Ѵ�.
        */

        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);



    }

 
    public void LButtonDown()
    {
        transform.Translate(-1.0f, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(1.0f, 0, 0);
    }

    

}
