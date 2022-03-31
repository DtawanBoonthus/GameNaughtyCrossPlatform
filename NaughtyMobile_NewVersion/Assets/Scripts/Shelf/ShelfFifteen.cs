using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfFifteen : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<IOpenShelfFifteen>();
        target?.OpenShelfFifteen();
    }
}
