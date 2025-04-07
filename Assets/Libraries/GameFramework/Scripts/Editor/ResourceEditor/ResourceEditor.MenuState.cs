//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEditor;

namespace UnityGameFramework.Editor.ResourceTools
{
    public sealed partial class ResourceEditor : EditorWindow
    {
        private enum MenuState : byte
        {
            Normal,
            Add,
            Rename,
            Remove,
        }
    }
}
