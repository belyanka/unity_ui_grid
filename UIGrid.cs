using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGrid : MonoBehaviour
{
    public Color _mainColor = new Color(0f,1f,0f,0.5f);
    public Color _secondaryColor = new Color(0f,1f,0f,0.2f);
    public float _gridSize = 18f;
    public float _xOffset = 0f;
    public float _yOffset = 0f;

    private void OnDrawGizmos()
    {
        RectTransform rect = transform as RectTransform;

        float height = rect.rect.height;
        float width = rect.rect.width;

        float xOffset = rect.position.x - width / 2 + _xOffset;
        float yOffset = rect.position.y - height / 2 + _yOffset;

        float gridCurrent = height;
        int lineCounter = 0;

        if (_gridSize < 4)
        {
            Debug.LogError("Grid size is too small!");
            return;
        }

        while (gridCurrent > 0)
        {
            if (lineCounter == 10)
            {
                Gizmos.color = _mainColor;
                lineCounter = 0;
            }
            else
            {
                Gizmos.color = _secondaryColor;
            }
            Gizmos.DrawLine(new Vector3(0f + xOffset, gridCurrent + yOffset),
                new Vector3(width + xOffset, gridCurrent + yOffset));
            gridCurrent -= _gridSize;
            lineCounter++;
        }

        gridCurrent = 0f;
        lineCounter = 0;
        while (gridCurrent < width)
        {
            if (lineCounter == 10)
            {
                Gizmos.color = _mainColor;
                lineCounter = 0;
            }
            else
            {
                Gizmos.color = _secondaryColor;
            }
            Gizmos.DrawLine(new Vector3(gridCurrent + xOffset, height + yOffset),
                new Vector3(gridCurrent + xOffset, 0f + yOffset));
            gridCurrent += _gridSize;
            lineCounter++;
        }
    }
}