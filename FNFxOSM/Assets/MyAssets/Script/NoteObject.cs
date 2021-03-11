using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyBoard keyToPress;

    private void Update()
    {
        if (canBePressed)
        {
            if (GameManager.inst.keyM.CheckNoteObjHit(keyToPress, this.transform))
            {
                gameObject.SetActive(false);
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.inst.NodeMissed();  //노트 Miss 처리.
        }
    }
}
