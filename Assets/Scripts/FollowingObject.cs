using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform pulmonaryVeinAnchor;

    // Declare as vari�veis para o offset
    public Vector3 positionOffset; // Deslocamento de posi��o
    public Vector3 rotationOffset; // Deslocamento de rota��o

    void Update()
    {
        if (pulmonaryVeinAnchor != null)
        {
            transform.position = pulmonaryVeinAnchor.position + positionOffset;
            transform.rotation = pulmonaryVeinAnchor.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}
