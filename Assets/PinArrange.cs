using UnityEngine;

[ExecuteInEditMode] // Enables updates in Scene View without Play Mode
public class PinArrange : MonoBehaviour
{
    public Transform[] pins; // Assign your 10 pin objects in the Inspector
    public float pinSpacing = 1.1f; // Adjust spacing

    void OnValidate()
    {
        ArrangePins(); // Auto-update in Scene View
    }

    void ArrangePins()
    {
        if (pins.Length != 10)
        {
            Debug.LogError("Please assign exactly 10 pin objects in the Inspector.");
            return;
        }

        int pinIndex = 0;
        int rows = 4; // 4-row triangular bowling formation

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                if (pinIndex >= pins.Length) return; // Stop after placing all 10 pins

                float xOffset = (col - (row * 0.5f)) * pinSpacing; // Centers pins in row
                float zOffset = row * pinSpacing * 1.1f; // Staggered row spacing

                pins[pinIndex].position = new Vector3(xOffset, 0, zOffset);
                pinIndex++;
            }
        }
    }
}
