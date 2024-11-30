using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Loadinger : MonoBehaviour
{
    public float waitingTime;

    private float tiemr;

    public string SceneIndex;

    private void LateUpdate()
    {
        tiemr += Time.deltaTime;
        if (tiemr > waitingTime) 
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(SceneIndex);
    }

    /*
        private void Awake()
        {
            if (SceneManager.GetActiveScene().name == "SceneLoading")
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
        }*/


}
