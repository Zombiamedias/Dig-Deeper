using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Animator animatorController;
    // Start is called before the first frame update
  
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButton("Fire1"))
        {
            animatorController.SetInteger("Animation_int",10);
        }
        else
        {
            animatorController.SetInteger("Animation_int",0);
        }
        animatorController.SetFloat("Speed_f", Input.GetAxis("Vertical"));
    }
}
