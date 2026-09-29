using UnityEngine;

namespace Skillveri
{
    [CreateAssetMenu(fileName = "IntractableInfoSO", menuName = "Scriptable Objects/IntractableInfoSO")]
    public class IntractableInfoSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField ,TextArea] public string Info { get; private set; }
    }
}
