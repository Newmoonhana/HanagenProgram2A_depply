using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat   //캐릭터 스텟.
{
    int level;  //레벨.
    int maxhp; //체력.
    int maxmp;  //마력.
    int attack; //공격력.
    int defend; //방어력.
    int magic_a;    //마법공격력.
    int magic_d;    //마법방어력.
    int speed;  //민첩.
    int luck;   //운.

    //속성.

}

public class Character  //플레이어블 뿐만 아니라 필드에 생성될 몬스터 또한 공유되는 class(적/아군의 배치를 전환도 가능하게 설정하기 위해).
{
    string name;
    Stat char_stat;

    float movespeed; //기본 스피드(플레이어 스프라이트 크기의 약수).
    float runspeed;  //대시 스피드(플레이어 스프라이트 크기의 약수).
}
