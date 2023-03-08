using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName  ="Light Preset",menuName= "Scriptables/Light Preset")]
public class Lightingpreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;

}
