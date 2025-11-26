#!/bin/bash
cd ../../NTools/Backend/NTools
pwd
dotnet build -c Release NTools.sln
cd ./NTools.ACL/bin/Release/net8.0
pwd
cp NTools.ACL.dll ../../../../../../../ResumeCV/Backend/ResumeCV/Lib
cp NTools.DTO.dll ../../../../../../../ResumeCV/Backend/ResumeCV/Lib
