using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFloor : MonoBehaviour
{

    public void OnMouseDown()
    {
        if (UI.DoubleClick())
        {
            if (gameObject != null)
            {
                Animator animator = gameObject.GetComponent<Animator>();

                if (animator != null)
                {
                    bool show = animator.GetBool("show");
                    animator.SetBool("show", !show);
                }
            }          
        }
    }

}
