using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private int gridX;
    [SerializeField] private int gridY;
    Vector2[,] groundGrid;

    [Header("Wall")]
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private int wallGridX;
    [SerializeField] private int wallGridY;
    [SerializeField] private int wallOffset;
    Vector2[,] wallGrid;



    // Start is called before the first frame update
    void Start()
    {
        groundGrid = new Vector2[gridX, gridY];
        wallGrid = new Vector2[wallGridX, wallGridY];
        SpawnGround();
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGround()
    {
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridY; j++)
            {
                Vector2 spawnPos = Vector2.right * j + Vector2.down * i;
                groundGrid[i, j] = spawnPos;
                Instantiate(groundPrefab, spawnPos, Quaternion.identity, this.transform);
            }

        }
    }

    private void SpawnWall()
    {
        for (int x = 0; x < wallGridX; x++)
        {
            for (int y = 0; y < wallGridY; y++)
            {             
                Vector2 spawnWallPos = (Vector2.right * y * wallOffset + Vector2.down * x * wallOffset) + spawnPoint;
                wallGrid[x, y] = spawnWallPos;
                Instantiate(wallPrefab, spawnWallPos, Quaternion.identity, this.transform);
                
            }
        }
    }
}
