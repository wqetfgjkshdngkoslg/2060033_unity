using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyGameDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    GameObject gTimerText;
    GameObject gScoreText;
    float fTime = 60.0f;
    int nScore = 0;

    ItemGenerator itemGenerator;

    void Start()
    {
        this.gTimerText = GameObject.Find("Time");
        this.gScoreText = GameObject.Find("Score");

        itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.fTime -= Time.deltaTime;

        if (fTime <= 0)
        {
            SceneManager.LoadScene(nScore >= 300 ? "EndScene" : "GameOverScene");   // ���׿����� ��� �ð��� 0�� �ɶ� ������ 300 �̻��̸� EndScene ���� �̵� �ƴ϶�� GameOverScene ���� �̵� 
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
       this.nScore -= 5;
       
    }
}
