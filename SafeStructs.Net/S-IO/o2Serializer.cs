using System.Runtime.InteropServices;

namespace Oxygen
{
    internal static class o2Serializer
    {
        internal static byte[] ObjectToByteArray<T>(T obj) where T : struct
        {
            // No null check needed because T is a struct

            // Get the size of the object and allocate memory
            var size = Marshal.SizeOf(obj);
            var arr = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            // Copy the object to the allocated memory
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }
        internal static T ByteArrayToObject<T>(byte[] arrBytes)
        {
            var obj = default(T);
            var size = Marshal.SizeOf(obj);
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arrBytes, 0, ptr, size);
            obj = (T)Marshal.PtrToStructure(ptr, obj.GetType());
            Marshal.FreeHGlobal(ptr);
            return obj;
        }

        /// <summary>
        /// Simple XOR obfuscation method to obfuscate the data array.
        /// Also can be used to deobfuscate the data array.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static byte[] Obfuscate(byte[] data, int key)
        {
            byte[] r = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
                r[i] = (byte)(data[i] ^ (key & 0xFF));
            return r;
        }
    }
}
