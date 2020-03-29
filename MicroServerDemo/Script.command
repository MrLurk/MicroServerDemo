cd "/Users/l/My Project/MicroServerDemo/MicroServerDemo/Main/bin/Debug/netcoreapp3.1"
nohup dotnet Main.dll &
cd "/Users/l/My Project/MicroServerDemo/MicroServerDemo/Server1/bin/Debug/netcoreapp3.1"
nohup dotnet Server1.dll &
cd "/Users/l/My Project/MicroServerDemo/MicroServerDemo/Server2/bin/Debug/netcoreapp3.1"
nohup dotnet Server2.dll & echo 完成 & pause
 