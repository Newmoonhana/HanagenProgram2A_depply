using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public PlayerPrefsManager pp_mng;
    public FieldManager field_mng;

    public Camera mainCamera;

    void Awake()
    {
        if (inst != null)   //간단한 싱글톤.
        {
            Destroy(gameObject);
            return;
        }
        inst = this;
        DontDestroyOnLoad(this);    //씬 이동 후 오브젝트 보존.

        pp_mng.Load();
    }
}
