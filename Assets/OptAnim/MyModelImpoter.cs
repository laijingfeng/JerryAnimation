using UnityEditor;

public class MyModelImporter : AssetPostprocessor
{
    void OnPreprocessModel()
    {
        if (assetPath.Contains(".FBX") == false && assetPath.Contains(".fbx") == false)
        {
            return;
        }

        //HandleHuman();
        HandleGeneric();
    }

    private void HandleGeneric()
    {
        bool isAnimation = assetPath.Contains("@");

        ModelImporter mi = assetImporter as ModelImporter;
        mi.animationType = ModelImporterAnimationType.Generic;
        mi.assetBundleName = string.Empty;

        if (isAnimation)
        {
            mi.importAnimation = true;
            mi.importMaterials = false;
        }
        else
        {
            mi.importAnimation = false;
            mi.importMaterials = true;
            mi.materialName = ModelImporterMaterialName.BasedOnMaterialName;
        }
    }

    private void HandleHuman()
    {
        bool isAnimation = assetPath.Contains("@");

        ModelImporter mi = assetImporter as ModelImporter;
        mi.animationType = ModelImporterAnimationType.Human;

        mi.globalScale = 1f;
        mi.meshCompression = ModelImporterMeshCompression.Off;
        mi.isReadable = true;
        mi.optimizeMesh = true;
        mi.importBlendShapes = true;
        mi.addCollider = false;
        mi.swapUVChannels = false;
        mi.importNormals = ModelImporterNormals.Import;
        mi.importTangents = ModelImporterTangents.CalculateMikk;
        mi.assetBundleName = string.Empty;

        if (isAnimation)
        {
            mi.importAnimation = true;
            mi.importMaterials = false;
            //mi.motionNodeName = "Bip001";
        }
        else
        {
            mi.importAnimation = false;

            mi.importMaterials = true;
            mi.materialName = ModelImporterMaterialName.BasedOnTextureName;
            mi.materialSearch = ModelImporterMaterialSearch.RecursiveUp;
        }
    }
}