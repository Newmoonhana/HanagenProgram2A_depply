using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public bool hasStarted; //곡 시작 여부.

    private void Update()
    {
        if (hasStarted)
        {
            Vector3 tmp = Vector3.zero;
            tmp.y = GameManager.inst.aniM.BPM * 10f * Time.deltaTime;  //10f = 스프라이트 배율.
            transform.position += tmp;
        }
    }
}
