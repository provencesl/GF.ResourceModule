using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 依赖资源模块
/// </summary>
public class DepResModule : IAssetBundleLoader, IDependencyLoader
{
    private IAssetBundleLoader _loader;

    private IDependencyLoader _depLoader;

    public DepResModule()
    {
        SetupLoader();
    }

    public DepResModule(string manifestAssetBundlePath)
    {
        SetupLoader();

        LoadManifestAssetBundle(manifestAssetBundlePath);
    }

    /// <summary>
    /// 装载加载器
    /// </summary>
    private void SetupLoader()
    {
        DepAssetBundleLoader loader = new DepAssetBundleLoader();

        _depLoader = loader;

        _loader = new ResModule(loader);
    }

    //=============== 接口实现 ====================//


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abPath"></param>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public T GetAsset<T>(string abPath, string assetName) where T : UnityEngine.Object
    {
        return _loader.GetAsset<T>(abPath, assetName);
    }

    public void GetAssetAsync<T>(string abPath, string assetName, Action<T> callback, Action<float> progressCallback = null) where T : UnityEngine.Object
    {
        _loader.GetAssetAsync(abPath, assetName, callback, progressCallback);
    }

    public AssetBundle LoadAssetBundle(string abPath)
    {
        return _loader.LoadAssetBundle(abPath);
    }

    public void LoadAssetBundleAsync(string abPath, Action<AssetBundle> callback, Action<float> progressCallback)
    {
        _loader.LoadAssetBundleAsync(abPath, callback, progressCallback);
    }

    public void LoadManifestAssetBundle(string abPath)
    {
        _depLoader.LoadManifestAssetBundle(abPath);

        _loader.Unload(abPath, false);
    }

    public void LoadManifestAssetBundleAsync(string abPath, Action callback = null, Action<float> progressCallback = null)
    {
        _depLoader.LoadManifestAssetBundleAsync(abPath, () => _loader.Unload(abPath, false), progressCallback);
    }

    public void Unload(string abPath, bool unloadAllLoadedObjects)
    {
        _loader.Unload(abPath, unloadAllLoadedObjects);
    }

    public void UnloadAll(bool unloadAllLoadedObjects)
    {
        _loader.UnloadAll(unloadAllLoadedObjects);
    }
}
