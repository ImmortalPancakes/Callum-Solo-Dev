using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractableObject
{
    ///
    /// Does action
    /// 
    void Facing();

    Vector3 Position { get; }

    void DoAction();
}
