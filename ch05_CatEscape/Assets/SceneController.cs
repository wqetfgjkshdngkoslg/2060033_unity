using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() // ���� ���Ḧ ���� �Լ� ����
    {
        Application.Quit(); // ���ø����̼� ����
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameExit()
    {
#if UNITY_EDITOR                                         // #if UNITY_EDITOR�� ����Ƽ �����Ϳ��� ������ ���� �ڵ尡 �����ϵ��� �ϴ� 
        //��ó���� ���ù�
        UnityEditor.EditorApplication.isPlaying = false; // ����Ƽ �����Ϳ��� ���� ���� ��� ���� ����
#else                                                    // ����Ƽ �����Ͱ� �ƴ� ���
        Application.Quit();                              // ���� ����
#endif

    }
}
