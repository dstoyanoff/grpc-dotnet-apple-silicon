#!/bin/sh

dotnet ef database update

dotnet /app/publish/grpc-dotnet.dll
