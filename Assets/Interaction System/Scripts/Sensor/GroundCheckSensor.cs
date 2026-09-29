using UnityEngine;

namespace Skillveri
{
    public class GroundCheckSensor : MonoBehaviour, ISensor<Collider>
    {
        [SerializeField] private float rayLength = 3;
        [SerializeField] private Vector3 rayDirection = Vector3.down;
        [SerializeField] private LayerMask layerMask;

        [SerializeField] private bool visualize;
        private RaycastHit[] _raycastHits = new RaycastHit[1];
        void Start()
        {

        }

        public bool TryDetect(out Collider result)
        {
            Ray ray = new(transform.position, rayDirection);

            int hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, rayLength, layerMask);

            if (hitCount > 0)
            {
                result = _raycastHits[0].collider;
                return true;
            }

            result = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            if (!visualize)return;

            Gizmos.DrawLine(
                transform.position,
                transform.position + rayDirection.normalized * rayLength
            );
        }
    }
}
