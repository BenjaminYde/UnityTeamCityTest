using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace MyCoolNameSpace
{
    public class GameBuilder
    {
        public static void PerformBuildWindows()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.locationPathName = "build/Windows";
            buildPlayerOptions.options = BuildOptions.None;

            BuildReport buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary buildSummary = buildReport.summary;

            if (buildSummary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build success!");
            }
            else
            {
                Debug.Log("Build failed!");
            }
        }
    }
}