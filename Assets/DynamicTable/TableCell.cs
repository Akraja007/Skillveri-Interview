using UnityEngine;
using TMPro;
namespace Skillveri
{

    public class TableCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Initialize(int columnIndex, bool isHeader)
        {
            text.text = isHeader
                ? $"Column {columnIndex + 1}"
                : string.Empty;
        }
    }

}
