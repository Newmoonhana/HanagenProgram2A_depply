using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    
}
public enum Type
{
    NULL = 0,
    //물리 계열.
    NORMAL = 1,
    EXTORT = 2,
    //마법 계열.
    FIRE = 3,
    WATER = 4,
    ICE = 5,
    ELECTRIC = 6,
    EARTH = 7,
    WIND = 8,
    //신성 계열.
    HOLY = 9,
    MAGUS = 10,
    PSYCHIC = 11,
    //근거리 원거리
    SHORT_RANGE = 12,
    LONG_RANGE = 13,
    //육지(지상) 공중
    GROUND = 14,
    MIDAIR = 15
}
[System.Serializable]
public class TypeData
{
    [Tooltip("속성 1")]
    [SerializeField] Type defalut1 = Type.NULL;
    [Tooltip("속성 2")]
    [SerializeField] Type defalut2 = Type.NULL;
    [Tooltip("거리 방식")]
    [SerializeField] Type range = Type.SHORT_RANGE;
    [Tooltip("캐릭터 위치")]
    [SerializeField] Type pos = Type.GROUND;
}