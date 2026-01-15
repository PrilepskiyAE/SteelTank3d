using UnityEditor;
using UnityEngine;

public class ConvertToStandardShader : EditorWindow
{
    [MenuItem("Tools/Convert URP Lit to Standard Shader")]
    static void Convert()
    {
        // Находим все материалы в проекте
        var materialGUIDs = AssetDatabase.FindAssets("t:Material");
        foreach (var guid in materialGUIDs)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var material = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (material != null && material.shader != null)
            {
                // Проверяем, что шейдер — из URP
                if (material.shader.name.Contains("Universal Render Pipeline/Lit"))
                {
                    // Меняем на Standard
                    material.shader = Shader.Find("Standard");
                    Debug.Log($"Converted: {material.name}");
                }
            }
        }
        AssetDatabase.SaveAssets();
        Debug.Log("Conversion completed!");
    }
}