using UnityEditor;
using UnityEngine;


namespace Isekai.ShowAnimation
{

    [CustomEditor(typeof(GridAnimation))]
    public class ShowAnimation : Editor
    {
        private GridAnimation _animation;
        private Texture2D _texture;
        private int index = 0;
        private Timer _timer;

        private void OnEnable()
        {
            _animation = (GridAnimation)target;
            _texture = AssetPreview.GetAssetPreview(_animation._Sprites[index]);
            _timer = new Timer(1f, () => ChangeSprite());
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _timer.Tick();

            GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), _texture);

            EditorUtility.SetDirty(target);
        }

        private void ChangeSprite()
        {
            index++;
            if (index == _animation._Sprites.Count)
            {
                index = 0;
            }
            _texture = AssetPreview.GetAssetPreview(_animation._Sprites[index]);
        }
    }
}