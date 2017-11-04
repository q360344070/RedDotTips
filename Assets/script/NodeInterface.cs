using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NodeInterface
{
    /// <summary>
    /// 初始化
    /// </summary>
    void initialization();
    /// <summary>
    /// 关闭该节点
    /// </summary>
    void CloseNode();
}
