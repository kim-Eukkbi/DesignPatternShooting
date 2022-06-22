using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DesginPatternInfoList", menuName = "ScriptableObject/DesginPatternInfo")]
public class DesignPatternSO : ScriptableObject
{
    public List<DesignPatternInfo> designPatternInfoList;
}

[System.Serializable]
public class DesignPatternInfo
{
    public string desginPatternName = "";
    [TextArea]
    public string infomation = "";
}
