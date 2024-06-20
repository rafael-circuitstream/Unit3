using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public abstract void ExecuteCommand();
    public abstract bool IsCompleted();
}
