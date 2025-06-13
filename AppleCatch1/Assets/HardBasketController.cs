using UnityEngine;

public class HardBasketController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip AppleSE;
    public AudioClip BombSE;
    AudioSource AudioSource;
    GameObject gDirector;

    void Start()
    {

        Application.targetFrameRate = 60;

        this.AudioSource = GetComponent<AudioSource>();

        this.gDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float fxoff = Mathf.RoundToInt(hit.point.x);
                float fzoff = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(fxoff, 0, fzoff);
            }
        }
    }


    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            //Debug.Log("Apple");
            this.AudioSource.PlayOneShot(this.AppleSE);
            this.gDirector.GetComponent<HardGameDirector>().GetApple();
        }
        else
        {

            //Debug.Log("Bomb");
            this.AudioSource.PlayOneShot(this.BombSE);
            this.gDirector.GetComponent<HardGameDirector>().GetBomb();
        }
        //Debug.Log("Catch");
        Destroy(other.gameObject);
    }
}
