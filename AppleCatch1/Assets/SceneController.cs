using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void EasyMode()
    {
        SceneManager.LoadScene("EasyGameScene");
    }

    public void NormalMode()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HardMode()
    {
        SceneManager.LoadScene("HardGameScene");
    }

    public void Guide()
    {
        SceneManager.LoadScene("GuideScene");
    }



    public void ExitButton()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // �����Ϳ����� Play ����
    #else
        Application.Quit(); // ����� ���ӿ����� ����
    #endif
    }
}
