using UnityEngine;

namespace Skillveri
{

    public class TableRow : MonoBehaviour
    {
        [SerializeField] private Transform cellContainer;
        [SerializeField] private TableCell cellPrefab;

        public void Initialize(int columnCount, bool isHeader)
        {
            ClearCells();

            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                TableCell cell = Instantiate(cellPrefab, cellContainer);
                cell.Initialize(columnIndex, isHeader);
            }
        }

        private void ClearCells()
        {
            for (int i = cellContainer.childCount - 1; i >= 0; i--)
            {
                Destroy(cellContainer.GetChild(i).gameObject);
            }
        }
    }

}
