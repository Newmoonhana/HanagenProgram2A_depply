using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public ScoreManager scoreM;
    public KeyManager keyM;
    public AnimationManager aniM;

    public AudioSource theMusic;    //재생 음악.
    public bool startPlaying;   //노래 시작.
    public BeatScroller theBS;  //비트 스크롤러.

    private void Start()
    {
        inst = this;
        scoreM.SetSMText();
        scoreM.currentMultiplier = 1;
    }

    private void Update()
    {
        if (Input.anyKey)   //디버그용.
            if (!startPlaying)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
                aniM.PlayAniOnBPS(aniM.player_ani);
            }
    }

    public void NodeHit()
    {
        Debug.Log("Hit On Time");
        scoreM.multiplierTracker++;
    }
    public Animator[] hit_ani;  //판정 애니메이션 재생 용.
    public void MissHit()
    {
        aniM.PlayHitAni(Hits.MISS);

        NodeMissed();
    }
    public void BadHit()
    {
        aniM.PlayHitAni(Hits.BAD);

        scoreM.currentScore += Score.bad * scoreM.currentMultiplier;
        Debug.Log("CurrentScore + " + Score.bad * scoreM.currentMultiplier);
        NodeHit();
    }
    public void GoodHit()
    {
        aniM.PlayHitAni(Hits.GOOD);

        scoreM.currentScore += Score.good * scoreM.currentMultiplier;
        Debug.Log("CurrentScore + " + Score.good * scoreM.currentMultiplier);
        NodeHit();
    }
    public void CoolHit()
    {
        aniM.PlayHitAni(Hits.COOL);

        scoreM.currentScore += Score.cool * scoreM.currentMultiplier;
        Debug.Log("CurrentScore + " + Score.cool * scoreM.currentMultiplier);
        NodeHit();
    }
    public void PerfectHit()
    {
        aniM.PlayHitAni(Hits.PERFECT);

        scoreM.currentScore += Score.perfect * scoreM.currentMultiplier;
        Debug.Log("CurrentScore + " + Score.perfect * scoreM.currentMultiplier);
        NodeHit();
    }

    public void NodeMissed()
    {
        Debug.Log("Missed Note");

        scoreM.currentMultiplier = 1;
        scoreM.multiplierTracker = 0;
        scoreM.SetSMText();
    }
}
