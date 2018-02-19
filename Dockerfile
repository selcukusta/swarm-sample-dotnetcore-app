FROM microsoft/dotnet:2.0-sdk AS build-env
COPY . /swarm-sample-app
WORKDIR /swarm-sample-app
RUN dotnet restore
RUN dotnet publish -c Release -o publish-folder -r linux-x64
# build runtime image
FROM microsoft/dotnet:2.0-runtime 
COPY --from=build-env /swarm-sample-app/publish-folder ./
ENV ASPNETCORE_URLS=http://*:3000
EXPOSE 300
ENTRYPOINT ["dotnet", "swarm-sample-app.dll"]