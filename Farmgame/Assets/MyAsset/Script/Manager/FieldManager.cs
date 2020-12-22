using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    List<GameObject> tile_obj = new List<GameObject>();
    List<TileSetting> tile_scp_lst = new List<TileSetting>();

    public Transform FieldParent;

    private void Awake()
    {
        for (int i = 0; i < FieldParent.childCount; i++)
        {
            tile_obj.Add(FieldParent.GetChild(i).gameObject);
            tile_scp_lst.Add(FieldParent.GetChild(i).GetComponent<TileSetting>());
        }
    }


}
