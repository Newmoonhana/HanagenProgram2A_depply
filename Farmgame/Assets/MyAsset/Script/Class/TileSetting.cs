using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile
{
    public class TileSetting : MonoBehaviour
    {
        int tilemode = 1;   //1: 평지, 2: 밭.
        System.DateTime startTime; //작물을 심기 시작한 시간 저장.
        System.TimeSpan growthTime; //작물이 자라날 속도 시간 변수.

        //get set
        public void SetGrowthTime(System.TimeSpan _time)
        {
            growthTime = _time;
        }
        public void SetGrowthTime(int _hours, int _minutes, int _seconds)
        {
            growthTime = new System.TimeSpan(_hours, _minutes, _seconds);
        }

        bool GrowthTimeCheck()  //작물 성장 체크.
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
