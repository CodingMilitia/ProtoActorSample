protoc Protos.proto -I=. --csharp_out=. --csharp_opt=file_extension=.g.cs --grpc_out . --plugin=protoc-gen-grpc=%userprofile%\.nuget\packages\Grpc.Tools\1.2.2\tools\windows_x64\grpc_csharp_plugin.exe
