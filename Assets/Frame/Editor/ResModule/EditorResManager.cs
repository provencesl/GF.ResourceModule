using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorResManager : Singleton<EditorResManager>
{
    /// <summary>
    /// 获取资源
    /// 路径相对DataPath
    /// </summary>
    public T GetAssetRelative<T>(string resPath) where T : UnityEngine.Object
    {
        return AssetDatabase.LoadAssetAtPath<T>(resPath);
    }

}
