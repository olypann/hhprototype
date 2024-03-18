using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenMessages : MonoBehaviour
{
    public Text NewMoveText;

    public Text AvailableMoves;

    public bool newMovesBool;
    // Start is called before the first frame update
    void Start()
    {
        newMovesBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (newMovesBool)
        {
            
            NewMoveText.enabled = true;
/*            Invoke("DisableMoveText", 5f);
*/        }
        
    }

    /*void DisableMoveText()
    {
        NewMoveText.enabled = false;
    }*/
}
