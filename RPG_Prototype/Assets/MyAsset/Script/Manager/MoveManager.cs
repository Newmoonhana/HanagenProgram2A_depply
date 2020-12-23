using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public IEnumerator Move(GameObject move_obj, BoxCollider2D move_col, Animator move_ani, Vector3 vector, float speed, float runSpeed)
    {
        move_ani.SetFloat("DirX", vector.x);
        move_ani.SetFloat("DirY", vector.y);
        move_ani.SetBool("Is_Walking", true);
        float currentWalkCount = 0;
        Vector3 startV = move_obj.transform.position;
        Vector3 goal = startV + vector;
        float speedResult = (speed + runSpeed) * Time.deltaTime;

        while (currentWalkCount < 1)
        {
            Debug.DrawRay(startV, vector, new Color(0, 1, 0)); //디버그용.
            move_obj.transform.Translate(vector.x * speedResult, vector.y * speedResult, vector.z);
            currentWalkCount += speedResult;
            yield return null;
        }
        move_obj.transform.position = goal;  //이동 후 그리드와 안맞을 경우를 대비해 위치 재설정.

        yield return null;
    }
}