using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardGameDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    GameObject gTimerText;
    GameObject gScoreText;
    float fTime = 60.0f;
    int nScore = 0;

    HardItemGenerator itemGenerator;

    void Start()
    {
        this.gTimerText = GameObject.Find("Time");
        this.gScoreText = GameObject.Find("Score");

        itemGenerator = GameObject.Find("ItemGenerator").GetComponent<HardItemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.fTime -= Time.deltaTime;

        if (fTime <= 15)
        {
            itemGenerator.SetParameters(0.1f, -0.2f, 9);
        }
        else if (fTime <= 30)
        {
            itemGenerator.SetParameters(0.5f, -0.08f, 8);
        }
        else if (fTime <= 50)
        {
            itemGenerator.SetParameters(0.65f, -0.06f, 6);
        }

        if (fTime <= 0)
        {
            SceneManager.LoadScene(nScore >= 100 ? "EndScene" : "GameOverScene");   // 삼항연산자 사용 시간이 0이 될때 점수가 300 이상이면 EndScene 으로 이동 아니라면 GameOverScene 으로 이동 
        }
        this.gTimerText.GetComponent<TextMeshProUGUI>().text = this.fTime.ToString("F1");
        this.gScoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + this.nScore.ToString();
    }

    public void GetApple()
    {
        this.nScore += 10;
    }

    public void GetBomb()
    {
            this.nScore -= 15;
      
    }
}
