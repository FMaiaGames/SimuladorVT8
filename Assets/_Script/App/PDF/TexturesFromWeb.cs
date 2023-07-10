using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Image = UnityEngine.UIElements.Image;
using UnityEngine.SceneManagement;

public class TexturesFromWeb : MonoBehaviour
{

    [SerializeField] private string urlStr;
    private string completeUrl;

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject panelPrefab;
    private GameObject tempPanel;
    private RectTransform tempRect;

    private Texture2D tempTex;
    private Sprite tempSprite;

    [SerializeField] private GameObject loadingIcon;


    void Start()
    {
        completeUrl = urlStr + $"{1}.png";

        DownloadTexture(completeUrl, 1);
    }

    async void DownloadTexture(string completeUrl, int pageNumber)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(completeUrl);
        request.SendWebRequest();

        while(!request.isDone){
            await Task.Yield();
        }

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {

            tempPanel = null;
            tempPanel = Instantiate(panelPrefab);
            tempPanel.transform.SetParent(content.transform);
            tempRect = tempPanel.GetComponent<RectTransform>();


            tempTex = null;
            tempTex = ((DownloadHandlerTexture)request.downloadHandler).texture;

            tempSprite = null;
            tempSprite = Sprite.Create(tempTex, new Rect(0, 0, tempTex.width, tempTex.height), Vector2.zero);
            tempSprite.name = pageNumber.ToString();
            tempPanel.GetComponent<UnityEngine.UI.Image>().sprite = tempSprite;


            tempRect.localScale = Vector3.one;

            content.GetComponent<RectTransform>().sizeDelta += new Vector2(0, Screen.width * 1.68f);



            pageNumber++;
            completeUrl = urlStr + $"{pageNumber}.png";
            DownloadTexture(completeUrl, pageNumber);


            if(loadingIcon.activeInHierarchy)
                loadingIcon.SetActive(false);

        }
    }

    public void ZoomIn()
    {
        content.transform.localScale += Vector3.one;
    }

    public void ZoomOut()
    {
        if(content.transform.localScale.x >= 2 )
            content.transform.localScale -= Vector3.one;
    }


}
