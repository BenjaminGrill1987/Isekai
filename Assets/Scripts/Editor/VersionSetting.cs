using UnityEditor;
using UnityEngine;

namespace Isekai.Editor
{
    public class VersionSetting : EditorWindow
    {
        private string _newVersion;
        private bool _versionIsLoaded = false;

        [MenuItem("Settings/Version")]
        public static void ShowWindow()
        {
            GetWindow<VersionSetting>("Set Version");
        }

        private void OnGUI()
        {
            if (!_versionIsLoaded)
            {
                LoadVersion();
            }
            GUILayout.Label($"Actual Version: {Application.version}", EditorStyles.boldLabel);

            _newVersion = EditorGUILayout.TextField("New Version: ", _newVersion);

            if (GUILayout.Button("Change Version"))
            {
                ChangeVersion();
            }
        }

        private void LoadVersion()
        {
            _newVersion = Application.version;
            _versionIsLoaded = true;
        }

        private bool VersionNumberIsOk()
        {
            var oldVersion = Application.version.Split(".");
            var newVersion = _newVersion.Split(".");

            for (int index = 0; index < oldVersion.Length; index++)
            {
                int oldNumber;
                int newNumber;
                int.TryParse(oldVersion[index], out oldNumber);
                int.TryParse(newVersion[index], out newNumber);

                if (oldNumber > newNumber)
                {
                    return false;
                }
                if (newNumber > oldNumber)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeVersion()
        {
            if (VersionNumberIsOk())
            {
                PlayerSettings.bundleVersion = _newVersion;
            }
        }
    }
}