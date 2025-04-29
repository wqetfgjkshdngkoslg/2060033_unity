using UnityEngine;
using TMPro;

public class ClearScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TMP_Text ResultScore;

    void Start()
    {
        ResultScore.text = "Score: " + PlayerController.nScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
