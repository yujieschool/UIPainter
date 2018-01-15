using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {




    public enum AnimalState
    {
         Idle,

          RunJump,

        Run,

        RunSide,

        BackDeath,

        ForwardDeth,

        Attack,

        MaxValue

    }


    public void ChangeState()
    {
 

    }


    FsmManager fsmManager;

    Animator tmpAnimator;


    CharacterController charactorCtrl;
	// Use this for initialization
	void Start () {

         
        charactorCtrl  = GetComponent<CharacterController>();

       // charactorCtrl.isTrigger = false;

        charactorCtrl.detectCollisions = false; 

         tmpAnimator =   GetComponent<Animator>();
        fsmManager = new FsmManager((byte)AnimalState.MaxValue);


        PlayerIdl tmpIdle = new PlayerIdl(tmpAnimator);

        fsmManager.AddState(tmpIdle);

        PlayerRunJump tmpRunJump = new PlayerRunJump(tmpAnimator);

        fsmManager.AddState(tmpRunJump);


        PlayerRun tmpRun = new PlayerRun(tmpAnimator);

        fsmManager.AddState(tmpRun);



        PlayerRunSide tmpRunSide = new PlayerRunSide(tmpAnimator);

        fsmManager.AddState(tmpRunSide);


        PlayerBackDeath tmpBackDeath = new PlayerBackDeath(tmpAnimator);

        fsmManager.AddState(tmpBackDeath);

        PlayerForwardDeath tmpForwardDeth = new PlayerForwardDeath(tmpAnimator);

        fsmManager.AddState(tmpForwardDeth);


        PlayerAttack tmpAttack = new PlayerAttack(tmpAnimator);

        fsmManager.AddState(tmpAttack);


	}


    void OnAnimatorMove()
    {

        charactorCtrl.detectCollisions = false; 


        charactorCtrl.SimpleMove(transform.forward*5);

        transform.rotation = tmpAnimator.bodyRotation;
         

    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKey(KeyCode.A))
        {


            fsmManager.ChangeState((sbyte)AnimalState.Run,-1);


        }



        if (Input.GetKey(KeyCode.D))
        {


            fsmManager.ChangeState((sbyte)AnimalState.Run, 1);

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {


            fsmManager.ChangeState((sbyte)AnimalState.RunJump);


        }



        if (Input.GetKeyDown(KeyCode.S))
        {


            fsmManager.ChangeState((sbyte)AnimalState.RunSide);

        }









        if (fsmManager != null)
            fsmManager.Update();


		
	}
}
