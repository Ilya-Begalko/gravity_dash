using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTransformCube : MonoBehaviour
{
    public void Transform()
    {
        transform.position = new Vector3(-1f, -1.5f, 0f);
        transform.localScale = new Vector3(2f, 2f, 2f);
    }
}
