using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 targetPos;  //타켓의 좌표.
    public Camera mainCamera;
    private int dir = 60;
    CinemachineVirtualCamera mainCamera_cinevirtual;

    void Awake()
    {
        mainCamera_cinevirtual = mainCamera.gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    //(이전 코드, 현재 시네머신 사용으로 사용 안함)메인 카메라 타겟 따라감.
    IEnumerator MainCamera_Move()
    {
        while (true)
        {
            GameObject target = mainCamera_cinevirtual.Follow.gameObject;
            if (target != null)
            {
                targetPos.Set(target.transform.position.x, target.transform.position.y, target.transform.position.z + 0.5f);

                if (dir < 0)
                    dir = 360 + dir;
                else if (dir >= 360)
                    dir -= 360;

                //각도 값 적용해서 픽셀 퍼펙트.
                Vector3 followV = new Vector3(targetPos.x, targetPos.y + (Mathf.Cos(dir) * -(Screen.height / 2)), targetPos.z + (Mathf.Sin(dir) * -(Screen.height / 2)));
                mainCamera.transform.position = followV;
            }
            yield return null;
        }
    }
}
