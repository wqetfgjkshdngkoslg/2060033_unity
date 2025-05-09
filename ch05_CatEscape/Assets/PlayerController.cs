using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    // 멤버 변수 선언
    float fMaxPositionX = 5.0f; // 플레이어 좌 , 우 이동시 게임창을 벗어나지 않도록 Vector  최댓값 설정 변수
    float fMinPositionX = -5.0f; // 플레이어 좌, 우 이동시 게임창을 벗어나지 않도록 Vector 최솟값 설정 변수
    float fPositionX = 0.0f;    // 플레이어가 좌, 우 이동할 수 있는 X좌표 저장 변수

    GameObject gLButton = null; // 오른쪽 버튼의 button Object를 저장할 변수
    GameObject gRButton = null; // 왼쪽 버튼의 button Object를 저장할 변수
    GameObject gHpGauge = null; // HP Gauge Image Object를 저장할 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
     Start 메서드
    미리 정의된 특수 이벤트 함수로써, 이 특수 함수듫을 C#에서는 함수를 메소드라고함
    MonoBehaviour 클래스가 초기화 될떄 호출되는 함수
    즉 start()메서드는스크립트인스턴스가활성화된경우에만첫번째프레임업데이트전에호출하므로 한번만 실행
    씬에셋에포함된모든오브젝트에대해Update등 이전에호출된모든스크립트를위한start함수가호출
    따라서게임플레이도중오브젝트를인스턴스화할때는실행되지않음
     */
    void Start()
    {
        /*
         디바이스 성능에 따른 실행 결과의 차이 없애기
        어떤 성능의 컴퓨터에서 동작해도 같은 속도로 움직이도록 하는 처리
        스마트폰은 60, PC는 300이 될 수 있는 디바이스 성능에 따라 게임 동작에 영향을 미칠수 있음
        프레임레이트 60으로 고정
         */
        Application.targetFrameRate = 60;
        gHpGauge = GameObject.Find("hpGauge"); // 게임 오브젝트 중에 hp게이지를 찾는 Find 함수 이용
        gLButton = GameObject.Find("LButton"); // 게임 오브젝트 중에 왼쪽 버튼을 찾는 Find 함수 이용
        gRButton = GameObject.Find("RButton"); // 게임 오브젝트 중에 오른쪽 버튼을 찾는 Find 함수 이용
    }

    // Update is called once per frame
    void Update()
    {
        /*
         키가눌렸는지검출하기위해서는Input클래스의GetKeyDown메서드를 사용함
        이메서드는매개변수로전달한키가눌리는순간true를한번만변환
        GetKeyDown메서드는지금까지사용하던GetMouseButtonDown메서드와비슷하므로 쉽게이해할수잇을것
        키를 누르는 순간 : GetKeyDown()
        키를 누르고 았는 순간 : GetKey()
        키를 뗀 순간 : GetKeyUp()
         */
        if (gHpGauge.GetComponent<Image>().fillAmount > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.5f, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.5f, 0, 0);
            }

            gLButton.GetComponent<Button>().interactable = true; // 왼쪽 버튼의 컴포넌트에서 버튼기능의 활성화
            gRButton.GetComponent<Button>().interactable = true; // 오른쪽 버튼의 컴포넌트에서 버튼기능의 활성화

        }
        else
        {

            gLButton.GetComponent<Button>().interactable = false; // 왼쪽 버튼의 컴포넌트에서 버튼기능의 활성화 기능을 끄는 기능
            gRButton.GetComponent<Button>().interactable = false; // 오른쪽 버튼의 컴포넌트에서 버튼기능의 활성화 기능을 끄는 기능
        }
        /*
        Mathf.Clamp(value, min, max) 메서드
            특정값을 어떠한 범위에 제한시키고자 할 때 사용하는 메서드
            value 값의 범위 : min < value < max
            최소/ 최대 값을 설정하여 지정한 범위 이외에 값이 되지 않도록 할 때 사용
            플레이어가 움직일 수 있는 최소/ 최대 범위값을 설정하여 그 범위를 벗어나지 않도록 한다.
        */

        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);



    }

 
    public void LButtonDown()
    {
        transform.Translate(-1.0f, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(1.0f, 0, 0);
    }

    

}
