using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FsmBase {
    public abstract void OnEnter();
    public virtual void OnLeave(){}
    public virtual void Update(){}

    public virtual void ReEnter(sbyte  index) { }


}
