using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
    public int id;
    public int whsint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void colse()
    {
        if (whsint == 1)
        {
            ManageAllNodes.GetManageAllNodes.dictionNodes[id].shutDown(arg0 =>
            {
                if (arg0)
                {
                    Debug.Log("Change successfully");
                }
            });
        }
        else
        {
            ManageAllNodes.GetManageAllNodes.dictionNodes[id].OpenNode(arg0 =>
            {
                if (arg0)
                {
                    Debug.Log("Change successfully");
                }
            });
        }
    }
}
