using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfCollision : MonoBehaviour
{ 
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<ICollision>();
        target?.TakeCollision();
    }

    private void OnTriggerExit(Collider other)
    {
        var target = other.gameObject.GetComponent<ICollision>();
        target?.NotTakeCollision();
    }
}
