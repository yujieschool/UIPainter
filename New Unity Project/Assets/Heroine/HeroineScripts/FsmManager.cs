using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmManager {

    FsmBase[] allState;
    sbyte stateIndex;
    sbyte curIndex;

    public FsmManager(byte num)
    {
        allState = new FsmBase[num];
        stateIndex = -1;
        curIndex = -1;
    }

    public void AddState(FsmBase tmpBase)
    {
        stateIndex++;
        allState[stateIndex] = tmpBase;
    }



    public void ChangeState(sbyte index,sbyte state =0 )
    {

        if (index == curIndex)
        {
            allState[curIndex].ReEnter(state);
            return;
        }
           

        if (curIndex!=-1)
        {
            allState[curIndex].OnLeave();
            curIndex = index;
         
        }
        else
        {
            curIndex = index;
          
        }

        allState[curIndex].OnEnter();
    }
    public void Update()
    {

    }
}
