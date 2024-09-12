using Oxygen;

/// <summary>
/// Same as Safe<T> but with a read-only value. and cannot be desrialized.
/// This struct is used to store a value in a secure way in memory.
/// The key is used to obfuscate the value in memory and make it more difficult for memory scanners to find the value.
/// However, it is not 100% secure; it is just a method to make it harder to locate the value.
/// Note that this approach is inherently slower than using normal value types.
/// </summary>
public readonly struct ReadOnlySafe<T> where T : struct
{
    // Properties 
    public T Value => o2Serializer.ByteArrayToObject<T>(o2Serializer.Obfuscate(ValueAsArray, key));

    private readonly byte[] ValueAsArray;
    private const int key = 1726185659; //(XOR key do not forget to change)

    // Constructor
    public ReadOnlySafe(T inputValue) => ValueAsArray = o2Serializer.Obfuscate(o2Serializer.ObjectToByteArray(inputValue), key);

    // Implicit conversions
    public static implicit operator ReadOnlySafe<T>(T inputValue) => new ReadOnlySafe<T>(inputValue);
    public static implicit operator T(ReadOnlySafe<T> safeValue) => safeValue.Value;

    // equality checks
    public static bool operator ==(ReadOnlySafe<T> a, T b)
    {
        if (ReferenceEquals(a, null))
            return ReferenceEquals(b, null);

        return a.Value.Equals(b);
    }
    public static bool operator !=(ReadOnlySafe<T> a, T b) => !(a == b);

    // Overrides 
    public override bool Equals(object obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
}
/* 
         _____                            ______       _  ______      _        
        |  _  |                           | ___ \     | | | ___ \    | |       
        | | | |_  ___   _  __ _  ___ _ __ | |_/ /_   _| |_| |_/ / ___| |_ __ _ 
        | | | \ \/ / | | |/ _` |/ _ \ '_ \| ___ \ | | | __| ___ \/ _ \ __/ _` |
        \ \_/ />  <| |_| | (_| |  __/ | | | |_/ / |_| | |_| |_/ /  __/ || (_| |
         \___//_/\_\\__, |\__, |\___|_| |_\____/ \__,_|\__\____/ \___|\__\__,_|
                     __/ | __/ |                                               
                    |___/ |___/      

        https://github.com/OxygenButBeta
 */
