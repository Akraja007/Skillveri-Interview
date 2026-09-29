using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skillveri
{

public class DynamicTable : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private TMP_InputField  rowInput;
    [SerializeField] private TMP_InputField  columnInput;
    [SerializeField] private Toggle headerToggle;

    [Header("Table")]
    [SerializeField] private Transform tableContainer;
    [SerializeField] private TableRow rowPrefab;
    [SerializeField] private TableRow headerPrefab;

    public void GenerateTable()
    {
        ClearTable();

        if (!TryGetTableSize(out int rows, out int columns))
            return;

        if (headerToggle.isOn)
        {
            TableRow header = Instantiate(headerPrefab, tableContainer);
            header.Initialize(columns, true);
        }

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            TableRow row = Instantiate(rowPrefab, tableContainer);
            row.Initialize(columns, false);
        }
    }

    private bool TryGetTableSize(out int rows, out int columns)
    {
        bool validRows = int.TryParse(rowInput.text, out rows);
        bool validColumns = int.TryParse(columnInput.text, out columns);

        Debug.Log(rowInput.text);
        Debug.Log(columnInput.text);
        if (!validRows || !validColumns)
        {
            Debug.LogWarning("Rows and columns must be valid numbers.");
            return false;
        }

        if (rows <= 0 || columns <= 0)
        {
            Debug.LogWarning("Rows and columns must be greater than zero.");
            return false;
        }

        return true;
    }

    private void ClearTable()
    {
        for (int i = tableContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(tableContainer.GetChild(i).gameObject);
        }
    }
}

}
