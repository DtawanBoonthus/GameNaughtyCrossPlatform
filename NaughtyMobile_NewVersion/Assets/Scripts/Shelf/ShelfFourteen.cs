using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfFourteen : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<IOpenShelfFourteen>();
        target?.OpenShelfFourteen();
    }
}
