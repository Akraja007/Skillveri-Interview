using UnityEngine;

namespace Skillveri
{
    public class Intractable : MonoBehaviour, IIntractable<IntractableInfoSO>
    {
        [SerializeField] private IntractableInfoSO IntractableInfo;

        public IntractableInfoSO Interact() => IntractableInfo;
    }
}
