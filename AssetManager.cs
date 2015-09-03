using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 资源目录的枚举名
/// </summary>
public enum AssetType
{
    Model,
    Texture
}

/// <summary>
/// 统一资源管理器
/// </summary>
public class AssetManager : MonoBehaviour
{

    public static AssetManager Instance;

    private Dictionary<string, UnityEngine.Object> AssetDic;

    void Awake()
    {
        if (Instance == null)
            Instance = gameObject.GetComponent<AssetManager>();
        AssetDic = new Dictionary<string, Object>();
    }

    void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        string tempResName = "Cube";
        AssetManager.Instance.AssetAdd<GameObject>(AssetType.Model, tempResName);
        GameObject test = AssetManager.Instance.AssetGet<GameObject>(tempResName) as GameObject;
        Instantiate(test);
    }
    /// <summary>
    /// 资源添加方法
    /// </summary>
    /// <typeparam name="T">要添加资源的类型</typeparam>
    /// <param name="type">该资源在目录下的枚举路径名称</param>
    /// <param name="name">资源名</param>
    public void AssetAdd<T>(AssetType type, string name) where T : UnityEngine.Object
    {
        GameObject temp = Resources.Load(type.ToString() + "/" + name) as GameObject;
        AssetDic.Add(typeof(T).ToString() + "name", temp);
    }

    /// <summary>
    /// 资源取得方法
    /// </summary>
    /// <typeparam name="T">Unity对象</typeparam>
    /// <param name="name">资源名称</param>
    /// <returns>返回字典里的对象</returns>
    public UnityEngine.Object AssetGet<T>(string name) where T : UnityEngine.Object
    {
        UnityEngine.Object obj = AssetDic[typeof(T).ToString() + "name"];
        return obj;
    }

}
