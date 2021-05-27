using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private List<Vector3> path;
    private int speed = 1;
    private int pathIndex = 0;
    private Transform characterPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        path = new List<Vector3>()
        {
            new Vector3(0, 0),
            new Vector3(2, 0),
            new Vector3(2, 2),
            new Vector3(0, 2)

        };

        characterPosition = (Transform) GetComponent("Transform");
        characterPosition.position = path[0];

    }

    // Update is called once per frame
    void Update()
    {
        var eps = 0.001;
        var start = path[pathIndex % path.Count];
        var end = path[(pathIndex+1)%path.Count];

        var diff = end - start;
        diff.Normalize();
        characterPosition.position += diff /500;

        if(math.abs(characterPosition.position.x-end.x) < eps && math.abs(characterPosition.position.y-end.y) < eps)
        {
            characterPosition.position = end;
            pathIndex++;
        }
    }
}
