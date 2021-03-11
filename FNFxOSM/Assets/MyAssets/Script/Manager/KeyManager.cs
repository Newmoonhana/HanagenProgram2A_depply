using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyBoard
{ 
    UP,
    LEFT,
    DOWN,
    RIGHT,
    ENTER,
    BACK,
    
    MAX
}

public enum KeyInput
{
    DOWN,
    ON,
    UP,

    MAX
}

public class KeySetting    //키 세팅.
{
    public KeyCode[][] keySetting;
    KeyCode[] upKey;
    KeyCode[] leftKey;
    KeyCode[] rightKey;
    KeyCode[] downKey;
    KeyCode[] enterKey;
    KeyCode[] backKey;

    public KeySetting()
    {
        upKey = new KeyCode[3] { KeyCode.UpArrow, KeyCode.W, KeyCode.Joystick1Button3 };
        leftKey = new KeyCode[4] { KeyCode.LeftArrow, KeyCode.A, KeyCode.Joystick1Button2, KeyCode.Joystick1Button4 };
        downKey = new KeyCode[3] { KeyCode.DownArrow, KeyCode.S, KeyCode.Joystick1Button0 };
        rightKey = new KeyCode[4] { KeyCode.RightArrow, KeyCode.D, KeyCode.Joystick1Button1, KeyCode.Joystick1Button5 };

        enterKey = new KeyCode[3] { KeyCode.KeypadEnter, KeyCode.Space, KeyCode.Joystick1Button2 };
        backKey = new KeyCode[3] { KeyCode.Backspace, KeyCode.Escape, KeyCode.Joystick1Button2 };

        keySetting = new KeyCode[6][] { upKey, leftKey, downKey, rightKey, enterKey, backKey };
    }
}

public class KeyManager : MonoBehaviour
{
    KeySetting key_setting = new KeySetting();
    public Transform Button;   //버튼 충돌 위치 파악 용.

    private void Update()
    {
        if (GameManager.inst.keyM.CheckButtonBeUsed(KeyBoard.ENTER, KeyInput.DOWN))
        {
            
        }
        else if (GameManager.inst.keyM.CheckButtonBeUsed(KeyBoard.BACK, KeyInput.DOWN))
        {

        }
    }

    //키보드 체크 관련.
    public bool CheckButtonBeUsed(KeyBoard _pressedKey, KeyInput _keyInput) //버튼이 눌러졌는지(키가 있는지) 체크.
    {
        if (_pressedKey < KeyBoard.UP || _pressedKey >= KeyBoard.MAX)
        {
            return false;
        }
        
        KeyCode[] keyTmp = key_setting.keySetting[(int)_pressedKey]; //계산에 사용할 임시 변수.
        bool tmp = false;
        for (int i = 0; i < keyTmp.Length; i++)
        {
            if (keyTmp[i] != KeyCode.None)
            {
                switch(_keyInput)
                {
                    case KeyInput.DOWN:
                        if (Input.GetKeyDown(keyTmp[i]))
                        {
                            tmp = true;
                        }
                        break;
                    case KeyInput.ON:
                        if (Input.GetKey(keyTmp[i]))
                        {
                            tmp = true;
                        }
                        break;
                    case KeyInput.UP:
                        if (Input.GetKeyUp(keyTmp[i]))
                        {
                            tmp = true;
                        }
                        break;
                }
                
                if (tmp)
                {
                    Debug.Log("Command : " + keyTmp[i] + ", Input : " + _keyInput);  //누른 버튼 체크 디버그.
                    break;
                }
            }
        }
        return tmp;
    }
    public bool CheckNoteObjHit(KeyBoard _pressedKey, Transform _noteTns)
    {
        bool tmp = false;
        if (CheckButtonBeUsed(_pressedKey, KeyInput.DOWN))
        {
            //거리에 따른 판정 처리.
            Hits _hit = Hits.MAX;
            Debug.Log("버튼 위치: " + Button.position.y + ", 노트 위치 : " + _noteTns.position.y + ", 거리 : " + Mathf.Abs(Button.position.y - _noteTns.position.y));
            if (Mathf.Abs(Button.position.y - _noteTns.position.y) < 1)
            {
                _hit = Hits.PERFECT;
            }
            else if (Mathf.Abs(Button.position.y - _noteTns.position.y) < 2)
            {
                _hit = Hits.COOL;
            }
            else if (Mathf.Abs(Button.position.y - _noteTns.position.y) < 5)
            {
                _hit = Hits.GOOD;
            }
            else if (Mathf.Abs(Button.position.y - _noteTns.position.y) < 9)
            {
                _hit = Hits.BAD;
            }
            else
            {
                _hit = Hits.MISS;
            }

            //이벤트 처리.
            GameManager.inst.aniM.PlayHitAni(_hit); //판정 애니메이션 재생.
            switch(_hit)
            {
                case Hits.PERFECT:
                    GameManager.inst.scoreM.currentScore += Score.perfect * GameManager.inst.scoreM.currentMultiplier;
                    GameManager.inst.NodeHit();
                    GameManager.inst.aniM.player_ani.SetBool("IsMissing", false);
                    tmp = true;
                    break;
                case Hits.COOL:
                    GameManager.inst.scoreM.currentScore += Score.cool * GameManager.inst.scoreM.currentMultiplier;
                    GameManager.inst.NodeHit();
                    GameManager.inst.aniM.player_ani.SetBool("IsMissing", false);
                    tmp = true;
                    break;
                case Hits.GOOD:
                    GameManager.inst.scoreM.currentScore += Score.good * GameManager.inst.scoreM.currentMultiplier;
                    GameManager.inst.NodeHit();
                    GameManager.inst.aniM.player_ani.SetBool("IsMissing", false);
                    tmp = true;
                    break;
                case Hits.BAD:
                    GameManager.inst.scoreM.currentScore += Score.bad * GameManager.inst.scoreM.currentMultiplier;
                    GameManager.inst.NodeHit();
                    GameManager.inst.aniM.player_ani.SetBool("IsMissing", false);
                    tmp = true;
                    break;
                case Hits.MISS:
                    GameManager.inst.scoreM.currentScore += Score.miss * GameManager.inst.scoreM.currentMultiplier;
                    GameManager.inst.aniM.PlayHitAni(Hits.MISS);
                    GameManager.inst.NodeMissed();
                    GameManager.inst.aniM.player_ani.SetBool("IsMissing", true);
                    break;
            }
            Debug.Log("CurrentScore + " + GameManager.inst.scoreM.currentScore);
        }
        return tmp;
    }
}
