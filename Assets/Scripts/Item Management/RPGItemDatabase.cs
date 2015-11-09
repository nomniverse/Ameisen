using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class RPGItemDatabase {

    public TextAsset itemInventory;
    public List<BaseItem> inventoryItems = new List<BaseItem>();

    private List<Dictionary<string, string>> inventoryItemsDictionary = new List<Dictionary<string, string>>();
    private Dictionary<string, string> inventoryDictionary;
    
    public RPGItemDatabase()
    {
        
    }

    public void LoadXML()
    {
        itemInventory = Resources.Load<TextAsset>("XML/ItemDatabase");
    }

    public void ReadItemFromDatabase()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(itemInventory.text);
        XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item");

        foreach(XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            inventoryDictionary = new Dictionary<string, string>();

            foreach(XmlNode content in itemContent)
            {
                inventoryDictionary.Add(content.Name, content.InnerText);
            }

            inventoryItemsDictionary.Add(inventoryDictionary);
        }

        for (int i = 0; i < inventoryItemsDictionary.Count; i++)
        {
            inventoryItems.Add(new BaseItem(inventoryItemsDictionary[i]));
            Debug.Log(inventoryItems[i].itemName);
        }
    }
}
