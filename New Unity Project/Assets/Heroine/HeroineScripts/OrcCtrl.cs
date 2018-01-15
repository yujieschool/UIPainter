using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OrcCtrl : MonoBehaviour {

    private FsmManager fsmManager;
    public enum AnimalState
    {
        idle,
        attack1,
        attack2,
        attack3,
        attack4,
        attack5,
        death,
        run,
        left,
        right,
        MaxValue
    }

    public void ChangeState(sbyte stateIndex)
    {
        fsmManager.ChangeState(stateIndex);
    }

    private float tmpTime;

	void Start () {
        tmpTime = 0;
        fsmManager = new FsmManager((byte)AnimalState.MaxValue);
        Animator tmpAnimator = transform.GetComponent<Animator>();
        FsmBase tmpIdle = new OrcIdle(tmpAnimator);
        fsmManager.AddState(tmpIdle);//0
        FsmBase tmpAttack1 = new OrcAttack1(tmpAnimator);
        fsmManager.AddState(tmpAttack1);//1
        FsmBase tmpAttack2 = new OrcAttack2(tmpAnimator);
        fsmManager.AddState(tmpAttack2);//2
        FsmBase tmpAttack3 = new OrcAttack3(tmpAnimator);
        fsmManager.AddState(tmpAttack3);//3
        FsmBase tmpAttack4 = new OrcAttack4(tmpAnimator);
        fsmManager.AddState(tmpAttack4);//4
        FsmBase tmpAttack5 = new OrcAttack5(tmpAnimator);
        fsmManager.AddState(tmpAttack5);//5
        FsmBase tmpDeath = new OrcDeath(tmpAnimator);
        fsmManager.AddState(tmpDeath);//6
        FsmBase tmpRun = new OrcRun(tmpAnimator);
        fsmManager.AddState(tmpRun);//7
        FsmBase tmpLeft = new OrcLeft(tmpAnimator);
        fsmManager.AddState(tmpLeft);//8
        FsmBase tmpRight = new OrcRight(tmpAnimator);
        fsmManager.AddState(tmpRight);//9


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            fsmManager.ChangeState((sbyte)AnimalState.left);
        }else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            fsmManager.ChangeState((sbyte)AnimalState.right);
        }else if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("XX");
            fsmManager.ChangeState((sbyte)AnimalState.run);
        }

        if (Input.GetMouseButtonDown(0))
        {
            fsmManager.ChangeState((sbyte)AnimalState.attack1);
        }
        
    }

    public void RTime()
    {
        tmpTime += Time.deltaTime;
    }
}
