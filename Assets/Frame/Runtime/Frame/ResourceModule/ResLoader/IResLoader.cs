using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源加载接口
/// </summary>
public interface IResLoader
{
    /// <summary>
    /// AB包加载
    /// </summary>
    IAssetBundleLoader AssetBundleLoader { get; set; }
}
