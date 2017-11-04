using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RedDotConfiguration : MonoBehaviour {

    [MenuItem("Assets/Add child nodes")]
    static void Init()
    {
        Dictionary<node,List<node>> ChildNodeCollection = new Dictionary<node, List<node>>();
        node[] RedDotCons = GameObject.FindObjectsOfType<node>();
        for (int i = 0; i < RedDotCons.Length; i++)
        {
            if (RedDotCons[i].Parent1 != null)
            {
                if (!ChildNodeCollection.ContainsKey(RedDotCons[i].Parent1))
                {
                    ChildNodeCollection[RedDotCons[i].Parent1] = new List<node>();
                    ChildNodeCollection[RedDotCons[i].Parent1].Add(RedDotCons[i]);
                }
                else
                {
                    ChildNodeCollection[RedDotCons[i].Parent1].Add(RedDotCons[i]);
                }
            }
            else
            {
                if (RedDotCons[i].WithNodes1 == 0 && RedDotCons[i].Parent1 == null)
                {
                    Debug.LogError(RedDotCons[i].name + "The parent node has no assignment");
                }
            }
        }
        var e = ChildNodeCollection.GetEnumerator();
        while (e.MoveNext())
        {
            e.Current.Key.ChildNodes1 = e.Current.Value;
        }
        AssetDatabase.SaveAssets();//保存所有更改的资源
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());//保存当前场景
        AssetDatabase.Refresh();//刷新资源
        Debug.Log("Configuration data processing is completed");
    }
}
