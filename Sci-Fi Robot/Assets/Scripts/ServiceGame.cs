using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ServiceGame : MonoBehaviour {

    //public GameObject panelLoading;
    public GameObject panelImages;
	// Use this for initialization
	void Start () {
		
	}

    IEnumerator ItemGame()
    {
        string url = "http://localhost:8080/jsonGame";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
        }
        else
        {
            //panelLoading.SetActive(false);
            string data = www.downloadHandler.text;
            var json = JSON.Parse(data);
            int id = int.Parse(json["id"]);
            Sprite img = panelImages.GetComponent<ItemImage>().lstImages[id];
            Debug.Log(json["id"]);
            Debug.Log(json["description"]);
            Debug.Log(json["image"]);
            Debug.Log(json["name"]);
        }
    }
    void Awake()
    {
        //btnShare.onClick.AddListener(() => {

            StartCoroutine(ItemGame());
        //});
    }
}
