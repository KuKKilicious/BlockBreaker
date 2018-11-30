using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("duplicate music player destroying itself");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        Debug.Log("Music player awake" + GetInstanceID());
    }
    // Use this for initialization
    void Start () {
        Debug.Log("Music player start" + GetInstanceID());

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
