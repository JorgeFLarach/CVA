using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Targeting : MonoBehaviour
{
    public Vector3 GetClosestTargetPosition(GameObject[] potentialTargets)
    {
        Vector3 closestPosition = Vector3.zero;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject target in potentialTargets)
        {
            float distance = Vector3.Distance(currentPosition, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPosition = target.transform.position;
            }
        }

        return closestPosition;
    }
}
