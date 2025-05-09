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

    public void ExitGame() // 게임 종료를 위해 함수 선언
    {
        Application.Quit(); // 어플리케이션 종료
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
#if UNITY_EDITOR                                         // #if UNITY_EDITOR는 유니티 에디터에서 실행할 때만 코드가 동작하도록 하는 
        //전처리기 지시문
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터에서 실행 중인 경우 게임 종료
#else                                                    // 유니티 에디터가 아닌 경우
        Application.Quit();                              // 게임 종료
#endif

    }
}
