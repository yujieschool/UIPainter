using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerIdl : FsmBase
{
    Animator animator;



    public PlayerIdl(Animator tmpAnimator)
    {

        

        this.animator = tmpAnimator;
 
    }

    public override void OnEnter()
    {

        animator.SetInteger("Index",1);
    }
    
 
}


public class PlayerRunJump: FsmBase
{
    Animator animator;



    public PlayerRunJump(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 2);
    }


}


public class PlayerRun : FsmBase
{
    Animator animator;



    public PlayerRun(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {


        animator.SetInteger("Index", 3);
    }

    public override void ReEnter(sbyte index)
    {
        //base.ReEnter(index);

        Debug.Log("cur index == " + index);
        animator.SetFloat("RunDirect",index,0.55f,Time.deltaTime);
    }


    public override void OnLeave()
    {
      //  base.OnLeave();

        animator.SetFloat("RunDirect",0);

    }

}


public class PlayerRunSide : FsmBase
{
    Animator animator;



    public PlayerRunSide(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 4);
    }


}


public class PlayerBackDeath : FsmBase
{
    Animator animator;



    public PlayerBackDeath(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 5);
    }


}


public class PlayerForwardDeath : FsmBase
{
    Animator animator;



    public PlayerForwardDeath(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Index", 6);
    }


}


public class PlayerAttack : FsmBase
{
    Animator animator;



    public PlayerAttack(Animator tmpAnimator)
    {
        this.animator = tmpAnimator;
    }

    public override void OnEnter()
    {
       // animator.SetInteger("Index", 6);


        animator.SetLayerWeight(1,1);
    }

    public override void OnLeave()
    {
        //base.OnLeave();

        animator.SetLayerWeight(1, 0);
    }



}




