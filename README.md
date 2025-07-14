# 🛡️ SafeStructs.Net - Memory Obfuscation for .NET

**SafeStructs** is a lightweight .NET library designed to store value types (`struct`) with memory obfuscation. It helps protect critical variables against tampering by tools such as Cheat Engine, by encrypting values in memory using XOR-based methods.

> ⚠️ This is not a cryptographic security system, but a simple obfuscation layer to make memory scanning and editing more difficult.

---

## 🚀 Features

- 🔒 **Data Obfuscation**: Stores values in memory using lightweight XOR encryption.
- 🧩 **Generic Support**: Works with any `struct`, including `int`, `float`, `bool`, and custom types like `Vector3`.
- 🧠 **Smart Operators**: Seamless integration with implicit/explicit conversions and operators.
- 🎮 **Unity Support**: Ideal for games and applications where critical data must be protected in-memory.

---

## 📦 Installation

You can use the library in two ways:

- **Manual**: Clone/download this repository and add the `.cs` files to your project.
- **DLL**: Add the precompiled DLL to your Unity or .NET project.

🔗 [Download SafeStructs DLL](https://github.com/OxygenButBeta/Safe-Structs-Obfuscation/blob/main/Build_SafeStructs.Net.dll)

---

## 🧪 Usage Example

```csharp
using Oxygen.Structs.NonEncrypted;

class Program
{
    static void Main()
    {
        Safe<int> myInt = 123456;
        Safe<float> myFloat = 3.14f;
        Safe<bool> myBool = true;

        int a = myInt;        // Implicit conversion
        float b = myFloat;
        bool c = myBool;

        myInt = 42;           // Reassignment
        myFloat += 1.0f;      // Operator support
    }
}

```
## Unity Example
```csharp
    // Let's assume this function returns a Vector3 that is important for your application
    Server.GetImportantVector3();

    // You need to store it to perform some calculations on it
    // If you use Vector3 directly, anyone can easily detect the value 
    // by using Cheat Engine or any other memory editor. They can locate 
    // the memory address, change the value, and send it to the server to cheat.
    Vector3 ImportantVector = Server.GetImportantVector3();

    // But if you use Safe<Vector3> instead of Vector3, the data will be stored securely,
    // making it much harder for cheaters to find and manipulate the memory address.
    Safe<Vector3> ImportantSafeVector = Server.GetImportantVector3();

    // Re-assigning the value
    ImportantSafeVector = Server.GetImportantVector3();

    // Perform calculations on the vector
    ImportantSafeVector = ImportantSafeVector + Vector3.one;

    // Then send it back to the server
    Server.SendImportantVector3(ImportantSafeVector);

