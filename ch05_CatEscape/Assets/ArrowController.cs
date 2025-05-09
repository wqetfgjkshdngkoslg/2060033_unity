//ȭ���� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� --> transform.Translate
// ȭ���� ����ȭ�� ������ ������ ȭ�� ������Ʈ�� �Ҹ��Ű�� ��� --> Destroy()

using UnityEngine;
using UnityEngine.UI;
public class ArrowController : MonoBehaviour
{

    // ��� ���� ����
    GameObject gPlayer = null;  // Player Object �� ������ GameObject ���� �ʱ갪�� null
    GameObject gHpGauge = null; // HP Gauge Image Object�� ������ ����

    Vector2 vArrowCirclePoint = Vector2.zero;    //ȭ���� �ѷ��� ���� �߽� ��ǥ
    Vector2 vPlayerCirclePoint = Vector2.zero;   // �÷��̾ �ѷ��� ���� �߽�
    Vector2 vArrowPlayerDir = Vector2.zero;      // ȭ�쿡�� �÷��̾������ ���Ͱ�

    float fArrowRadius = 0.5f;          //ȭ���� ������
    float fPlayerRadius = 1.0f;         //�÷��̾� ������
    float fArrowPlayerDistance = 0.0f;   // ȭ���� �߽ɺ��� �÷��̾ �ѷ��ѿ��� �߽ɱ����� �Ÿ�                            



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        �� �ȿ� ������Ʈ�� ã�� �ż��� : Find
        Find �޼���� ������Ʈ �̸��� �μ��� �����ϰ� �μ� �̸��� ���� �����ϸ� �ش� ������Ʈ�� ��ȯ
        �÷��̾��� ��ǥ�� ���ϱ� ���ؼ� �÷��̾ �˻��Ͽ� ������Ʈ ������ ����
        �� ������Ʈ ���ڿ� �����ϴ� ������Ʈ�� �� �ȿ�

         */
        gPlayer = GameObject.Find("player"); 
        gHpGauge = GameObject.Find("hpGauge"); // ���� ������Ʈ �߿� hp�������� ã�� Find �Լ� �̿�
    }

    // Update is called once per frame
    void Update()
    {
        /*
         ȭ�����������Ʒ��� 1�ʿ��ϳ����������� ��� --> transform.Translate
        Translate �޼��� : ������Ʈ�� ������ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
        Y��ǥ�� -0.1 f�� �����ϸ� ������Ʈ�� ���ݾ������� �Ʒ��ζ�������
        �����Ӹ��� ������� ����
         */
        if (gHpGauge.GetComponent<Image>().fillAmount > 0)
        {
            transform.Translate(0, -0.1f, 0);
        }
        
        


        /*
         ȭ���� ����ȭ�� ������ ������ ȭ�� ������Ʈ�� �Ҹ��Ű�� ��� --> Destroy
         ȭ������� ���� ȭ�� �Ҹ��Ű��
        ȭ���� �������θ� ȭ�� ������ ������ , ���� �������� ������ ��Ӷ�����
        ȭ���� ��Ӷ������� �޸𸮳��� 
        Destroy�޼��� : �Ű������� ������ ������Ʈ ���� 
        �Ű������� �ڽ��� ����Ű�� GameObject ������ �����ϹǷ� ȭ����
        ȭ�� ������ ������ �ڽ��� �Ҹ��Ŵ
         */

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        /*
         �浹 ���� �� ���� �߽� ��ǥ��  �ݰ��� ����� �浹 ���� �˰���
        ȭ���� �߽ɺ��� �÷��̾ �ѷ��� ���� �߽� ���� �Ÿ��� ��Ÿ��� ������ �̿��Ͽ� ���Ѵ� 
        �ο��� �߽ɰ��ǰŸ� fArrowPlayerDistance > fArrowRadius + fPlayerRadius �浹�����ʿ�
        �ο��� �߽ɰ��ǰŸ� fArrowPlayerDistance < fArrowRadius + fPlayerRadius �浹
         */

        vArrowCirclePoint = transform.position;

        vPlayerCirclePoint = gPlayer.transform.position;

        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;

        /*
         �� ���� ���� ���̸� ���ϴ� �޼��� magnitude
         �޼��� ���� : publicfloat Magnitude(vector3 vector)
         ���ʹ� ũ��� ������ ���� ������ �������� �������� �����Ǹ� �� ������ �Ÿ��� �� ������ ũ�Ⱑ �ȴ� 
         �Ϲ������� �������� ������ ���� ������ ������ �Ӹ��� �θ�
         ������ �������� ������ ��ġ�� �������, �κ����� ũ��� ������ ���ٸ� ���� ���� ���ͷ� ����Ѵ�
         ȭ���� �߽ɺ��� �÷��̾ �ѷ��� ���� �߽� ������ �Ÿ�

         
         */

        fArrowPlayerDistance = vArrowPlayerDir.magnitude;


        /*
         
         �÷��̾ ȭ�쿡 �¾Ҵ��� ���� ȭ��� �÷��̾��� �浹 ����]
         ���� �߽� ��ǥ�� �ݰ��� ����� �浹����
         �浹 �ο��� �߽� �� �Ÿ� �� �������� �պ��� ũ�� �浹���� ����
         �浹 �ο��� �߽� �� �Ÿ� �� �������� �պ��� ������ �浹
         �浹 �ϸ� ȭ�� ������Ʈ �Ҹ�
         
         */
        if (fArrowPlayerDistance < fArrowRadius + fPlayerRadius)
        {
            /*
             * �÷��̾ ȭ�쿡 ������ ȭ�� ��Ʈ�ѷο��� ���� ��ũ��Ʈ(GameDirector)�� f_Decreasetp() �޼��带 ȣ�� 
             * ��, ArrowController���� GameDirector ������Ʈ�� �ִ� Decreaselp() �޼��带 ȣ���ϱ� ������
             * Find �޼��带 ã�Ƽ� GameDirector ������Ʈ�� ã�´�
             */
            GameObject director = GameObject.Find("GameDirector");
            // GetComponent �޼��带 ����� GameDirector ������Ʈ�� GameDirector ��ũ��Ʈ�� ���ϰ�,
            // f_DeceaseHp �޼��带 �����Ͽ� , ���� ��ũ��Ʈ�� �÷��̾�� ȭ���� �浹�ߴٰ� ����
            director.GetComponent<GameDirector>().f_DeceaseHp();


            Destroy(gameObject);
        }

        

    }
}
