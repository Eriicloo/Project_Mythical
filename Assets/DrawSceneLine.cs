using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aquest script tant sols fa que es dibuixe una linea que anira desde la plataforma movil fins el seu objectiu.
//Es un script que serveix per fer debugg, res mes
public class DrawSceneLine : MonoBehaviour
{

    public Transform from;
    public Transform to;

    void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.08f);
            Gizmos.DrawSphere(to.position, 0.08f);
        }
    }
}