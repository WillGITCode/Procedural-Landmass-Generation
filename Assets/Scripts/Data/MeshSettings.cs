using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MeshSettings : UpdatableData
{
    public const int numSupportedLODs = 5;
    public const int numSupportedChunkSizes = 9;
    public const int numSupportedFlatShadingLayers = 3;
    public static readonly int[] supportedChunkSizes = { 48, 72, 96, 120, 144, 168, 192, 216, 240 };
    public static readonly int[] supportedFlatShadedChunkSizes = { 48, 72, 96 };
    public float meshScale = 2.5f;
    public bool useFlatShading;
    [Range(0, numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;
    [Range(0, numSupportedFlatShadingLayers - 1)]
    public int flatshadedChunkSizeIndex;

    // num verts per line of mesh redered at LOD = 0. Includes the 2 extra verts that are excluded from the mesh, but used for the borders
    public int numVertsPerLine
    {
        get
        {
            return supportedChunkSizes[(useFlatShading) ? flatshadedChunkSizeIndex : chunkSizeIndex] + 5;
        }
    }

    public float meshWorldSize{
        get{
            return (numVertsPerLine - 3) * meshScale;
        }
    }
}
