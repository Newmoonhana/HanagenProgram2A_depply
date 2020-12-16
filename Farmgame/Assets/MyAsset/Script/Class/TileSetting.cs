using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile
{
    enum TileMode
    {
        No_data,
        Default_field
    }

    public class TileSetting : MonoBehaviour
    {
        string tileobj_name = "";
        TileMode tilemode = TileMode.Default_field;
        System.DateTime startTime; //작물을 심기 시작한 시간 저장.
        System.TimeSpan growthTime; //작물이 자라날 속도 시간 변수.

        //get set
        public string GetTileobjName()
        {
            return tileobj_name;
        }
        public void SetTileobjName(string _name)
        {
            tileobj_name = _name;
        }
        public System.DateTime GetStartTime()
        {
            return startTime;
        }
        public void SetStartTime(int _hours, int _minutes)
        {
            startTime = System.DateTime.Now;
            PlayerPrefs.SetInt(tileobj_name + "_startTime_dd", startTime.Day);
            PlayerPrefs.SetInt(tileobj_name + "_startTime_hh", startTime.Hour);
            PlayerPrefs.SetInt(tileobj_name + "_startTime_mm", startTime.Minute);

        }
        public System.TimeSpan GetGrowthTime()
        {
            return growthTime;
        }
        public void SetGrowthTime(int _minutes)
        {
            growthTime = new System.TimeSpan(_minutes / 60, _minutes % 60, 0);
            PlayerPrefs.SetInt(tileobj_name + "_growthTime_mm", _minutes);
        }

        public bool GrowthTimeCheck()  //작물 성장 체크.
        {
            System.DateTime nowTime = System.DateTime.Now;

            if (startTime + growthTime >= nowTime)
            {


                return true;    //작물 성장 완료.
            }

            return false;   //작물 덜 성장.
        }
    }
}
