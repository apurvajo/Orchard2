FROM appsvc/dotnetcore:1.1.1-runtime
RUN cd /home ; git clone https://github.com/OrchardCMS/Orchard2.git
RUN cd /home/Orchard2 ; sh build.sh
RUN cd /home/Orchard2/src/Orchard.Web ; dotnet run
EXPOSE 5000
