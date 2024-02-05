/// <summary>
/// Saving and reading the data from the file: 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// using binary gives us more functionality; 
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

public class DataManagement : MonoBehaviour
{
    public static DataManagement data;
    public int highScore;
    private string path = Application.persistentDataPath + "gameInfo.dat";
    private void Awake()
    {
        if(data == null)
        {
            DontDestroyOnLoad(data);
            data = this; 
        } 
        else if(data != this)
        {
            Destroy(gameObject); 
        }
    }

    // Methods below can be accessed anywhere from the game: 
    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Create(path);
        GameData gameData = new GameData();
        gameData.highScore = highScore;
        // Serialization - the process of converting the physical data to the format we can transfer and pass over network.
        // Each gameObject is serialized as a whole which may reference to other objects that 
        // are serialized too. 
        BinForm.Serialize(file, gameData);
        file.Close(); 
    }

    /// <summary>
    /// Opening file: Functions: open file, readonly, non-share
    /// </summary>
    public void LoadData()
    {
        using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            // Deserialization - the process of recreating the physical data from the the (say binary format) 
            GameData gameData = (GameData)BinForm.Deserialize(stream);
            stream.Close();
            highScore = gameData.highScore; 
        }
    }
}

// we can imagine following as the serializable meaning we can change it ?
// we use Serializable to make a claim that it might be converted to the form
[Serializable]
class GameData
{
    public int highScore; 
}

