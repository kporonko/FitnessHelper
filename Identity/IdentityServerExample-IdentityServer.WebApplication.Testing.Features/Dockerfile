FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
EXPOSE 7199
ENV ASPNETCORE_URLS http://*:7199
ENTRYPOINT ["dotnet", "WebApplication.Testing.Features.dll"]