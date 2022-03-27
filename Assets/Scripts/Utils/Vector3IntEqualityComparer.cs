using System;
using System.Collections.Generic;
using UnityEngine;
class Vector3IntEqualityComparer: IEqualityComparer<Vector3Int> {
    public bool Equals(Vector3Int v1, Vector3Int v2)
    {
        return v1.Equals(v2);
    }

    public int GetHashCode(Vector3Int vx)
    {
        return vx.GetHashCode();
    }
}