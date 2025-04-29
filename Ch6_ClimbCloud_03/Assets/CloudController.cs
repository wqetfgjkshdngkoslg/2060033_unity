using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CloudController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float fCloudSpeed = 0.07f;

    bool isMoveCloud = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isMoveCloud)
        {
            transform.Translate(fCloudSpeed, 0, 0); 

            if (transform.position.x >= 2.0f) 
            {
                isMoveCloud = false; 
            }
        }
        else
        {
            transform.Translate(-fCloudSpeed, 0, 0); 

            if (transform.position.x <= -2.0f) 
            {
                isMoveCloud = true; 
            }


        }

    }

}
  
