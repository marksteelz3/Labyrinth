using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {


	public MazeCell cellPrefab;

	private MazeCell[,] cells;

	public float generationDelay;

	public IntVector2 size;

	public MazePassage passagePrefab;
	public MazeWall wallPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public MazeCell GetCell (IntVector2 coordinates) {
		return cells [coordinates.x, coordinates.y];
	}

	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds (generationDelay);
		cells = new MazeCell[size.x, size.y];
		List <MazeCell> activeCells = new List <MazeCell> ();
		DoFirstGenerationStep (activeCells);
		while (activeCells.Count > 0) {
			yield return delay;
			DoNextGenerationStep (activeCells);
		}

		/*
		IntVector2 coordinates = RandomCoordinates;
				while (ContainsCoordinates (coordinates) && GetCell (coordinates) == null) {
			yield return delay;
			CreateCell (coordinates); 
					coordinates += MazeDirections.RandomValue.ToIntVector2();
		}
		*/

	}

	void DoFirstGenerationStep (List<MazeCell> activeCells) {
		activeCells.Add (CreateCell (RandomCoordinates));
	}

	void DoNextGenerationStep (List <MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells [currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt (currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		if (ContainsCoordinates (coordinates)) {
			MazeCell neighbor = GetCell (coordinates);
			if (neighbor == null) {
				neighbor = CreateCell (coordinates);
				CreatePassage (currentCell, neighbor, direction);
				activeCells.Add (neighbor);
			} else {
				CreateWall (currentCell, neighbor, direction);
			}
		} 
		else {
			CreateWall (currentCell, null, direction);
		}
	}

	private MazeCell CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate<MazeCell> (cellPrefab);
		cells [coordinates.x, coordinates.y] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "MazeCell " + coordinates.x + ", " + coordinates.y;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3 (coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.y - size.y * 0.5f + 0.5f);
		return newCell;
	}

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2 (Random.Range (0, size.x), Random.Range (0, size.y));
		}
	}

	public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.y >= 0 && coordinate.y < size.y;
	}

	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage passage = Instantiate <MazePassage> (passagePrefab);
		passage.Initialize (cell, otherCell, direction);
		passage = Instantiate <MazePassage> (passagePrefab);
		passage.Initialize (otherCell, cell, direction.GetOpposite ());
	}

	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate <MazeWall> (wallPrefab);
		wall.Initialize (cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate <MazeWall> (wallPrefab);
			wall.Initialize (otherCell, cell, direction.GetOpposite ());
		}
	}
}
