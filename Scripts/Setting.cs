﻿using System;
using UnityEngine;

namespace Bale007
{
    public static class Setting
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        public static string SAVE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
#elif UNITY_ANDROID || UNITY_IOS
    public static string SAVE_PATH = Application.persistentDataPath;
#endif
        public static readonly bool SHOW_DEBUG_MSG = true;
        public static readonly bool ENCRYPT_STRING = true;

        public static readonly string DOWNLOAD_KEY = "PULL_DATA";
        public static readonly string STRING_KEY = ""; //your private key value here
        public static readonly string STRING_IV = ""; //your private iv value here
    }
}