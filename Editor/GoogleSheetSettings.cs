using System;
using UnityEditor;
using UnityEngine;

namespace GoogleSheetsUnity.Editor
{
    internal sealed class GoogleSheetSettings : ScriptableObject
    {
        [SerializeField] private string _googleApplicationName = string.Empty;
        [SerializeField] private string _userName = string.Empty;
        [SerializeField] private string _clientId = string.Empty;
        [SerializeField] private string _projectId = string.Empty;
        [SerializeField] private string _clientSecret = string.Empty;
        [SerializeField] private GoogleSheetTable[] _tables = Array.Empty<GoogleSheetTable>();

        private const string ConfigName = "com.catnexu.googlesheetsettings";

        public static GoogleSheetSettings Instance
        {
            get
            {
                if (s_instance == null && !EditorBuildSettings.TryGetConfigObject(ConfigName, out s_instance))
                    s_instance = CreateConfig();
                return s_instance;
            }
            set
            {
                if (s_instance == value)
                    return;

                if (EditorUtility.IsPersistent(value))
                {
                    EditorBuildSettings.AddConfigObject(ConfigName, value, true);
                    Debug.Log("Google sheets config changed to " + AssetDatabase.GetAssetPath(value));
                }

                s_instance = value;
            }
        }

        private static GoogleSheetSettings s_instance;


        public string ApplicationName => _googleApplicationName;
        public string User => _userName;

        public string Credentials =>
            string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_projectId) || string.IsNullOrEmpty(_clientSecret)
                ? string.Empty
                : "{\"installed\":{\"client_id\":\"" + _clientId + "\"," +
                "\"project_id\":\"" + _projectId + "\"," +
                "\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\"," +
                "\"token_uri\":\"https://oauth2.googleapis.com/token\"," +
                "\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\"," +
                "\"client_secret\":\"" + _clientSecret + "\"," +
                "\"redirect_uris\":[\"urn:ietf:wg:oauth:2.0:oob\"," +
                "\"http://localhost\"]}}";

        public bool TryGetTableId(string tableName, out string tableId)
        {
            tableId = string.Empty;
            for (var i = _tables.Length - 1; i >= 0; i--)
            {
                GoogleSheetTable table = _tables[i];
                if (table.Name == tableName)
                {
                    tableId = table.Id;
                    return true;
                }
            }

            return false;
        }

        [MenuItem(GoogleSheetsPath.MenuPath + "Open config")]
        private static void OpenOrCreateConfig()
        {
            GoogleSheetSettings instance = Instance;
            if (instance)
            {
                Selection.SetActiveObjectWithContext(instance, instance);
                EditorGUIUtility.PingObject(instance);
            }
        }

        private static GoogleSheetSettings CreateConfig()
        {
            string path = EditorUtility.SaveFilePanelInProject("Create Google Sheets Unity Config", "GoogleSheetsUnity.asset", "asset", "");
            if (string.IsNullOrEmpty(path))
                return null;

            GoogleSheetSettings instance = CreateInstance<GoogleSheetSettings>();
            AssetDatabase.CreateAsset(instance, path);
            EditorUtility.SetDirty(instance);
            return instance;
        }
    }
}