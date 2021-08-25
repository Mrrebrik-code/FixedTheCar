using Mechanics.SketchBook;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class ToolsForEditor
    {
        [MenuItem("Tools/Zero progress")]
        private static void ProgressToZero()
        {
            var dataFinish = new DataFinishedLevel();
            dataFinish.Clear();
            LogicPrometerOnSketchBook.ZeroMe();
        }
    }
}