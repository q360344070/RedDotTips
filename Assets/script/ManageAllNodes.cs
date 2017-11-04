using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAllNodes
{

    private static ManageAllNodes intima;
    public Dictionary<int, node> dictionNodes; 
    public static ManageAllNodes GetManageAllNodes
    {
        get
        {
            if (intima == null)
            {
                intima=new ManageAllNodes();
                intima.dictionNodes=new Dictionary<int, node>();
            }
            return intima;
        }

        set
        {
            intima = value;
        }
    }
}
