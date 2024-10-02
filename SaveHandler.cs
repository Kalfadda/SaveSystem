using Sirenix.OdinInspector;
using UnityEngine;

namespace Scythe.Tools
{
    public class SaveHandler : MonoBehaviour
    {
        public string strngValue;
        public int integerValue;
        public float floatValue;
        public bool booleanValue;

        public Vector2 vec2;
        public Vector3 vec3;
        public Vector4 vec4;
        public Quaternion quat;
        public Color color;
        public Color32 color32;
        public Rect rect;
        public Bounds bounds;
        public Matrix4x4 matrix;
        public Ray ray;
        public Plane plane;
        public AnimationCurve curve;

        [Button("Save Data")]
        public void SaveData()
        {
            SaveSystem.SaveData("string", strngValue);
            SaveSystem.SaveData("int", integerValue);
            SaveSystem.SaveData("float", floatValue);
            SaveSystem.SaveData("bool", booleanValue);

            SaveSystem.SaveVector2("vec2", vec2);
            SaveSystem.SaveVector3("vec3", vec3);
            SaveSystem.SaveVector4("vec4", vec4);
            SaveSystem.SaveQuaternion("quat", quat);
            SaveSystem.SaveColor("color", color);
            SaveSystem.SaveColor32("color32", color32);
            SaveSystem.SaveRect("rect", rect);
            SaveSystem.SaveBounds("bounds", bounds);
            SaveSystem.SaveMatrix4x4("matrix", matrix);
            SaveSystem.SaveRay("ray", ray);
            SaveSystem.SavePlane("plane", plane);
            SaveSystem.SaveAnimationCurve("curve", curve);
        }

        [Button("Load Data")]
        public void LoadData()
        {
            strngValue = SaveSystem.LoadData("string", "default string");
            integerValue = SaveSystem.LoadData("int", 0);
            floatValue = SaveSystem.LoadData("float", 0f);
            booleanValue = SaveSystem.LoadData("bool", false);

            vec2 = SaveSystem.LoadVector2("vec2");
            vec3 = SaveSystem.LoadVector3("vec3");
            vec4 = SaveSystem.LoadVector4("vec4");
            quat = SaveSystem.LoadQuaternion("quat");
            color = SaveSystem.LoadColor("color");
            color32 = SaveSystem.LoadColor32("color32");
            rect = SaveSystem.LoadRect("rect");
            bounds = SaveSystem.LoadBounds("bounds");
            matrix = SaveSystem.LoadMatrix4x4("matrix");
            ray = SaveSystem.LoadRay("ray");
            plane = SaveSystem.LoadPlane("plane");
            curve = SaveSystem.LoadAnimationCurve("curve");
        }
    }
}