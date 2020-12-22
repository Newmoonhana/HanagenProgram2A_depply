using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour
{
    public InputField valOpen;
    public bool reset = false;

    public void Save()
    {
        PlayerPrefs.SetInt("Open", int.Parse(valOpen.text));
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("Open"))
        {
            ResetPP();
        }
        valOpen.text = PlayerPrefs.GetInt("Open").ToString();
    }

    //모든 값 리셋.
    public void ResetPP()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("Open", 0);


        reset = false;
    }
}
