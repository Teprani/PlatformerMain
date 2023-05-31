using UnityEngine;

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update

    /*public static audioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }*/
    public void Music()
    {

            AudioSource[] audio = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audio)
            {
                a.Play();
            }
        //recuperer audio source get component
        GetComponent<AudioSource>().enabled = false;

    }
    
}
