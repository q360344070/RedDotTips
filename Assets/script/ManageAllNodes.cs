using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManageAllNodes
{

    private static ManageAllNodes intima;
    public Dictionary<string, node> dictionNodes;
    public Dictionary<string, int> SameKeyIndex;
    public static ManageAllNodes GetManageAllNodes
    {
        get
        {
            if (intima == null)
            {
                intima=new ManageAllNodes();
                intima.dictionNodes=new Dictionary<string, node>();
                intima.SameKeyIndex = new Dictionary<string, int>();
            }
            return intima;
        }

        set
        {
            intima = value;
        }
    }
    /// <summary>
    /// 获取红点提示节点
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public node GetNode(string name)
    {
        if (dictionNodes.ContainsKey(name))
        {
            return dictionNodes[name];
        }
        return null;
    }
    /// <summary>
    /// 删除销毁的节点
    /// </summary>
    /// <param name="name"></param>
    public void Delete(string name)
    {
        if (dictionNodes.ContainsKey(name))
        {
            dictionNodes.Remove(name);
        }
    }
}
