using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject prefabsToInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabsToInstantiate, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
