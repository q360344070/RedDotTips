using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class node : MonoBehaviour, NodeInterface
{

    [SerializeField]
    private string id;
    private int Whether;
    [SerializeField]
    private node Parent;
    [SerializeField]
    private List<node> ChildNodes;
    [SerializeField]
    private Image ico;
    [SerializeField]
    private int WithNodes;//1根节点
    private bool tmp;
    private bool isComplete=false;
    //返回false 不成功   true成功
    private UnityEngine.Events.UnityAction<bool> SuccessfulCall;
    /// <summary>
    /// 该节点是否已经关闭  1关闭  2打开
    /// </summary>
    public int Whether1
    {
        get
        {
            return Whether;
        }

        set
        {
            if (!Whether.Equals(value))
            {
                if (value == 1)
                {
                    tmp = true;
                    for (int i = 0; i < ChildNodes1.Count; i++)
                    {
                        if (ChildNodes[i].Whether1 == 2)
                        {
                            tmp = false;
                        }
                    }
                    if (tmp)
                    {
                        Whether = value;
                        if (ico != null)
                        {
                            ico.enabled = false;
                            CloseNode();
                        }
                        if (Parent != null)
                        {
                            Parent.Whether1 =1;
                        }
                        if (SuccessfulCall != null)
                        {
                            SuccessfulCall(true);
                            SuccessfulCall = null;
                        }
                    }
                }
                else if(value==2)
                {
                    Whether = value;
                    if (SuccessfulCall != null)
                    {
                        SuccessfulCall(true);
                        SuccessfulCall = null;
                    }
                    ico.enabled = true;
                    if (Parent != null)
                    {
                        Parent.Whether1 = 2;
                    }
                }
            }
            else
            {
                if (SuccessfulCall != null)
                {
                    SuccessfulCall(false);
                    SuccessfulCall = null;
                }
            }
        }
    }
    /// <summary>
    /// 该节点的标号
    /// </summary>
    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
    /// <summary>
    ///  父节点
    /// </summary>
    public node Parent1
    {
        get
        {
            return Parent;
        }

        set
        {
            Parent = value;
        }
    }

    public List<node> ChildNodes1
    {
        get
        {
            return ChildNodes;
        }

        set
        {
            ChildNodes = value;
        }
    }
    /// <summary>
    /// 1 是根节点 ，默认是0 
    /// </summary>
    public int WithNodes1
    {
        get
        {
            return WithNodes;
        }

        set
        {
            WithNodes = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        ico = transform.Find("RedDotPicture").GetComponent<Image>();
        if (ico == null)
        {
            //红点图标为空
            Debug.LogError("Red dot icon is empty,not find  name RedDotPicture");
        }
        ico.enabled = false;
        Whether1 = 1;
        initialization();
        isComplete = true;
    }
    public void initialization()
    {
        if (!ManageAllNodes.GetManageAllNodes.dictionNodes.ContainsKey(id))
        {
            ManageAllNodes.GetManageAllNodes.dictionNodes[id] = this;
        }
        else
        {
            //Already have the same key in the dictionary
            if (ManageAllNodes.GetManageAllNodes.SameKeyIndex.ContainsKey(id))
            {
                int index = ManageAllNodes.GetManageAllNodes.SameKeyIndex[id];
                index++;
                ManageAllNodes.GetManageAllNodes.dictionNodes[id + "_" + index] = this;
                ManageAllNodes.GetManageAllNodes.SameKeyIndex[id] = index;
                id = id + "_" + index;
            }
            else
            {
                ManageAllNodes.GetManageAllNodes.SameKeyIndex[id] = 0;
                int index = ManageAllNodes.GetManageAllNodes.SameKeyIndex[id];
                ManageAllNodes.GetManageAllNodes.dictionNodes[id+"_"+ index] = this;
                id = id + "_" + index;
            }
        }
    }

    public void CloseNode()
    {
        
    }

    public void OpenNode(UnityEngine.Events.UnityAction<bool> callUnityAction=null)
    {
        SuccessfulCall = null;
        SuccessfulCall = callUnityAction;
        Whether1 = 2;
    }
    public void shutDown(UnityEngine.Events.UnityAction<bool> callUnityAction=null)
    {
        SuccessfulCall = null;
        SuccessfulCall = callUnityAction;
        Whether1 = 1;
    }
}
