# .NET Serialization Experiments

Small .NET samples exploring serialization and deserialization with JSON, XML, and binary data. Most projects target .NET 10 and include unit tests.

[![CI](https://github.com/fernandezja/serialization-experiments-dotnet/actions/workflows/ci.yaml/badge.svg)](https://github.com/fernandezja/serialization-experiments-dotnet/actions/workflows/ci.yaml)

## Samples

| Project | What it demonstrates |
|---|---|
| [DeserializeObjectFromStringThatIsAnByteArray](DeserializeObjectFromStringThatIsAnByteArray) | Converts hexadecimal text to bytes and demonstrates legacy `BinaryFormatter` serialization/deserialization. **Proof of concept only.** |
| [SerializeObjectToByteArray](SerializeObjectToByteArray) | Serializes objects to byte arrays and restores them with `BinaryFormatter`. **Unsafe and unsupported on .NET 10; never use with untrusted data.** |
| [SerializeAndDeserializeJson](SerializeAndDeserializeJson) | Reads booking data from JSON with Newtonsoft.Json and writes selected reservation details. |
| [DeserializeJsonToDynamic](DeserializeJsonToDynamic) | Parses dollar values as a dynamic `JObject` and deserializes them into typed view models with Newtonsoft.Json. |
| [DeserializeJsonToListT](DeserializeJsonToListT) | Deserializes a JSON array into `List<Cliente>`, including Microsoft JSON date values, and prints a report. |
| [SystemTextJson](SystemTextJson) | Deserializes application configuration with `System.Text.Json` and prints a selected setting. |
| [SystemTextJsonToDynamic](SystemTextJsonToDynamic) | Deserializes movie JSON with `System.Text.Json`, including case-insensitive property names and default values. |
| [SerializeAndDeserializeXml](SerializeAndDeserializeXml) | Serializes and deserializes Jedi objects as XML, including XML namespaces. |

## Important security note

`BinaryFormatter` is obsolete, insecure, and not supported by modern .NET runtimes. The binary projects are educational experiments only. Use a supported format such as JSON, XML, or a safe binary serializer for production code.

## Running tests

Run all solution tests with:

```bash
dotnet test
```
