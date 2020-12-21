using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public IEnumerator Move(GameObject move_obj, BoxCollider2D move_col, Animator move_ani, Vector3 vector, float speed, float runSpeed)
    {
        //충돌 여부.
        RaycastHit hit;
        Physics.Raycast(move_col.gameObject.transform.position, vector, out hit, 1f);
        string col = null;
        if (hit.collider != null)
            col = hit.collider.tag;
        if (col != "NoPassing")
        {
            move_ani.SetFloat("DirX", vector.x);
            move_ani.SetFloat("DirY", vector.y);
            move_ani.SetBool("Is_Walking", true);
            float currentWalkCount = 0;
            Vector3 startV = move_obj.transform.position;
            while (currentWalkCount < 1)
            {
                move_obj.transform.Translate(vector.x * (speed + runSpeed), vector.y * (speed + runSpeed), vector.z);
                currentWalkCount += speed + runSpeed;
                yield return GameManager.inst.wait00_10f;
            }
            move_obj.transform.position = startV + vector;  //이동 후 그리드와 안맞을 경우를 대비해 위치 재설정.
        }
        else
        {
            move_ani.SetBool("Is_Walking", false);
        }
            
        yield return null;
    }
}