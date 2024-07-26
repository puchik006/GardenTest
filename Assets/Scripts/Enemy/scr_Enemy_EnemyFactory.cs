using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scr_Enemy_EnemyFactory: MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private List<scr_Enemy> _enemyPrefabs;
    private List<scr_Enemy> _listOfEnemys = new();
    private const int MAX_QUANTITY_OF_ENEMIES = 3;

    /// <summary>
    /// Instantiate randomly on map some quantity of enemies
    /// </summary>
    public void V_InstaniateEnemies()
    {
        for (int i = 0; i < MAX_QUANTITY_OF_ENEMIES; i++)
        {
            int enemyIndex = Random.Range(0, _enemyPrefabs.Count);
            Vector3Int randomPosition = GetRandomPositionInTilemap();
            _listOfEnemys.Add(Instantiate(_enemyPrefabs[enemyIndex], _tilemap.CellToWorld(randomPosition), Quaternion.identity));
        }
    }

    public void V_DestroyAllEnemies()
    {
        _listOfEnemys.ForEach(e => Destroy(e.gameObject));
        _listOfEnemys.Clear();
    }

    Vector3Int GetRandomPositionInTilemap()
    {
        BoundsInt bounds = _tilemap.cellBounds;

        if (_tilemap.GetUsedTilesCount() == 0)
        {
            Debug.LogError("Tilemap has no tiles. Please add tiles to the tilemap.");
            return Vector3Int.zero;
        }

        int minX = bounds.xMin;
        int maxX = bounds.xMax;
        int minY = bounds.yMin;
        int maxY = bounds.yMax;

        Vector3Int randomPosition;

        do
        {
            int randomX = Random.Range(minX, maxX);
            int randomY = Random.Range(minY, maxY);
            randomPosition = new Vector3Int(randomX, randomY, 0);
        }
        while (!_tilemap.HasTile(randomPosition));

        return randomPosition;
    }
}
