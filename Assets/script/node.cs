using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class node : MonoBehaviour, NodeInterface
{

    [SerializeField]
    private int id;
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
    public int Id
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
    void Start ()
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
	// Update is called once per frame
	void Update () {
		
	}
    public void initialization()
    {
        ManageAllNodes.GetManageAllNodes.dictionNodes[id] = this;
    }

    public void CloseNode()
    {
        if (isComplete&& ChildNodes1.Count<1)
        {
            //Debug.Log("关闭节点" + this.name);
        }
    }

    public void OpenNode(UnityEngine.Events.UnityAction<bool> callUnityAction)
    {
        SuccessfulCall = null;
        SuccessfulCall = callUnityAction;
        Whether1 = 2;
    }
    public void shutDown(UnityEngine.Events.UnityAction<bool> callUnityAction)
    {
        SuccessfulCall = null;
        SuccessfulCall = callUnityAction;
        Whether1 = 1;
    }
}
