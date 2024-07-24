using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scr_Enemy_EnemyFactory: MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    private List<scr_Enemy> _listOfEnemys;

    void Awake()
    {
        V_InstaniateEnemy();
    }

    public void V_InstaniateEnemy()
    {
        Vector3Int randomPosition = GetRandomPositionInTilemap();
        Instantiate(_enemyPrefabs[0], _tilemap.CellToWorld(randomPosition) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
    }

    public void V_DestriyAllEnemies()
    {

    }

    Vector3Int GetRandomPositionInTilemap()
    {
        BoundsInt bounds = _tilemap.cellBounds;

        if (_tilemap.GetUsedTilesCount() == 0)
        {
            Debug.LogError("Tilemap has no tiles. Please add tiles to the tilemap.");
            return Vector3Int.zero;
        }

        // Get the minimum and maximum positions within the tilemap
        int minX = bounds.xMin;
        int maxX = bounds.xMax;
        int minY = bounds.yMin;
        int maxY = bounds.yMax;

        Vector3Int randomPosition;

        // Randomly select a tile position that contains a tile
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
