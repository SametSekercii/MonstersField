using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AttackRange))]
public class AttackRangeEditor : Editor
{
    private void OnSceneGUI()
    {

        AttackRange Range = (AttackRange)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(Range.transform.position, Vector3.up, Vector3.forward, 360, Range.viewRadius);
        Vector3 viewAngleA = Range.DirFromAngle(Range.viewAngle / 2, false);
        Vector3 viewAngleB = Range.DirFromAngle(-Range.viewAngle / 2, false);

        Handles.DrawLine(Range.transform.position, Range.transform.position + viewAngleA * Range.viewRadius);
        Handles.DrawLine(Range.transform.position, Range.transform.position + viewAngleB * Range.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in Range.targetsInRange)
        {
            Handles.DrawLine(Range.transform.position, visibleTarget.position);
        }

    }
}