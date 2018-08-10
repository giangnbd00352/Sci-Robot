using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ServiceGame : MonoBehaviour {

    public GameObject panelLoading;
    public GameObject panelDescription;
    public ScrollRect BulletScrollView;
    public GameObject lstLibraries;
    public GameObject BagUI;
    public Button Select;
    // public GameObject bulletSpieces;

    RobotController robot;
    // Use this for initialization
    void Start () {
        robot = FindObjectOfType<RobotController>();
        panelDescription.transform.GetChild(0).GetComponent<Image>().sprite = lstLibraries.GetComponent<ItemImage>().lstImages[0];
        GameObject newBullet = lstLibraries.GetComponent<lstBullets>().Bullets[0];
        newBullet.GetComponent<Bullet>().bulletSpeed = 25;
        newBullet.GetComponent<Bullet>().bulletDamage = 15;
        robot.bullet = newBullet;        
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
            //Debug.Log("Load");
            panelLoading.SetActive(false);
            string data = www.downloadHandler.text;
            var json = JSON.Parse(data);
            JSONArray items = (JSONArray)json;
            // Debug.Log("object json:" + items.Count);
            for(int i=1;i< BulletScrollView.transform.GetChild(0).GetChild(0).childCount;i++)
            {
                //Debug.Log("Destroy:" + BulletScrollView.transform.GetChild(0).GetChild(0).transform.name);
                Destroy(BulletScrollView.transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
            }
            for (int i = 0; i < items.Count; i++)
            {
                string id = json[i]["id"];
                string name = json[i]["name"];
                string damage = json[i]["damage"];
                string image = json[i]["image"];
                string speed = json[i]["speed"];

                Transform newBorder;
                newBorder = Instantiate(BulletScrollView.transform.GetChild(0).GetChild(0).GetChild(0), BulletScrollView.transform.GetChild(0).GetChild(0).transform);
                newBorder.gameObject.SetActive(true);

                newBorder.GetChild(0).GetComponent<Image>().sprite = lstLibraries.GetComponent<ItemImage>().lstImages[int.Parse(id)];
                newBorder.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                {
                    panelDescription.SetActive(true);
                    panelDescription.transform.GetChild(0).GetComponent<Image>().sprite = lstLibraries.GetComponent<ItemImage>().lstImages[int.Parse(id)];
                    panelDescription.transform.GetChild(1).GetComponent<Text>().text = "Name: " + name;
                    panelDescription.transform.GetChild(2).GetComponent<Text>().text = "Damage: " + damage;
                    panelDescription.transform.GetChild(3).GetComponent<Text>().text = "Speed: " + speed;
                    Select.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        GameObject newBullet = lstLibraries.GetComponent<lstBullets>().Bullets[int.Parse(image)];
                        newBullet.GetComponent<Bullet>().bulletSpeed = float.Parse(speed);
                        newBullet.GetComponent<Bullet>().bulletDamage = float.Parse(damage);
                        robot.bullet = newBullet;
                        robot.RobotAction = true;
                    });

                });
            }
        }
    }
    public void Load()
    {
        Debug.Log("Start Load");
         StartCoroutine(ItemGame());
    }
}
