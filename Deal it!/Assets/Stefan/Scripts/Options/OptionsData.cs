using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[System.Serializable]
public class OptionsData
{
    private const string SAVE_FILE_NAME = "Options.json";

    private static readonly OptionsData m_DefaultOptions = new OptionsData ( )
    {
        resolutionIndex = 1,
        fullScreen = true,
        mainVolume = 1,
        musicVolume = 1,
        sfxVolume = 1,
        fov = 80,
        sensitivity = 25,
    };

    public int resolutionIndex;
    public bool fullScreen;

    public float mainVolume;
    public float musicVolume;
    public float sfxVolume;
    public float fov;
    public float sensitivity;

    private static OptionsData m_saved;

    public static OptionsData Saved
    {
        get
        {
            if(m_saved == null)
            {
                string path = Path.Combine (Application.persistentDataPath, SAVE_FILE_NAME);

                if ( File.Exists (path) )
                {
                    string json = File.ReadAllText (path);

                    var data = JsonUtility.FromJson<OptionsData> (json);

                    if ( data != null )
                    {
                        m_saved = data;
                    }
                    else
                    {
                        m_saved = m_DefaultOptions;
                    }
                }
                else
                {
                    m_saved = m_DefaultOptions;
                }
            }
            return m_saved;
        }
    }


    public void Save ( )
    {

        string json = JsonUtility.ToJson (this, true);

        string path = Path.Combine (Application.persistentDataPath, SAVE_FILE_NAME);

        File.WriteAllText (path, json);

        m_saved = this;

        Debug.Log ("SAved Options!");
    }
}
