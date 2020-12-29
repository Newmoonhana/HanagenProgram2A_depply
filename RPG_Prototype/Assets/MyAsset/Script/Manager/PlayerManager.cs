using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //플레이어 속성값.
    [SerializeField] Character player_character = new Character(); //현재 플레이 중인 캐릭터.

    //플레이어 관련 변수.
    public GameObject player_obj;   //플레이어 오브젝트.
    Transform player_tns;
    Animator player_ani;  //플레이어 오브젝트 애니메이터.
    BoxCollider2D player_col;   //플레이어 캐릭터 컨트롤러.

    //플레이어의 상태.00
    public bool player_applyRunFlag = false;   //대시 중인지 체크(false: X, true: 대시).
    public int player_collide = -1; //-1:충돌 안함, n: 충돌한 태그 종류(콜라이더 enum 만들 예정).
    private bool gridMoveDelay = false;   //이동명령이 끝날 때까지 동작 불가(false: X, true: 동작 불가)).

    private Vector3 vector; //플레이어 방향키 체크후 조작용 벡터.

    private void Awake()
    {
        player_tns = player_obj.transform;
        player_ani = player_tns.GetChild(0).GetComponent<Animator>();
        player_col = player_tns.GetChild(1).GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //플레이어 이동(방향키).
        if (!gridMoveDelay)
            if (((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)))
                StartCoroutine(Player_Move());
    }

    //플레이어 이동 함수.
    IEnumerator Player_Move()
    {
        gridMoveDelay = true;
        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if (vector.x != 0)
            vector.y = 0;

        //대시 시 추가 적용되는 스피드 값.
        float applyRunspeed;
        if (Input.GetAxis("Dash") != 0)
        {
            applyRunspeed = player_character.Get_runspeed();
            player_applyRunFlag = true;
            player_ani.SetBool("Is_Dash", true);
        }
        else
        {
            applyRunspeed = 0;
            player_applyRunFlag = false;
            player_ani.SetBool("Is_Dash", false);
        }

        //충돌 여부.
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player")); //특정 레이어 제외.
        RaycastHit2D hit = Physics2D.Raycast(player_tns.position, vector, 1f, layerMask);
        string col = null;
        if (hit.collider != null)
            col = hit.collider.tag;
        if (col != "NoPassing") //이동 불가 콜라이더 미충돌.
        {
            yield return StartCoroutine(GameManager.inst.move_m.Move(player_obj, player_col, player_ani, vector, player_character.Get_movespeed(), applyRunspeed));
        }
        else    //이동 불가 콜라이더 충돌 시.
        {
            player_ani.SetFloat("DirX", vector.x);
            player_ani.SetFloat("DirY", vector.y);
            player_ani.SetBool("Is_Walking", false);
        }
        

        if (((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)))
            player_ani.SetBool("Is_Walking", false);
        gridMoveDelay = false;
    }
}
