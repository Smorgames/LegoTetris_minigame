using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private int _horizontalSize;
    [SerializeField] private int _verticalSize;

    [SerializeField] private GameObject _cellSpawnObject;
    [SerializeField] private float _cellSize;
    [SerializeField] private Vector2 _offset;

    private SpawnPosition _spawnPosition = new SpawnPosition();

    private GameField _gameField; public GameField GameField { get { return _gameField; } }

    #region Singleton
    public static GameMaster instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

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
                GameObject cellGameObject = 
                Instantiate(spawnObject, new Vector2(i, j) * spawnPosition.CellSize + spawnPosition.Offset, angle);

                cellGameObject.transform.SetParent(transform);
                cellGameObject.GetComponent<CellSpriteController>().ChangeCellSprite(counter % 2);

                Cell cell = cellGameObject.GetComponent<Cell>();

                _gameField.AddCell(i, j, cell);
                cell.SetXYCoordinates(i, j);

                counter++;
            }

        counter++;
        }
    }
}