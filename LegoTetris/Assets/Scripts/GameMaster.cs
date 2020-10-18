using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private int _horizontalSize;
    [SerializeField] private int _verticalSize;

    [SerializeField] private GameObject _cellSpawnObject;
    [SerializeField] private float _cellSize;
    [SerializeField] private Vector2 _offset;

    private SpawnPosition _spawnPosition = new SpawnPosition();

    private GameField _gameField;

    private void Start()
    {
        SetSpawnPosition();

        _gameField = new GameField(_horizontalSize, _verticalSize);

        CreateGameField(_cellSpawnObject, _spawnPosition, Quaternion.identity);
    }

    private void SetSpawnPosition()
    {
        _spawnPosition.CellSize = _cellSize;
        _spawnPosition.Offset = _offset;
    }

    public void CreateGameField(GameObject spawnObject, SpawnPosition spawnPosition, Quaternion angle)
    {
        int counter = 0;

        for (int i = 0; i < _horizontalSize; i++)
        {
            for (int j = 0; j < _verticalSize; j++)
            {
                GameObject cell = (GameObject)Instantiate(spawnObject, new Vector2(i, j) * spawnPosition.CellSize + spawnPosition.Offset, angle);
                cell.transform.SetParent(transform);
                cell.GetComponent<CellSpriteController>().ChangeCellSprite(counter % 2);
                counter++;
            }

        counter++;
        }
    }
}
