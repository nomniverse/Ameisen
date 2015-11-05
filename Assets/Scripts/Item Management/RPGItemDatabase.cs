using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class RPGItemDatabase : MonoBehaviour {

    public TextAsset itemInventory;
    public static List<BaseItem> inventoryItems = new List<BaseItem>();

    private List<Dictionary<string, string>> inventoryItemsDictionary = new List<Dictionary<string, string>>();
    private Dictionary<string, string> inventoryDictionary;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        ReadItemFromDatabase();

        for (int i = 0; i < inventoryItemsDictionary.Count; i++)
        {
            inventoryItems.Add(new BaseItem(inventoryItemsDictionary[i]));
            Debug.Log(inventoryItems[i].itemName);
        }
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
    }
}
