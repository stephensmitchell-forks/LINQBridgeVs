﻿using System.IO;
using System.Reflection;
using BridgeVs.Build.Tasks;
using BridgeVs.Build.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.UnitTest;

namespace BridgeVs.Build.UnitTest
{
    [TestClass]
    public class CleanBuildTest
    {
        private static Assembly _assemblyModel;

        private static void CreateDllAndPdb(string visualizerFullPath, string visualizerPdbFullPath)
        {
            using (File.Create(visualizerFullPath))
            {
            }

            using (File.Create(visualizerPdbFullPath))
            {
            }
        }
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _assemblyModel = typeof(CustomType1).Assembly;
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Clean_BuildTask_Test_V11_Should_Succeed()
        {
            const string vsVersion = "11.0";
            var visualizerAssemblyName = VisualizerAssemblyNameFormat.GetTargetVisualizerAssemblyName(vsVersion, _assemblyModel.Location);
            var targetInstallationPath = VisualStudioOptions.GetInstallationPath(vsVersion);
            var visualizerFullPath = Path.Combine(targetInstallationPath, visualizerAssemblyName);
            var visualizerPdbFullPath = Path.GetFileNameWithoutExtension(visualizerFullPath) + ".pdb";
            CreateDllAndPdb(visualizerFullPath, visualizerPdbFullPath);


            var cleanBuildTask = new CleanBuildTask
            {
                Assembly = _assemblyModel.Location,
                VisualStudioVer = vsVersion
            };

            var result = cleanBuildTask.Execute();

            Assert.IsTrue(result, $"Clean build task V{vsVersion} failed");
            Assert.IsFalse(File.Exists(visualizerFullPath), $"{visualizerFullPath} hasn't been deleted correctly");
            Assert.IsFalse(File.Exists(visualizerPdbFullPath), $"{visualizerPdbFullPath} hasn't been deleted correctly");
        }


        [TestMethod]
        [TestCategory("UnitTest")]
        public void Clean_BuildTask_Test_V12_Should_Succeed()
        {
            const string vsVersion = "12.0";
            var visualizerAssemblyName = VisualizerAssemblyNameFormat.GetTargetVisualizerAssemblyName(vsVersion, _assemblyModel.Location);
            var targetInstallationPath = VisualStudioOptions.GetInstallationPath(vsVersion);
            var visualizerFullPath = Path.Combine(targetInstallationPath, visualizerAssemblyName);
            var visualizerPdbFullPath = Path.GetFileNameWithoutExtension(visualizerFullPath) + ".pdb";
            CreateDllAndPdb(visualizerFullPath, visualizerPdbFullPath);


            var cleanBuildTask = new CleanBuildTask
            {
                Assembly = _assemblyModel.Location,
                VisualStudioVer = vsVersion
            };

            var result = cleanBuildTask.Execute();

            Assert.IsTrue(result, $"Clean build task V{vsVersion} failed");
            Assert.IsFalse(File.Exists(visualizerFullPath), $"{visualizerFullPath} hasn't been deleted correctly");
            Assert.IsFalse(File.Exists(visualizerPdbFullPath), $"{visualizerPdbFullPath} hasn't been deleted correctly");
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Clean_BuildTask_Test_V14_Should_Succeed()
        {
            const string vsVersion = "14.0";
            var visualizerAssemblyName = VisualizerAssemblyNameFormat.GetTargetVisualizerAssemblyName(vsVersion, _assemblyModel.Location);
            var targetInstallationPath = VisualStudioOptions.GetInstallationPath(vsVersion);
            var visualizerFullPath = Path.Combine(targetInstallationPath, visualizerAssemblyName);
            var visualizerPdbFullPath = Path.GetFileNameWithoutExtension(visualizerFullPath) + ".pdb";
            CreateDllAndPdb(visualizerFullPath, visualizerPdbFullPath);


            var cleanBuildTask = new CleanBuildTask
            {
                Assembly = _assemblyModel.Location,
                VisualStudioVer = vsVersion
            };

            var result = cleanBuildTask.Execute();

            Assert.IsTrue(result, $"Clean build task V{vsVersion} failed");
            Assert.IsFalse(File.Exists(visualizerFullPath), $"{visualizerFullPath} hasn't been deleted correctly");
            Assert.IsFalse(File.Exists(visualizerPdbFullPath), $"{visualizerPdbFullPath} hasn't been deleted correctly");
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        public void Clean_BuildTask_Test_V15_Should_Succeed()
        {
            const string vsVersion = "15.0";
            var visualizerAssemblyName = VisualizerAssemblyNameFormat.GetTargetVisualizerAssemblyName(vsVersion, _assemblyModel.Location);
            var targetInstallationPath = VisualStudioOptions.GetInstallationPath(vsVersion);
            var visualizerFullPath = Path.Combine(targetInstallationPath, visualizerAssemblyName);
            var visualizerPdbFullPath = Path.GetFileNameWithoutExtension(visualizerFullPath) + ".pdb";

            CreateDllAndPdb(visualizerFullPath, visualizerPdbFullPath);

            var cleanBuildTask = new CleanBuildTask
            {
                Assembly = _assemblyModel.Location,
                VisualStudioVer = vsVersion
            };

            var result = cleanBuildTask.Execute();

            Assert.IsTrue(result, $"Clean build task V{vsVersion} failed");
            Assert.IsFalse(File.Exists(visualizerFullPath), $"{visualizerFullPath} hasn't been deleted correctly");
            Assert.IsFalse(File.Exists(visualizerPdbFullPath), $"{visualizerPdbFullPath} hasn't been deleted correctly");
        }
    }
}