//�÷��̾ ȭ�鿡 ������ �ʴ� �� ���ʱ��� �̵��ϸ�, ī�޶� ���� �� �� ���� ������ �߻�
// �������� �ذ��ϱ� ���ؼ���, ī�޶� �÷��̾ ����ٴϸ� ������ �� �ֵ��� ��ũ��Ʈ �ۼ�

using UnityEngine;


public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //�÷��̾� ������Ʈ�� ã�� ���ؼ� ��� ���� ����
    GameObject n_gPlayer = null;

    // �÷��̾ ���� �̵��� ������ ī�޶� ����ٴϵ��� �÷��̾� Y��ǥ ���� ����
    Vector3 vPlayerPosition = Vector3.zero;

    void Start()
    {
        // �÷����� ������Ʈ�� ã�Ƽ� ��� ������ ����
        n_gPlayer = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ ���� �̵��� ������ ī�޶� ����ٴϵ��� �����Ӹ��� �÷��̾� ��ǥ�� ���ؼ� ����(vPlayerPosition)
        vPlayerPosition = n_gPlayer.transform.position;

        //�÷��̾� �̵��� ī�޶� ���󰡴� ���� Y�� ����*�� ��ȭ�̹Ƿ� ��� ���� Y��ǥ���� �ݿ��Ѵ�
        // x��ǥ�� z��ǥ�� ������ �����Ƿ� ī�޶��� ���� ��ǥ�� �״�� ���
        transform.position = new Vector3(transform.position.x, vPlayerPosition.y, transform.position.z);
    }
}
