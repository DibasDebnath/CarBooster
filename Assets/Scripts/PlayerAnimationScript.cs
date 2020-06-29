using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{


    public Animator animator;



    public static string JUMPUP = "JumpUp";
    public static string JUMPDOWN = "JumpDown";
    public static string PUSH = "Push";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void jumpUp()
    {
        animator.SetTrigger(JUMPUP);
    }
    public void jumpDown()
    {
        animator.SetTrigger(JUMPDOWN);
    }
    public void push()
    {
        animator.SetTrigger(PUSH);
    }




}
