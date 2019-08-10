using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    // Start is called before the first frame update
    // Really basic, inefficient singleton pattern.
    private void Awake()
    {
        int numPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numPlayers > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }



}
