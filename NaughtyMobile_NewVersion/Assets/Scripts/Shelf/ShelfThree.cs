using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfThree : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<IOpenShelfThree>();
        target?.OpenShelfThree();
    }
}
