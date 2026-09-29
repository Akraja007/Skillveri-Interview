using System.Collections.Generic;
using UnityEngine;

namespace Skillveri
{
    public class SimplePathFindStrategy : IPathFindStrategy
    {
        public List<Vector3> FindPath(Vector3 start, Vector3 target)
        {
            return new List<Vector3> { start, target };
        }
    }
}
