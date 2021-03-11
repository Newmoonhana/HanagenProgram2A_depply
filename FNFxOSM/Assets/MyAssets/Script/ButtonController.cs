using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //스프라이트 관련.
    private SpriteRenderer theSP;
    public Sprite defalutImage; //기본 스프라이트.
    public Sprite pressedImage; //방향키 누름 스프라이트.

    public KeyBoard keyToPress;  //버튼이 인식할 키.

    private void Start()
    {
        theSP = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.inst.keyM.CheckButtonBeUsed(keyToPress, KeyInput.DOWN))
        {
            switch (keyToPress)
            {
                case KeyBoard.UP:
                    GameManager.inst.aniM.player_ani.SetInteger("IsPushing_Y", 1);
                    break;
                case KeyBoard.DOWN:
                    GameManager.inst.aniM.player_ani.SetInteger("IsPushing_Y", -1);
                    break;
                case KeyBoard.LEFT:
                    GameManager.inst.aniM.player_ani.SetInteger("IsPushing_X", -1);
                    break;
                case KeyBoard.RIGHT:
                    GameManager.inst.aniM.player_ani.SetInteger("IsPushing_X", 1);
                    break;
            }
            this.theSP.sprite = pressedImage;
        }
        if(GameManager.inst.keyM.CheckButtonBeUsed(keyToPress, KeyInput.UP))
        {
            GameManager.inst.aniM.player_ani.SetInteger("IsPushing_X", 0);
            GameManager.inst.aniM.player_ani.SetInteger("IsPushing_Y", 0);
            GameManager.inst.aniM.player_ani.SetBool("IsMissing", true);
            this.theSP.sprite = defalutImage;
        }
    }
}
