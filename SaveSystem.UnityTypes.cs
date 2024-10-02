
using UnityEngine;
using System;

namespace Scythe.Tools
{
    public static partial class SaveSystem
    {
        #region Save Methods

        public static void SaveVector2(string key, Vector2 vector, string fileName = null)
        {
            SaveData(key, vector, fileName);
        }

        public static void SaveVector3(string key, Vector3 vector, string fileName = null)
        {
            SaveData(key, vector, fileName);
        }

        public static void SaveVector4(string key, Vector4 vector, string fileName = null)
        {
            SaveData(key, vector, fileName);
        }

        public static void SaveQuaternion(string key, Quaternion quaternion, string fileName = null)
        {
            SaveData(key, quaternion, fileName);
        }

        public static void SaveColor(string key, Color color, string fileName = null)
        {
            SaveData(key, color, fileName);
        }

        public static void SaveColor32(string key, Color32 color, string fileName = null)
        {
            SaveData(key, color, fileName);
        }

        public static void SaveRect(string key, Rect rect, string fileName = null)
        {
            SaveData(key, rect, fileName);
        }

        public static void SaveBounds(string key, Bounds bounds, string fileName = null)
        {
            SaveData(key, bounds, fileName);
        }

        public static void SaveMatrix4x4(string key, Matrix4x4 matrix, string fileName = null)
        {
            SaveData(key, matrix, fileName);
        }

        public static void SaveRay(string key, Ray ray, string fileName = null)
        {
            SaveData(key, ray, fileName);
        }

        public static void SavePlane(string key, Plane plane, string fileName = null)
        {
            SaveData(key, plane, fileName);
        }

        // Additional methods for custom types like AnimationCurve
        public static void SaveAnimationCurve(string key, AnimationCurve curve, string fileName = null)
        {
            SerializableAnimationCurve serializableCurve = new SerializableAnimationCurve(curve);
            SaveData(key, serializableCurve, fileName);
        }

        #endregion

        #region Load Methods

        public static Vector2 LoadVector2(string key, Vector2 fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Vector3 LoadVector3(string key, Vector3 fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Vector4 LoadVector4(string key, Vector4 fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Quaternion LoadQuaternion(string key, Quaternion fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Color LoadColor(string key, Color fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Color32 LoadColor32(string key, Color32 fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Rect LoadRect(string key, Rect fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Bounds LoadBounds(string key, Bounds fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Matrix4x4 LoadMatrix4x4(string key, Matrix4x4 fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Ray LoadRay(string key, Ray fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static Plane LoadPlane(string key, Plane fallbackValue = default)
        {
            return LoadData(key, fallbackValue);
        }

        public static AnimationCurve LoadAnimationCurve(string key, AnimationCurve fallbackValue = null)
        {
            SerializableAnimationCurve serializableCurve = LoadData<SerializableAnimationCurve>(key, null);
            if (serializableCurve != null)
            {
                return serializableCurve.ToAnimationCurve();
            }
            return fallbackValue ?? new AnimationCurve();
        }

        #endregion

        #region Serializable Classes for Custom Types

        [Serializable]
        private class SerializableAnimationCurve
        {
            public Keyframe[] keys;

            public SerializableAnimationCurve(AnimationCurve curve)
            {
                keys = curve.keys;
            }

            public AnimationCurve ToAnimationCurve()
            {
                return new AnimationCurve(keys);
            }
        }

        #endregion
    }
}
