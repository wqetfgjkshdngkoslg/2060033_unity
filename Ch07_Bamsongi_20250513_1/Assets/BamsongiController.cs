//���콺 Ŭ���ϸ� ����̰� �������� ���ư��� �������� 


using UnityEngine;


public class BamsongiController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    
    void Start()
    {
        //����̽� ���ɿ� ���� ������ ���� ���ֱ�
        Application.targetFrameRate = 60;
        /*
         ����̰� ȭ�� �������� ���ư����� +Z �� ������ ���͸� �Ű������� �����ϰ� f_TargetShoot ȣ��
        y�� �������� ���� 200 ���ϴ� ������ ����̰� ���ῡ ������� �߷��� ������ �޾� �������� �����ϴ� ���� ���� ����
         Start �޼��带 ȣ���ϴ� ���۰� ���ÿ� ����̰� ���ư�
         */
        f_TargetShoot(new Vector3(0, 250, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Ű����� �������� ����̿��� ���� ���ϴ� �޼���
    public void f_TargetShoot(Vector3 argDir)
    {
        //�Ű������� ���޵� Vector ������ ���� ���Ѵ�
        GetComponent<Rigidbody>().AddForce(argDir);
    }

    // physics �� ����ϹǷ� ����� ����̰� �浹�ϸ� OnCollisionEnter �� ȣ��Ǿ� �����
    void OnCollisionEnter(Collision other)
    {
        //����̰� ���ῡ ��� ���� ����� �������� ���߹Ƿ� , RigidBody ������Ʈ isKinematic �޼��带 true �� ����
        // isKinematic �޼��带 true �� �����ϸ�, ������Ʈ�� �ۿ��ϴ� ���� �����ϰ� ����̸� ������Ŵ
        // isKinematic �޼��� : �ܺο��� �������� ������ ���� ���������ʴ� ������Ʈ��� �̒�, �߷°� �浹�� ���������ʵ�����
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

    }
}
