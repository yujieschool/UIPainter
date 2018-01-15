using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrcIdle : FsmBase
{
    Animator animator;

    public OrcIdle(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 0);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcAttack1 : FsmBase
{
    Animator animator;

    public OrcAttack1(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 1);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcAttack2 : FsmBase
{
    Animator animator;

    public OrcAttack2(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 2);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcAttack3 : FsmBase
{
    Animator animator;

    public OrcAttack3(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 3);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcAttack4 : FsmBase
{
    Animator animator;

    public OrcAttack4(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 4);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcAttack5 : FsmBase
{
    Animator animator;

    public OrcAttack5(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 5);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcDeath : FsmBase
{
    Animator animator;

    public OrcDeath(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 6);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcRun : FsmBase
{
    Animator animator;

    public OrcRun(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        Debug.Log("XAXAXAX");
        animator.SetInteger("Marking", 7);
        animator.SetFloat("Angle", 0);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcLeft : FsmBase
{
    Animator animator;

    public OrcLeft(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 7);
        animator.SetFloat("Angle",-1);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}

public class OrcRight : FsmBase
{
    Animator animator;

    public OrcRight(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        animator.SetInteger("Marking", 7);
        animator.SetFloat("Angle", 1);
    }

    public override void OnLeave()
    {
    }

    public override void Update()
    {
    }
}
