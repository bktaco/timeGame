using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementQueue
{
	public event EventHandler OnMovementListChanged;
	private List<Vector2> moveList;

	public MovementQueue()
	{
		moveList = new List<Vector2>();
	}

	public void AddMove(Vector2 moveDir)
	{
		moveList.Add(moveDir);
		OnMovementListChanged?.Invoke(this, EventArgs.Empty);
	}

	public List<Vector2> GetMoveList()
	{
		return moveList;
	}

	public Vector2 GetLatestMove()
	{
		return moveList.Last();
	}
}
