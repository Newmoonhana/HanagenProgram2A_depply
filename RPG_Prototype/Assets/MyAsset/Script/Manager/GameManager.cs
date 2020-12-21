using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public PlayerManager player_m;
    public MoveManager move_m;

    //전역 변수.
    public WaitForSeconds wait00_01f = new WaitForSeconds(00.01f);   //0.01초 대기.
    public WaitForSeconds wait00_10f = new WaitForSeconds(00.10f);   //0.1초 대기.

    private void Awake()
    {
        if (inst == null)
        {
            DontDestroyOnLoad(this.gameObject);
            inst = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
