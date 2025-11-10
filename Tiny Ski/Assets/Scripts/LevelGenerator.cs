using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    /// <summary>
    /// Singleton de LevelGenerator
    /// </summary>
    private static LevelGenerator instance;

    public List<GameObject> pieces;

    private void Awake()
    {
        // Inicialización del singleton
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddNewPiece(Vector3 spawnPosition)
    {
        Instantiate(instance.pieces[Random.Range(0, instance.pieces.Count)], spawnPosition, Quaternion.identity);
    }
}
