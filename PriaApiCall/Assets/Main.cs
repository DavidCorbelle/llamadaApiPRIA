using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] parameters= {"amount=10"};
        StartCoroutine(petitionGet("https://opentdb.com/api.php", parameters));
        
    }

    IEnumerator petitionGet(string uri, string[] parameters){
        string petition=uri+"?";
       for (int i = 0; i < parameters.Length; i++)
          {
             petition+=parameters[i];
                if(parameters.Length!=(i+1)){
                  petition+="&";
            }   
          }
    using (UnityWebRequest webRequest = UnityWebRequest.Get(petition))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
