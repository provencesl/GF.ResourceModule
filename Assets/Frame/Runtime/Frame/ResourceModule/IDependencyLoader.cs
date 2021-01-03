using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDependencyLoader
{
        
    /// <summary>
    /// 加载manifest
    /// </summary>
    void LoadManifestAssetBundle(string abPath);

    /// <summary>
    /// 异步加载manifest
    /// </summary>
    void LoadManifestAssetBundleAsync(string abPath, Action callback = null, Action<float> progressCallback = null);

}
