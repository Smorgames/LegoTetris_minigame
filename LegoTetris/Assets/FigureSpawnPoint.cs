using UnityEngine;

public class FigureSpawnPoint : MonoBehaviour
{
    public int Index { get; set; }
    public bool HasFigure { get; set; }

    public FigureSpawner FigureSpawnerObject { get; set; }

    public void SpawnRandomFigure()
    {
        HasFigure = false;
        FigureSpawnerObject.SpawnRandomFigureInPoint(Index);
    }
}
