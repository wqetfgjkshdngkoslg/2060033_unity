// ȭ���� Ŭ���ϸ� Ŭ���� �� ���� ���� �� ���� ��ȯ�ϵ��� ���� 

using UnityEngine;
using UnityEngine.SceneManagement;


// LoadScene �� ����ϱ� ���ؼ��� SceneManagement �� ����Ʈ �ؾ��� 
public class ClearDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         ����Ƽ���� ���� �ε��ϴ°��� SceneManager.LoadScene �޼��带 ���
         �� �̸��̳� ���� ���� �ε����� �Ķ���ͷ� �����Ͽ� Ư������ �ε� �� �� ����
         ���� �ε��ϴ� ���� �ٸ� ���� �Բ� �ε��ϰų� �ε�� ���� ��ε��ϴ� ���� �پ��� �ɼǵ� ������
         �� �̸����� �ε� :SceneManager.LoadScene("MySceneName");
         ���� ���� �ε����� �ε� : SceneManager.LoadScene(1); (�� ��° ���� �ε�)
         ���콺�� Ŭ���� ���� �����ϸ�, SceneManager Ŭ������LoadScene �޼��带 ����� ���� ������ ��ȯ
         */
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }

        

    }
}
