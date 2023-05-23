using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
    public NPCStats owner;
    public int age;
     abstract public void OnUse(SpawnerScript controller);
}
