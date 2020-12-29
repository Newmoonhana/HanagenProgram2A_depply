using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[System.Serializable]
public class Stat   //캐릭터 스텟.
{
    [Tooltip("레벨")]
    [SerializeField] int level;
    [Space(10f)]

    [Tooltip("체력")]
    [SerializeField] int hp;
    [Tooltip("최대 체력")]
    [SerializeField] int hp_max;
    [Space(10f)]

    [Tooltip("마력")]
    [SerializeField] int mp;
    [Tooltip("최대 마력")]
    [SerializeField] int mp_max;
    [Space(10f)]

    [Tooltip("공격력(적용 수치)")]
    [SerializeField] int attack;
    [Tooltip("공격력(기본)")]
    [SerializeField] int attack_defalut;
    [Space(10f)]

    [Tooltip("방어력(적용 수치)")]
    [SerializeField] int defend;
    [Tooltip("방어력(기본)")]
    [SerializeField] int defend_defalut;
    [Space(10f)]

    [Tooltip("마법공격력(적용 수치)")]
    [SerializeField] int magic_a;
    [Tooltip("마법공격력(기본)")]
    [SerializeField] int magic_a_defalut;
    [Space(10f)]

    [Tooltip("마법방어력(적용 수치)")]
    [SerializeField] int magic_d;
    [Tooltip("마법방어력(기본)")]
    [SerializeField] int magic_d_defalut;
    [Space(10f)]

    [Tooltip("민첩(적용 수치)")]
    [SerializeField] int speed;
    [Tooltip("민첩(기본)")]
    [SerializeField] int speed_defalut;
    [Space(10f)]

    [Tooltip("운(적용 수치)")]
    [SerializeField] int luck;
    [Tooltip("운(기본)")]
    [SerializeField] int luck_defalut;
    [Space(10f)]

    //속성.
    [SerializeField] TypeData charType;

    public Stat()
    {
        level = 1;
        charType = new TypeData();
    }
}

[System.Serializable]
public class Character  //플레이어블 뿐만 아니라 필드에 생성될 몬스터 또한 공유되는 class(적/아군의 배치를 전환도 가능하게 설정하기 위해).
{
    [Tooltip("캐릭터 이름")]
    [SerializeField] string name;
    [Tooltip("캐릭터 인적사항")]
    [TextArea(3, 5)]
    [SerializeField] string information;

    [Header("Character Stat")]
    [Tooltip("캐릭터 스탯")]
    [SerializeField] Stat stat;  //스텟.

    //필드 내 관련 스탯.
    [Header("Field Stat")]
    [Tooltip("필드 이동 기본 스피드")]
    [SerializeField] float movespeed;

    [Tooltip("대시 시 추가 스피드")]
    [SerializeField] float runspeed;

    public Character()
    {
        movespeed = 0.5f;
        runspeed = 0.5f;
        stat = new Stat();
    }

    //get set
    public float Get_movespeed()
    {
        return movespeed;
    }
    public float Get_runspeed()
    {
        return runspeed;
    }
}
