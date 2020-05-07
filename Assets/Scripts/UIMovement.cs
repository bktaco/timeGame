using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    private Transform _moveSlotContainer;
    private Transform _moveTemplate;
    private MovementQueue _movementQueue;
    private int x = 0;
    private int y = 0;

    private void Awake()
    {
        _moveSlotContainer = transform.Find("moveSlotContainer");
        _moveTemplate = _moveSlotContainer.Find("moveTemplate");
    }

    public void SetMovementQueue(MovementQueue movementQueue)
    {
        _movementQueue = movementQueue;

        movementQueue.OnMovementListChanged += MovementQueue_OnMovementListChanged;

        //RefreshMovementQueue();
    }

    private void MovementQueue_OnMovementListChanged(object sender, EventArgs e)
    {
        RefreshMovementQueue();
    }

    private void RefreshMovementQueue()
    {
        
        float slotCellSize = 50f;
        
        RectTransform moveRectTransform = Instantiate(_moveTemplate, _moveSlotContainer).GetComponent<RectTransform>();
        TextMeshProUGUI uiText = moveRectTransform.GetComponent<TextMeshProUGUI>();
        moveRectTransform.gameObject.SetActive(true);

        var move = _movementQueue.GetLatestMove();

        if(move.x < 0)
        {
            uiText.text = "Left";
        }
        else
        {
            uiText.text = "Right";
        }
        

        moveRectTransform.anchoredPosition = new Vector2(x * slotCellSize, y * slotCellSize);
        
        y--;
        
        
    }
}
