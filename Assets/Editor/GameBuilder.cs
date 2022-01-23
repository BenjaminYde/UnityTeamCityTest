using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace MyCoolNameSpace
{
    public class GameBuilder
    {
        public static void PerformBuildWindows()
        {
            PerformPreBuildWindows();

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.locationPathName = "build/MyCoolGame.exe";
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

            PerformPostBuildWindows();
        }

        public static void PerformPostBuildWindows()
        {
            Debug.Log($"[Executing Post Build Windows]");
            Debug.Log("This is the post build...");
        }

        public static void PerformPreBuildWindows()
        {
            DeleteBuildFolder();
        }

        private static void DeleteBuildFolder()
        {
            Debug.Log($"[Deleting build folder...]");
            var pathCurrentDirectory = Directory.GetParent(Application.dataPath).FullName;
            Debug.Log($"Current directory is {pathCurrentDirectory}");
            var folderToDelete = Path.Combine(pathCurrentDirectory, "build");
            Debug.Log($"Folder to delete is {folderToDelete}");
            try
            {
                Directory.Delete(folderToDelete, true);
                Debug.Log($"Deleted the build folder!");
            }
            catch(Exception e)
            {
                Debug.Log($"Failed deleting the build folder! Exception message:\n{e.Message}");
            }
        }
    }
}