FROM appsvc/dotnetcore:1.1.1-runtime
RUN apt-get update
RUN apt-get install -y gettext zip unzip git uuid-runtime
RUN cd /home ; git clone https://github.com/OrchardCMS/Orchard2.git
RUN cd /home/Orchard2 ; sh build.sh
RUN cd /home/Orchard2/src/Orchard.Web ; dotnet run
EXPOSE 5000
