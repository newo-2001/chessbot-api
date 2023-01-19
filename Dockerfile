FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY . /app
WORKDIR /app
RUN dotnet build --configuration Release .

# FROM alpine AS stockfish
# RUN wget -q "https://uc593499563f6450fa0499b802d5.dl.dropboxusercontent.com/zip_download_get/BVAIG9SUao7RDDw7_4Dw63x4hXzLn0n1KLLTeiiz9Rw4CAd3osm6Ujr4edscv1Prc3U5IfLfOoU1Vw8lZfZpaJy_SV8SB-kDm4xeVNA2021_yw?dl=1" -O /stockfish_bundle.zip
# RUN unzip -d /stockfish_bundle /stockfish_bundle.zip && rm /stockfish_bundle.zip && unzip -d /stockfish /stockfish_bundle/stockfish_13_linux_x64.zip && rm -rf stockfish_bundle
# RUN chmod +x /stockfish/stockfish_13_linux_x64/stockfish_13_linux_x64

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS app

# COPY --from=stockfish /stockfish/stockfish_13_linux_x64 /stockfish
COPY Stockfish /stockfish
RUN chmod +x /stockfish

COPY --from=build /app/Chessbot.Api/bin/Release/net7.0 /app

#ENV STOCKFISH__PATH /stockfish/stockfish_13_linux_x64
ENTRYPOINT [ "dotnet", "/app/Chessbot.Api.dll" ]