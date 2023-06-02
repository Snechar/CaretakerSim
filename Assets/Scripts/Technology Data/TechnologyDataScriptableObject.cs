using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TechnologyData")]
public class TechnologyDataScriptableObject : ScriptableObject
{

    public string TechName;
    public Sprite Image;
    [TextArea (10,100)]
    public string TechDescription;

}
