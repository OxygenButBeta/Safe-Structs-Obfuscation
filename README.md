## SafeStructs.Net - Memory Obfuscation for .NET
SafeStructs is a .NET  is a part of my personal library used in various projects. It is designed to store values in memory with obfuscation to make it harder for memory scanners and similar tools to access and modify the data.

## Important Notes
- Obfuscation Key: The obfuscation key is used to scramble the byte array. While this method makes it more difficult to access values, it is not 100% secure.
  
- Performance Considerations: Due to the additional obfuscation layer, there will be performance overhead compared to normal value types.
The SafeStruct implementation consumes more memory and can be less efficient compared to direct value types due to additional processing and obfuscation. While direct value types can still be easily accessed and altered by tools like Cheat Engine or similar software, SafeStruct provides a more robust protection mechanism to prevent such easy modifications. It is recommended to use this approach only for critical variables within your project.

## Features

- **Data Obfuscation**: Securely stores values in memory using XOR encryption.
- **Generic Support**: Works with any value type (`struct`).
- **Ease of Use**: Implicit and explicit operators make it easy to work with obfuscated values.

## Installation

You can add SafeStructs to your project manually by copying the source code or by including the dll in your project directly.
- **Dll**: [You can click here to go to the dll](https://github.com/OxygenButBeta/Safe-Structs-Obfuscation/blob/main/Build_SafeStructs.Net.dll)

## Usage

Here’s a quick example of how to use SafeStructs:

```csharp
using Oxygen.Structs.NonEncrypted;

static void Main()
{
    // Create a Safe<int> instance with an initial value
    Safe<int> _int = 51231123;  // Initialize a Safe<int> with an integer value
    Safe<float> _float = 3.14f; // Initialize a Safe<float> with a float value
    Safe<bool> _bool = true;    // Initialize a Safe<bool> with a boolean value

    // Retrieve the value from Safe<int>
    int a = _int; // Directly retrieve the integer value from Safe<int>
    float b = _float; // Directly retrieve the float value from Safe<float>
    bool c = _bool; // Directly retrieve the boolean value from Safe<bool>
    
    // Note: The usage of Safe<T> is similar to using normal variables.
    // You can directly assign Safe<T> instances to variables of type T,
    // and you can use them as if they were regular values.
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

