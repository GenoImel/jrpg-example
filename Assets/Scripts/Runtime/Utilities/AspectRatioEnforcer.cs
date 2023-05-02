using UnityEngine;

// ReSharper disable InconsistentNaming
namespace Jrpg.Runtime.Utilities
{
    /// <summary>
    /// Aspect Ratio enforcement scripts were adopted from the following repo:
    /// <a href="https://github.com/huchi57/AspectRatioEnforcer">huchi57/AspectRationEnforcer</a>
    /// </summary>
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public class AspectRatioEnforcer : MonoBehaviour
    {
        private class DisplayMask
        {
            private Rect _mask1;
            private Rect _mask2;
            private Rect _viewport;

            public Rect Mask1 => _mask1;
            public Rect Mask2 => _mask2;
            public Rect Viewport => _viewport;

            public void SetLetterbox(float viewportHeight, float maskHeight, float viewportInset)
            {
                _mask1.Set(0, 0, Screen.width, maskHeight);
                _mask2.Set(0, maskHeight + viewportHeight, Screen.width, maskHeight);
                _viewport.Set(0, viewportInset / 2, 1, 1 - viewportInset);
            }

            public void SetPillarBox(float viewportWidth, float maskWidth, float viewportInset)
            {
                _mask1.Set(0, 0, maskWidth, Screen.height);
                _mask2.Set(maskWidth + viewportWidth, 0, maskWidth, Screen.height);
                _viewport.Set(viewportInset / 2, 0, 1 - viewportInset, 1);
            }

            public void ClearBox()
            {
                _mask1 = Rect.zero;
                _mask2 = Rect.zero;
                _viewport.Set(0, 0, 1, 1);
            }
        }

        [SerializeField] private bool _previewInEditMode = true;
        [SerializeField] private Color _maskColor = Color.black;
        [SerializeField, Min(0)] private float _aspectRatio = 16f / 9f;

        private static Texture2D _maskTexture;
        private static GUIStyle _style;
        private static Color _cacheMaskColor;
        private Camera _camera;
        private DisplayMask _mask;

        public bool PreviewInEditMode
        {
            get => _previewInEditMode;
            set => _previewInEditMode = value;
        }

        public Color MaskColor
        {
            get => _maskColor;
            set => _maskColor = value;
        }

        public float AspectRatio
        {
            get => _aspectRatio;
            set => _aspectRatio = value < 0f ? 0f : value;
        }

        private float ScreenRatio => Screen.width / (float)Screen.height;
        private float ViewportInset => 1f - (ScreenRatio / AspectRatio);

        private DisplayMask Mask
        {
            get
            {
                if (_mask == null)
                {
                    _mask = new DisplayMask();
                }
                return _mask;
            }
        }

        private void DrawMask()
        {
            if (_maskTexture == null)
            {
                _maskTexture = new Texture2D(1, 1);
                UpdateMaskColor(_maskColor);
            }

            if (_style == null)
            {
                _style = new GUIStyle();
            }

            if (_cacheMaskColor != _maskColor)
            {
                UpdateMaskColor(_maskColor);
            }

            _style.normal.background = _maskTexture;

            GUI.Box(Mask.Mask1, GUIContent.none, _style);
            GUI.Box(Mask.Mask2, GUIContent.none, _style);
            _camera.rect = Mask.Viewport;
        }

        private void ResetCamera()
        {
            Mask.ClearBox();
            _camera.rect = Mask.Viewport;
        }

        private void UpdateMaskColor(Color color)
        {
            _cacheMaskColor = color;
            _maskTexture.SetPixel(0, 0, color);
            _maskTexture.Apply();
        }

        private void OnGUI()
        {
            if (_previewInEditMode || Application.isPlaying)
            {
                if (_aspectRatio > ScreenRatio)
                {
                    float viewportHeight = _aspectRatio <= 0 ? Screen.height : Screen.width / _aspectRatio;
                    float maskHeight = (Screen.height - viewportHeight) / 2;
                    Mask.SetLetterbox(viewportHeight, maskHeight, ViewportInset);
                }

                else if (_aspectRatio < ScreenRatio)
                {
                    float viewportWidth = Screen.height * _aspectRatio;
                    float maskWidth = (Screen.width - viewportWidth) / 2;
                    Mask.SetPillarBox(viewportWidth, maskWidth, ViewportInset);
                }

                else
                {
                    Mask.ClearBox();
                }
            }
            else
            {
                Mask.ClearBox();
            }

            DrawMask();
        }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnDisable()
        {
            ResetCamera();
        }
    }
}
