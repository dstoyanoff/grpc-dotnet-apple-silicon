FROM mcr.microsoft.com/dotnet/sdk:5.0

RUN apt-get update \
  && DEBIAN_FRONTEND=noninteractive \
  apt-get install --no-install-recommends --assume-yes \
  protobuf-compiler-grpc

ENV PROTOBUF_PROTOC=/usr/bin/protoc

RUN dotnet tool install -g dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /src

COPY scripts/start.sh start.sh
COPY grpc-dotnet.csproj .

RUN dotnet restore

COPY . .

RUN dotnet build
RUN dotnet publish -o /app/publish

EXPOSE 5000

ENTRYPOINT [ "/bin/sh", "start.sh" ]
