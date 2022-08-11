using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInputManager : MonoBehaviour
{
    public Text nameText;
    public Text addressText;

    List<Dictionary<string, object>> data_Dialog;

    void Awake()
    {
        data_Dialog = CSVReader.Read("starbucks_store_info");

        StartCoroutine(TextInputStart());
    }

    IEnumerator TextInputStart()
    {
        for (int i=0; i< data_Dialog.Count; i++)
        {
            nameText.text = data_Dialog[i]["매장명"].ToString();
            addressText.text = data_Dialog[i]["주소"].ToString();

            ScreenCapture.CaptureScreenshot("./Assets/Result/"+data_Dialog[i]["매장명"].ToString() + ".png");

            yield return new WaitForSeconds(0.1f);
        }
    }
}
