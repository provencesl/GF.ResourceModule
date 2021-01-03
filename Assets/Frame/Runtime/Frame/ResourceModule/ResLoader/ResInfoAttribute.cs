using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class ResInfoAttribute : Attribute
{
    /// <summary>
    /// AB包路径
    /// </summary>
    public string abPath;

    /// <summary>
    /// 资源名
    /// </summary>
    public string assetName;

    /// <summary>
    /// 是否异步
    /// </summary>
    public bool async = false;

    /// <summary>
    /// 资源位置
    /// </summary>
    public AssetLocation location = AssetLocation.StreamingAssets;

    public ResInfoAttribute()
    {

    }

    public ResInfoAttribute(string abPath, string assetName)
    {
        this.abPath = abPath;
        this.assetName = assetName;
    }

    public ResInfoAttribute(string abPath, string assetName, bool async, AssetLocation location)
    {
        this.abPath = abPath;
        this.assetName = assetName;
        this.async = async;
        this.location = location;
    }
}
/// <summary>
/// Asset的资源目录
/// </summary>
public enum AssetLocation
{
    StreamingAssets = 0,

    PersistentDataPath
}