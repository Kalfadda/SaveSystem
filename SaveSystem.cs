namespace Scythe.Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;

    public static partial class SaveSystem
    {
        private static string defaultFileName = "savedata.json";

        // Internal list to hold all saved data
        private static List<SavedDataEntry> dataList = new List<SavedDataEntry>();

        // Load existing data from file at startup
        static SaveSystem()
        {
            LoadFromFile();
        }

        #region Save Methods

        /// <summary>
        /// Saves any serializable data.
        /// </summary>
        public static void SaveData<T>(string key, T value, string fileName = null)
        {
            string valueString = JsonUtility.ToJson(new SerializableValue<T>(value));
            string typeName = typeof(T).AssemblyQualifiedName;

            // Check if key exists
            int index = dataList.FindIndex(data => data.key == key);
            if (index >= 0)
            {
                dataList[index].value = valueString;
                dataList[index].typeName = typeName;
            }
            else
            {
                dataList.Add(new SavedDataEntry { key = key, value = valueString, typeName = typeName });
            }

            SaveToFile(fileName);
        }

        #endregion Save Methods

        #region Load Methods

        /// <summary>
        /// Loads any serializable data.
        /// </summary>
        public static T LoadData<T>(string key, T fallbackValue = default)
        {
            SavedDataEntry data = dataList.Find(d => d.key == key);
            if (data != null)
            {
                if (Type.GetType(data.typeName) == typeof(T))
                {
                    SerializableValue<T> serializableValue = JsonUtility.FromJson<SerializableValue<T>>(data.value);
                    return serializableValue.value;
                }
                else
                {
                    Debug.LogWarning($"Type mismatch for key '{key}'. Expected {typeof(T)}, but found {Type.GetType(data.typeName)}.");
                }
            }
            return fallbackValue;
        }

        #endregion Load Methods

        #region File Operations

        /// <summary>
        /// Saves the dataList to a file in JSON format.
        /// </summary>
        private static void SaveToFile(string fileName = null)
        {
            string path = Path.Combine(Application.persistentDataPath, fileName ?? defaultFileName);
            SavedDataList saveDataList = new SavedDataList { dataList = dataList };
            string json = JsonUtility.ToJson(saveDataList, true);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Loads the dataList from a file.
        /// </summary>
        private static void LoadFromFile()
        {
            string path = Path.Combine(Application.persistentDataPath, defaultFileName);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SavedDataList saveDataList = JsonUtility.FromJson<SavedDataList>(json);
                dataList = saveDataList.dataList;
            }
            else
            {
                dataList = new List<SavedDataEntry>();
            }
        }

        #endregion File Operations

        #region Serializable Classes

        [Serializable]
        private class SavedDataEntry
        {
            public string key;
            public string value;
            public string typeName;
        }

        [Serializable]
        private class SavedDataList
        {
            public List<SavedDataEntry> dataList;
        }

        [Serializable]
        private class SerializableValue<T>
        {
            public T value;

            public SerializableValue(T value)
            {
                this.value = value;
            }
        }

        #endregion Serializable Classes
    }
}