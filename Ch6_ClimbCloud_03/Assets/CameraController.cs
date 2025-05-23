//플레이어가 화면에 보이지 않는 더 위쪽까지 이동하면, 카메라가 따라 갈 수 없는 문제점 발생
// 문제점을 해결하기 위해서는, 카메라가 플레이어를 따라다니며 움직일 수 있도록 스크립트 작성

using UnityEngine;


public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //플레이어 오브젝트를 찾기 위해서 멤버 변수 선언
    GameObject n_gPlayer = null;

    // 플레이어가 수직 이동할 떄마다 카메라가 따라다니도록 플레이어 Y좌표 저장 변수
    Vector3 vPlayerPosition = Vector3.zero;

    void Start()
    {
        // 플레리어 오브젝트를 찾아서 멤버 변수에 저장
        n_gPlayer = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 수직 이동할 때마다 카메라가 따라다니도록 프레임마다 플레이어 좌표를 구해서 저장(vPlayerPosition)
        vPlayerPosition = n_gPlayer.transform.position;

        //플레이어 이동에 카메라가 따라가는 것은 Y축 방향*의 변화이므로 위어서 구한 Y좌표값을 반영한다
        // x좌표와 z좌표는 변함이 없으므로 카메라의 원래 좌표를 그대로 사용
        transform.position = new Vector3(transform.position.x, vPlayerPosition.y, transform.position.z);
    }
}
