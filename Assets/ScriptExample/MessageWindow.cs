﻿using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    [SerializeField]
    ScriptEngine scriptEngine;

    public float interval = 0.05f;

    bool running = false;

    string message;
    float messageStartTime;

    int prevCursor;

    void Update()
    {
        if (running)
        {
            int cursor = (int)((Time.time - messageStartTime) / interval);
            if (cursor >= message.Length)
            {
                running = false;
                scriptEngine.NextCommand();
                return;
            }

            GetComponent<TextMesh>().text = message.Substring(0, cursor + 1);

            if (prevCursor != cursor)
            {
                prevCursor = cursor;
                char letter = message[cursor];
                if (letter != 32 && letter != 10)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public void StartMessage(string message)
    {
        this.message = message;
        messageStartTime = Time.time;
        running = true;
        prevCursor = -1;
    }
}

