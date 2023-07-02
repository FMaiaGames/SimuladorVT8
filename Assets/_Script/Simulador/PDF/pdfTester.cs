using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pdfTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(openPDF());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator openPDF()
    {
        var path = "http://filipemaia.com/acervo/etapa.pdf";
        var savePath = Application.persistentDataPath;

        WWW www = new WWW(path);
        yield return www;
        var error = www.error;

        byte[] bytes = www.bytes;
        var result = "File size : " + bytes.Length;

        try
        {
            System.IO.File.WriteAllBytes(savePath + "/test.pdf", bytes);
            error = "No Errors so far";
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }

        Application.OpenURL("http://filipemaia.com/acervo/etapa.pdf");
    }


}
