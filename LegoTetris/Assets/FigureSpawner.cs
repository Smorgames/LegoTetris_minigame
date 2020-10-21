using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject[] figures;

    private void Awake()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].GetComponent<FigureSpawnPoint>().Index = i;
            spawnPoints[i].GetComponent<FigureSpawnPoint>().FigureSpawnerObject = this;
        }
    }

    private void Start()
    {
        SpawnRandomFigureInAllPoints();
    }

    public void SpawnRandomFigureInAllPoints()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
            SpawnRandomFigureInPoint(i);
    }

    public void SpawnRandomFigureInPoint(int index)
    {
        GameObject figure = (GameObject)Instantiate(figures[Random.Range(0, figures.Length)], spawnPoints[index].position, Quaternion.identity);
        figure.GetComponent<Figure>().SpawnPoint = spawnPoints[index].GetComponent<FigureSpawnPoint>();

        spawnPoints[index].GetComponent<FigureSpawnPoint>().HasFigure = true;
    }
}
