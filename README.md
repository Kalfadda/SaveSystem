# Unity Save System

A robust and flexible save system for Unity that handles all primitive types, collections, and common Unity structs. Designed for internal use but made public in case it helps others save time. Future enhancements and robustness improvements are planned.

## Features

- **Easy Saving and Loading**: Save any serializable data with simple method calls.
- **Supports Primitive Types**: `int`, `float`, `string`, `bool`, etc.
- **Unity Structs Support**: `Vector2`, `Vector3`, `Vector4`, `Quaternion`, `Color`, `Rect`, `Bounds`, `Matrix4x4`, `Ray`, `Plane`, etc.
- **Collection Support**: Arrays and Lists of supported types.
- **Type Safety**: Ensures data integrity with type checking during load operations.
- **Custom Data Types**: Save custom classes and structs marked with `[Serializable]`.
- **File Management**: Saves data to JSON files in `Application.persistentDataPath`.

## Usage

### Saving Data

#### Primitive Types

```csharp
// Saving an integer
SaveSystem.SaveData("playerScore", 100);

// Saving a float
SaveSystem.SaveData("playerHealth", 75.5f);

// Saving a string
SaveSystem.SaveData("playerName", "Hero");

// Saving a boolean
SaveSystem.SaveData("isGameOver", false);
```
#### Unity Types

```csharp

// Saving a Vector3
Vector3 position = new Vector3(1.0f, 2.0f, 3.0f);
SaveSystem.SaveVector3("playerPosition", position);

// Saving a Quaternion
Quaternion rotation = Quaternion.Euler(0, 90, 0);
SaveSystem.SaveQuaternion("playerRotation", rotation);

// Saving a Color
Color favoriteColor = Color.green;
SaveSystem.SaveColor("favoriteColor", favoriteColor);

// Saving a Rect
Rect uiRect = new Rect(0, 0, 100, 50);
SaveSystem.SaveRect("uiElementRect", uiRect);
```
#### Collections

```csharp

// Saving an array
int[] highScores = new int[] { 1000, 2000, 3000 };
SaveSystem.SaveData("highScores", highScores);```

// Saving a list
List<string> inventory = new List<string> { "Sword", "Shield", "Potion" };
SaveSystem.SaveData("inventoryList", inventory);
```
### Loading Data

#### Primitive Types

```csharp

// Loading an integer
int playerScore = SaveSystem.LoadData("playerScore", 0);

// Loading a float
float playerHealth = SaveSystem.LoadData("playerHealth", 100.0f);

// Loading a string
string playerName = SaveSystem.LoadData("playerName", "DefaultName");

// Loading a boolean
bool isGameOver = SaveSystem.LoadData("isGameOver", false);
```
#### Unity Types

```csharp

// Loading a Vector3
Vector3 defaultPosition = Vector3.zero;
Vector3 loadedPosition = SaveSystem.LoadVector3("playerPosition", defaultPosition);

// Loading a Quaternion
Quaternion defaultRotation = Quaternion.identity;
Quaternion loadedRotation = SaveSystem.LoadQuaternion("playerRotation", defaultRotation);

// Loading a Color
Color defaultColor = Color.white;
Color loadedColor = SaveSystem.LoadColor("favoriteColor", defaultColor);

// Loading a Rect
Rect defaultRect = new Rect(0, 0, 0, 0);
Rect loadedRect = SaveSystem.LoadRect("uiElementRect", defaultRect);
```
#### Collections

```csharp

// Loading an array
int[] loadedHighScores = SaveSystem.LoadData("highScores", new int[0]);

// Loading a list
List<string> loadedInventory = SaveSystem.LoadData("inventoryList", new List<string>());
```

### Notes
- Internal Use: This save system was developed for internal purposes but is shared publicly to help others save time.
- Future Enhancements: Plans to add more robustness and support for additional types in future updates.
- Type Safety: Always ensure the type you load matches the type you saved to prevent type mismatch warnings.
