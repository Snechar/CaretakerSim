using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
     abstract public void OnUse(SpawnerScript controller);
}
