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

    [Header("Static Wall")]
    [SerializeField] private Vector2 spawnStaticWall;
    [SerializeField] private Vector2 spawnStaticWall2;
    [SerializeField] private int staticWallDimension;



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

                if (x == 0 && y == 0)
                {
                    for (int i = 0; i < staticWallDimension; i++)
                    {
                        Vector2 spawnStaticWallPos = (Vector2.right * i) + spawnStaticWall;
                        Instantiate(wallPrefab, spawnStaticWallPos, Quaternion.identity, this.transform);

                        if (i >= staticWallDimension - 1)
                        {
                            for (int a = 0; a < staticWallDimension; a++)
                            {
                                Vector2 spawnStaticWallPos2 = (Vector2.up * a) + spawnStaticWall2;
                                Instantiate(wallPrefab, spawnStaticWallPos2, Quaternion.identity/*, this.transform*/);
                            }

                        }
                    }

                    for (int j = 0; j < staticWallDimension; j++)
                    {
                        Vector2 spawnStaticWallPos = (Vector2.down * j) + spawnStaticWall;
                        Instantiate(wallPrefab, spawnStaticWallPos, Quaternion.identity, this.transform);

                        if (j >= staticWallDimension - 1)
                        {
                            for (int b = 0; b < staticWallDimension; b++)
                            {
                                Vector2 spawnStaticWallPos2 = (Vector2.left * b) + spawnStaticWall2;
                                Instantiate(wallPrefab, spawnStaticWallPos2, Quaternion.identity/*, this.transform*/);
                            }

                        }
                    }
                }

            }
        }
    }
}
