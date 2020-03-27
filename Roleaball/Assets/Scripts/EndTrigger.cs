using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManage gameManager;
    private void OnTriggerEnter(Collider target)
    {
        gameManager.CompleteLevel();
    }
}
