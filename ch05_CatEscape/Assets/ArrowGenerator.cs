/*
 ȭ�� ������Ʈ�� 1�ʿ� �� ���� �����ϴ� �˰���
Update �޼���� �����Ӹ��� ����ǰ� �������Ӱ� ���� �÷��� ������ �ð� ���� Time.deltaTime�� ����
�����Ӱ� ������ ������ �ð� ���̸� �볪�� ��(delta)�� ������ 1���̻��̵Ǹ� �볪�� ���� ���
�볪�� ���� ���� ������ 1�ʿ� �� ���� ȭ�� ����
iunstantiate �޼���
    ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� ������ �� ����
    ȭ�� �������� �̿��Ͽ� ȭ�� �ν��Ͻ��� �����ϴ� �޼���
Random Ranges �޼��� : ���� ���� ���� ������ �� �ִ� ���
    Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� �������� ���� ������ �� �ִ� ����� ����
    ����ڰ� ������ �ּڰ��� �ִ� ������ ���� ���� ����
        ù ��° �Ű��������� ũ�ų� ���� �ι�° �Ű��������� ���� �������� ������ ���� �����ϰ� ��ȯ

 */

using UnityEngine;
using UnityEngine.UI;

public class ArrowGenerator : MonoBehaviour
{
    /*
     ���ʷ����� ��ũ��Ʈ�� ������ ���޹��
        arrowprefab ������ ������ ��ü�� �����ϱ� ���ؼ� public ���� ������
        ��� ���� ����� public ���� �����ϸ� inspector â���� prefab ���赵�� ������ �� �յ��� ����
        ȭ�� �뷮 ������ ���ؼ� ����迡 �Ѱ� �� prefab ���赵�� �Ѱ� �־�� ��
     */
    public GameObject gArrowfrepab = null;  // ȭ�� prefab ���� �������Ʈ ���� ����

    GameObject gArrowinstance = null;       // ȭ�� �ν��Ͻ� ���� ����
    GameObject gHpGauge = null;             // HP Gauge Image Object�� ������ ����

    float fArrowCreateSpan = 0.3f;          // ȭ�� ���� ���� ȭ���� 1�ʸ��� ���� ����

    float fDeltaTime = 0.0f;                //�������Ӱ� ���� ������ ������ �ð� ���̸� �����ϴ� ����

    int nArrowPositionRange = 0;            // ȭ���� x��ǥ Range ���� ���� 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gHpGauge = GameObject.Find("hpGauge"); // ���� ������Ʈ �߿� hp�������� ã�� Find �Լ� �̿�
    }

    // Update is called once per frame
    void Update()
    {   /*
          Update �޼���� �����Ӹ��� ����ǰ� �������Ӱ� ���� ������ ������ �ð� ���̴� Time.deltatime�� ���Ե�
          Time.deltaTime �� �� �����Ӵ� �����ϴ� �ð��� ���ϴµ� ���� float ���·� ��ȯ�ϰ� ������ �ʸ� ���
          �� �����Ӱ� ������ ������ �ð����̸� fDeltaTime�� ����
         */
        fDeltaTime += Time.deltaTime;

        // ȭ���� 1�ʸ��� �Ѱ��� ����
        // �����Ӵ� �����ð��� 1�ʰ������� ȭ�� ����
        if(fDeltaTime > fArrowCreateSpan)
        {
            fDeltaTime = 0.0f;  // �����Ӱ� ������ ������  �ð� ���� ���� ���� �ʱ�ȭ


            /*
             instantiate �޼��� : ȭ�� �������� �̿��Ͽ� ȭ�� �ν��Ͻ��� �����ϴ� �ż��� 
                �Ű������� �������� �����ϸ� ��ȯ������ ������ �ν��Ͻ��� �����ش�
                instantiate �޼��带 ����ϸ� ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� �����Ҽ�����
                RPG �����̶�� ������ ������ ĳ���� ��� ��  ���͵��� ��� �̸� ����� ���� �� ������
                �׷��Ƿ� ���� ������Ʈ�� �������� ����
                Instantiate (Game0bject original, Vector3 position. Quaternion rotation) 
                 GameObject original �����ϰ��� �ϴ� ���ӿ�����Ʈ��
                Vector3 position Vector3���� ������ ��ġ�� ������
                 Quaternion rotation : ������ ���ӿ�����Ʈ�� ȸ������ ����
             */
            if (gHpGauge.GetComponent<Image>().fillAmount > 0)
            {
                gArrowinstance = Instantiate(gArrowfrepab);
            }
                
            /*
             Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� ���� ���� ���� ������ �� �ִ� ����� ����
             Ranks Rance �޼��� ����ڰ� ������ ��� �� ������ ������ ���ڸ� ������ 
             ������ �ּڰ��� �ִ밪�� �������� �Ǽ������� ���� ���� �Ǵ� �Ǽ��� ��ȯ
               ù ��° �Ű��������� ũ�ų� ����, �� ��° �Ű��������� ���� �������� ������ ���� ������ ��ȯ 
             ȭ���� X ȭǥ�� -6 ~ 6 ���̿� �ұ�Ģ�ϰ� ��ġ
             */
            nArrowPositionRange = Random.Range(-7, 7);

            gArrowinstance.transform.position = new Vector3(nArrowPositionRange, 7, 0);
        }

    }
}
