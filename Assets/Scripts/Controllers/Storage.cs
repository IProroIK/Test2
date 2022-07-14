using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class Storage
{
    private string filePath;
    private BinaryFormatter formatter;

    public Storage()
    {
        filePath = Application.persistentDataPath + "/saves/Saves.dt";
    }

    public object Load( object saveDataByDelault)
    {
        if(!File.Exists(filePath))
        {
            if(saveDataByDelault != null)
            {
                Save(saveDataByDelault);
            }
            return saveDataByDelault;
        }
        var file = File.Open(filePath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(filePath);
        formatter.Serialize(file, saveData);
        file.Close();
    }

    private void InitBinaryFormatter()
    {
        formatter = new BinaryFormatter();

    }
}
