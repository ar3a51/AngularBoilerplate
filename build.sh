#!/bin/sh
dotnet restore
dotnet build --configuration Release
cd Angular.Web
npm install
npm run prod