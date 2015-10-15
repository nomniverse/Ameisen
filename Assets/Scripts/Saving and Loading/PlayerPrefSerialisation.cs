using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerPrefSerialisation {

    public static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void Save(string key, object obj)
    {
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);

        string temp = System.Convert.ToBase64String(memoryStream.ToArray());
        PlayerPrefs.SetString(key, temp);
    }

    public static object Load(string key)
    {
        string temp = PlayerPrefs.GetString(key);
        
        if (temp == string.Empty)
        {
            return null;
        }

        MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(temp));
        return binaryFormatter.Deserialize(memoryStream);
    }
}
