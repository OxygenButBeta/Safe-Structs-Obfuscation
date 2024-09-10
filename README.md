#SafeStructs.Net - Memory Obfuscation for .NET
SafeStructs is a .NET package designed to securely and easliy handle and obfuscate values in memory by converting them into byte arrays and applying obfuscation. This approach helps prevent unauthorized tools from easily accessing and modifying these values.

###Important Notes
- **Obfuscation Key: The obfuscation key is used to scramble the byte array. While this method makes it more difficult to access values, it is not 100% secure.
  
- **Performance Considerations: Due to the additional obfuscation layer, there will be performance overhead compared to normal value types.
The SafeStruct implementation consumes more memory and can be less efficient compared to direct value types due to additional processing and obfuscation. While direct value types can still be easily accessed and altered by tools like Cheat Engine or similar software, SafeStruct provides a more robust protection mechanism to prevent such easy modifications. It is recommended to use this approach only for critical variables within your project.

## Features

- **Data Obfuscation**: Securely stores values in memory using XOR encryption.
- **Generic Support**: Works with any value type (`struct`).
- **Ease of Use**: Implicit and explicit operators make it easy to work with obfuscated values.

## Installation

You can add SafeStructs to your project manually by copying the source code or by including the dll in your project directly.
- **Dll**: ([https://github.com/kullaniciadi/repositoryadi/blob/main/src/SafeStruct.cs#L10-L20](https://github.com/OxygenButBeta/Safe-Structs-Obfuscation/blob/main/Build_SafeStructs.Net.dll)).

## Usage

Here’s a quick example of how to use SafeStructs:

```csharp
using SafeStructs;

class Program
{
    static void Main()
    {
        // Create a Safe<int> instance with an initial value
        Safe<int> safeValue = 51231123;

        // Retrieve the value from Safe<int>
        int a = safeValue;
        int b = safeValue;

        // Check if values are equal
        if (a == safeValue)
        {
            Console.WriteLine("Values match!");
        }

        // Print the value
        Console.WriteLine($"The stored value is: {safeValue}");
    }
}
