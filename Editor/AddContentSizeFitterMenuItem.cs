using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
    internal static class AddContentSizeFitterMenuItem
    {
        [MenuItem( "CONTEXT/LayoutGroup/Add Content Size Fitter" )]
        [MenuItem( "CONTEXT/Text/Add Content Size Fitter" )]
        [MenuItem( "CONTEXT/TMP_Text/Add Content Size Fitter" )]
        private static void AddContentSizeFitter( MenuCommand menuCommand )
        {
            var component         = ( Component )menuCommand.context;
            var gameObject        = component.gameObject;
            var contentSizeFitter = Undo.AddComponent<ContentSizeFitter>( gameObject );
            var mode              = ContentSizeFitter.FitMode.PreferredSize;

            contentSizeFitter.horizontalFit = mode;
            contentSizeFitter.verticalFit   = mode;
        }

        [MenuItem( "CONTEXT/LayoutGroup/Add Content Size Fitter", true )]
        [MenuItem( "CONTEXT/Text/Add Content Size Fitter", true )]
        [MenuItem( "CONTEXT/TMP_Text/Add Content Size Fitter", true )]
        private static bool CanAddContentSizeFitter( MenuCommand menuCommand )
        {
            var component = ( Component )menuCommand.context;

            return !component.TryGetComponent<ContentSizeFitter>( out _ );
        }
    }
}