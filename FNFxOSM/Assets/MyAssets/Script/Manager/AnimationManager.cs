using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hits
{
    PERFECT,
    COOL,
    GOOD,
    BAD,
    MISS,

    MAX
}

public class AnimationManager : MonoBehaviour
{
    public Animator[] hit_ani = new Animator[5];  //판정 애니메이션 재생 용.
    public Animator player_ani; //플레이 캐릭터 애니메이터.
    public float BPM; //곡 템포.

    private void Start()
    {
        BPM = BPM / 60f;
    }

    public void PlayAniOnBPS(Animator _ani) //박자에 맞춰 애니메이션 재생.
    {
        if (!_ani.enabled)
            _ani.enabled = true;
        _ani.Play(0, -1, BPM);
    }

    public void PlayHitAni(Hits _hit)   //판정 애니메이션 재생.
    {
        for (int i = 0; i < hit_ani.Length; i++)
        {
            hit_ani[i].SetBool("IsPlaying", false);
            hit_ani[i].Play(0, -1, 0f);
        }

        hit_ani[(int)_hit].SetBool("IsPlaying", true);
        Debug.Log("노트 판정 : " + _hit);
        Debug.Log("실행 애니메이션 : " + hit_ani[(int)_hit].gameObject.name);
    }
}
